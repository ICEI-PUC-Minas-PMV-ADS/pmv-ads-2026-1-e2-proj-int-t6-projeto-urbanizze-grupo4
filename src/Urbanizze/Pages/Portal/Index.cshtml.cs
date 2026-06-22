using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Urbanizze.Pages.Portal;

public class IndexModel : PageModel
{
    private readonly AppDbContext _context;

    public IndexModel(AppDbContext context)
    {
        _context = context;
    }

    public List<PrefeituraCidade> Cidades { get; set; } = new();
    public PrefeituraCidade? CidadeSelecionada { get; set; }
    public List<Denuncia> Denuncias { get; set; } = new();
    public int TotalDenuncias { get; set; }
    public int TotalAbertas { get; set; }
    public int TotalEmAnalise { get; set; }
    public int TotalResolvidas { get; set; }

    public async Task OnGetAsync(int? cidadeId)
    {
        Cidades = await _context.PrefeiturasCidades
            .OrderBy(c => c.Nome)
            .ToListAsync();

        if (cidadeId.HasValue)
        {
            CidadeSelecionada = await _context.PrefeiturasCidades
                .FirstOrDefaultAsync(c => c.Id == cidadeId.Value);

            if (CidadeSelecionada != null)
            {
                Denuncias = await _context.Denuncias
                    .Include(d => d.Departamento)
                    .Where(d => d.Departamento.PrefeituraCidadeId == cidadeId.Value)
                    .OrderByDescending(d => d.CriadoEm)
                    .ToListAsync();

                TotalDenuncias = Denuncias.Count;
                TotalAbertas = Denuncias.Count(d => d.StatusDenuncia == StatusDenuncia.ABERTA);
                TotalEmAnalise = Denuncias.Count(d => d.StatusDenuncia == StatusDenuncia.EM_ANALISE);
                TotalResolvidas = Denuncias.Count(d => d.StatusDenuncia == StatusDenuncia.CONCLUIDA);
            }
        }
    }
}
