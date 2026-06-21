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

    public async Task OnGetAsync()
    {
        Cidadaos = await _context.Cidadaos.ToListAsync();
    }
}
