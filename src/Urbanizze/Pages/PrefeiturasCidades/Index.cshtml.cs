using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Urbanizze.Pages.PrefeiturasCidades;

public class IndexModel : PageModel
{
    private readonly AppDbContext _context;

    public IndexModel(AppDbContext context)
    {
        _context = context;
    }

    public IList<PrefeituraCidade> Prefeituras { get; set; } = new List<PrefeituraCidade>();

    public async Task OnGetAsync()
    {
        Prefeituras = await _context.PrefeiturasCidades
            .Include(p => p.Departamentos)
            .ToListAsync();
    }
}
