using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Urbanizze.Pages.Funcionarios;

public class IndexModel : PageModel
{
    private readonly AppDbContext _context;

    public IndexModel(AppDbContext context)
    {
        _context = context;
    }

    public IList<Funcionario> Funcionarios { get; set; } = new List<Funcionario>();

    public async Task OnGetAsync()
    {
        Funcionarios = await _context.Funcionarios
            .Include(f => f.Cidadao)
            .Include(f => f.Departamento)
                .ThenInclude(d => d.PrefeituraCidade)
            .ToListAsync();
    }
}
