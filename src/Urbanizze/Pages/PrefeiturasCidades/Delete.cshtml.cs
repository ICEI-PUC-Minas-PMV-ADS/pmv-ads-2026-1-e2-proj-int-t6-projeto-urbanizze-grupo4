using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Urbanizze.Pages.PrefeiturasCidades;

public class DeleteModel : PageModel
{
    private readonly AppDbContext _context;

    public DeleteModel(AppDbContext context)
    {
        _context = context;
    }

    [BindProperty]
    public PrefeituraCidade Prefeitura { get; set; } = null!;

    public async Task<IActionResult> OnGetAsync(int id)
    {
        var prefeitura = await _context.PrefeiturasCidades.FindAsync(id);
        if (prefeitura == null)
            return NotFound();

        Prefeitura = prefeitura;
        return Page();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        var prefeitura = await _context.PrefeiturasCidades.FindAsync(Prefeitura.Id);
        if (prefeitura != null)
        {
            _context.PrefeiturasCidades.Remove(prefeitura);
            await _context.SaveChangesAsync();
        }

        return RedirectToPage("./Index");
    }
}
