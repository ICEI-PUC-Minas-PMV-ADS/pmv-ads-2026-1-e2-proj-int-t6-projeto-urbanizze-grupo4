using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Urbanizze.Pages.Cidadaos;

public class IndexModel : PageModel
{
    private readonly AppDbContext _context;

    public IndexModel(AppDbContext context)
    {
        _context = context;
    }

    public IList<Cidadao> Cidadaos { get; set; } = new List<Cidadao>();
    public Dictionary<int, string> CidadaoCidade { get; set; } = new();

    public async Task OnGetAsync()
    {
        Cidadaos = await _context.Cidadaos.ToListAsync();

        var cidadesPorCidadao = await _context.Denuncias
            .Include(d => d.Departamento)
                .ThenInclude(dep => dep.PrefeituraCidade)
            .GroupBy(d => d.CidadaoId)
            .Select(g => new {
                CidadaoId = g.Key,
                Cidade = g.OrderByDescending(d => d.CriadoEm)
                           .Select(d => d.Departamento.PrefeituraCidade.Nome)
                           .FirstOrDefault()
            })
            .ToListAsync();

        CidadaoCidade = cidadesPorCidadao
            .Where(x => x.Cidade != null)
            .ToDictionary(x => x.CidadaoId, x => x.Cidade!);
    }
}
