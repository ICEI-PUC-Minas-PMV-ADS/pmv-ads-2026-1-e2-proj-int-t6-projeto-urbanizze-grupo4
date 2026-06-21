using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Urbanizze.Controllers;

public class DenunciasController : Controller
{
    private readonly AppDbContext _context;

    public DenunciasController(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index(string? busca, string? filtroStatus, string? filtroCategoria)
    {
        var query = _context.Denuncias
            .Include(d => d.Cidadao)
            .Include(d => d.Departamento)
                .ThenInclude(dep => dep.PrefeituraCidade)
            .AsQueryable();

        if (!string.IsNullOrWhiteSpace(busca))
        {
            query = query.Where(d => d.Titulo.Contains(busca) || d.Descricao.Contains(busca));
        }

        if (!string.IsNullOrWhiteSpace(filtroStatus))
        {
            if (Enum.TryParse<StatusDenuncia>(filtroStatus, out var status))
            {
                query = query.Where(d => d.StatusDenuncia == status);
            }
        }

        if (!string.IsNullOrWhiteSpace(filtroCategoria))
        {
            query = query.Where(d => d.Departamento.Nome == filtroCategoria);
        }

        var denuncias = await query.OrderByDescending(d => d.CriadoEm).ToListAsync();

        var todas = await _context.Denuncias.ToListAsync();
        ViewBag.TotalDenuncias = todas.Count;
        ViewBag.TotalAbertas = todas.Count(d => d.StatusDenuncia == StatusDenuncia.ABERTA);
        ViewBag.TotalEmAnalise = todas.Count(d => d.StatusDenuncia == StatusDenuncia.EM_ANALISE);
        ViewBag.TotalResolvidas = todas.Count(d => d.StatusDenuncia == StatusDenuncia.CONCLUIDA);
        ViewBag.Busca = busca;
        ViewBag.FiltroStatus = filtroStatus;
        ViewBag.FiltroCategoria = filtroCategoria;

        return View(denuncias);
    }

    public async Task<IActionResult> Detalhes(int id)
    {
        var denuncia = await _context.Denuncias
            .Include(d => d.Cidadao)
            .Include(d => d.Departamento)
                .ThenInclude(dep => dep.PrefeituraCidade)
            .Include(d => d.Mensagens.OrderBy(m => m.CriadoEm))
                .ThenInclude(m => m.Cidadao)
            .Include(d => d.Mensagens)
                .ThenInclude(m => m.Funcionario)
                    .ThenInclude(f => f!.Cidadao)
            .FirstOrDefaultAsync(d => d.Id == id);

        if (denuncia == null)
            return RedirectToAction("Index");

        return View(denuncia);
    }

    [HttpPost]
    public async Task<IActionResult> EnviarMensagem(int id, string novaMensagem)
    {
        var denuncia = await _context.Denuncias.FindAsync(id);

        if (denuncia == null)
            return RedirectToAction("Index");

        if (!string.IsNullOrWhiteSpace(novaMensagem))
        {
            var mensagem = new Mensagem
            {
                DenunciaId = id,
                CidadaoId = denuncia.CidadaoId,
                Texto = novaMensagem,
                CriadoEm = DateTime.UtcNow
            };

            _context.Mensagens.Add(mensagem);
            await _context.SaveChangesAsync();
        }

        return RedirectToAction("Detalhes", new { id });
    }

    [HttpPost]
    public async Task<IActionResult> AlterarStatus(int id, string novoStatus)
    {
        var denuncia = await _context.Denuncias.FindAsync(id);

        if (denuncia != null && Enum.TryParse<StatusDenuncia>(novoStatus, out var status))
        {
            denuncia.StatusDenuncia = status;
            denuncia.AtualizadoEm = DateTime.UtcNow;
            await _context.SaveChangesAsync();
        }

        return RedirectToAction("Detalhes", new { id });
    }

        public async Task<IActionResult> Criar()
    {
        ViewBag.Departamentos = await _context.Departamentos
            .Include(d => d.PrefeituraCidade)
            .ToListAsync();

        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Criar(string titulo, string descricao, int departamentoId, string? localizacao, bool anonima)
    {
        var cidadaoId = HttpContext.Session.GetInt32("UsuarioId");

        if (cidadaoId == null)
            return RedirectToAction("Index");

        var denuncia = new Denuncia
        {
            CidadaoId = cidadaoId.Value,
            DepartamentoId = departamentoId,
            Titulo = titulo,
            Descricao = descricao,
            Localizacao = localizacao,
            Anonima = anonima,
            StatusDenuncia = StatusDenuncia.ABERTA,
            CriadoEm = DateTime.UtcNow,
            AtualizadoEm = DateTime.UtcNow
        };

        _context.Denuncias.Add(denuncia);
        await _context.SaveChangesAsync();

        return RedirectToAction("Index");
    }
}
