using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Urbanizze.Pages.Denuncias;

public class IndexModel : PageModel
{
    private readonly AppDbContext _context;

    public IndexModel(AppDbContext context)
    {
        _context = context;
    }

    public IList<Denuncia> Denuncias { get; set; } = new List<Denuncia>();

    public async Task OnGetAsync()
    {
        Denuncias = await _context.Denuncias
            .Include(d => d.Cidadao)
            .Include(d => d.Departamento)
            .Include(d => d.Funcionario)
            .ToListAsync();
    }
}