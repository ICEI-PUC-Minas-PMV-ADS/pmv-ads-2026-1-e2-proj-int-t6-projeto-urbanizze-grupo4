using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Urbanizze.Pages.PrefeiturasCidades;

public class EditModel : PageModel
{
    private readonly AppDbContext _context;

    public EditModel(AppDbContext context)
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
        if (!ModelState.IsValid)
            return Page();

        _context.Attach(Prefeitura).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!await _context.PrefeiturasCidades.AnyAsync(p => p.Id == Prefeitura.Id))
                return NotFound();
            throw;
        }

        return RedirectToPage("./Index");
    }
}
