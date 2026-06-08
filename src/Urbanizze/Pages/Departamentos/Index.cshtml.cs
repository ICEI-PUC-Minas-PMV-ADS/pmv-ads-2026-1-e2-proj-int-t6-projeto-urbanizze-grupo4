using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Urbanizze.Pages.Departamentos;

public class IndexModel : PageModel
{
    private readonly AppDbContext _context;

    public IndexModel(AppDbContext context)
    {
        _context = context;
    }

    public IList<Departamento> Departamentos { get; set; } = new List<Departamento>();

    public async Task OnGetAsync()
    {
        Departamentos = await _context.Departamentos
            .Include(d => d.PrefeituraCidade)
            .Include(d => d.Funcionarios)
            .ToListAsync();
    }
}
