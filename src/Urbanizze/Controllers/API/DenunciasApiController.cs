using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("api/denuncias")]
public class DenunciasApiController : ControllerBase
{
    private readonly AppDbContext _context;

    public DenunciasApiController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll(
        [FromQuery] string? busca,
        [FromQuery] string? status,
        [FromQuery] string? departamento,
        [FromQuery] string? periodo,
        [FromQuery] string? localizacao)
    {
        var query = _context.Denuncias
            .Include(d => d.Cidadao)
            .Include(d => d.Departamento)
            .AsQueryable();

        if (!string.IsNullOrEmpty(busca))
            query = query.Where(d =>
                d.Titulo.Contains(busca) ||
                d.Descricao.Contains(busca) ||
                d.Localizacao.Contains(busca));

        if (!string.IsNullOrEmpty(status) && Enum.TryParse<StatusDenuncia>(status, true, out var statusEnum))
            query = query.Where(d => d.StatusDenuncia == statusEnum);

        if (!string.IsNullOrEmpty(departamento))
            query = query.Where(d => d.Departamento.Nome.Contains(departamento));

        if (!string.IsNullOrEmpty(localizacao))
            query = query.Where(d => d.Localizacao.Contains(localizacao));

        if (!string.IsNullOrEmpty(periodo))
        {
            var hoje = DateTime.Today;
            query = periodo switch
            {
                "hoje" => query.Where(d => d.CriadoEm.Date == hoje),
                "7d"   => query.Where(d => d.CriadoEm >= hoje.AddDays(-7)),
                "30d"  => query.Where(d => d.CriadoEm >= hoje.AddDays(-30)),
                "90d"  => query.Where(d => d.CriadoEm >= hoje.AddDays(-90)),
                _      => query
            };
        }

        var resultado = await query
            .OrderByDescending(d => d.CriadoEm)
            .Select(d => new
            {
                id            = d.Id,
                titulo        = d.Titulo,
                descricao     = d.Descricao,
                localizacao   = d.Localizacao,
                status        = d.StatusDenuncia.ToString(),
                departamento  = d.Departamento.Nome,
                cidadao       = d.Cidadao.Nome,
                criadoEm      = d.CriadoEm.ToString("yyyy-MM-dd")
            })
            .ToListAsync();

        return Ok(resultado);
    }
}