using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Urbanizze.Pages.Departamentos;

public class DeleteModel : PageModel
{
    private readonly AppDbContext _context;

    public DeleteModel(AppDbContext context)
    {
        _context = context;
    }

    [BindProperty]
    public Departamento Departamento { get; set; } = null!;

    public async Task<IActionResult> OnGetAsync(int id)
    {
        var departamento = await _context.Departamentos
            .Include(d => d.PrefeituraCidade)
            .FirstOrDefaultAsync(d => d.Id == id);

        if (departamento == null)
            return NotFound();

        Departamento = departamento;
        return Page();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        var departamento = await _context.Departamentos.FindAsync(Departamento.Id);
        if (departamento != null)
        {
            _context.Departamentos.Remove(departamento);
            await _context.SaveChangesAsync();
        }

        return RedirectToPage("./Index");
    }
}
