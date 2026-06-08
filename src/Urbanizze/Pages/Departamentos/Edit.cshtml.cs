using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Urbanizze.Pages.Departamentos;

public class EditModel : PageModel
{
    private readonly AppDbContext _context;

    public EditModel(AppDbContext context)
    {
        _context = context;
    }

    [BindProperty]
    public Departamento Departamento { get; set; } = null!;

    public SelectList Prefeituras { get; set; } = null!;

    public async Task<IActionResult> OnGetAsync(int id)
    {
        var departamento = await _context.Departamentos.FindAsync(id);
        if (departamento == null)
            return NotFound();

        Departamento = departamento;
        Prefeituras = new SelectList(
            await _context.PrefeiturasCidades.ToListAsync(),
            nameof(PrefeituraCidade.Id),
            nameof(PrefeituraCidade.Nome));

        return Page();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            Prefeituras = new SelectList(
                await _context.PrefeiturasCidades.ToListAsync(),
                nameof(PrefeituraCidade.Id),
                nameof(PrefeituraCidade.Nome));
            return Page();
        }

        Departamento.AtualizadoEm = DateTime.UtcNow;
        _context.Attach(Departamento).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!await _context.Departamentos.AnyAsync(d => d.Id == Departamento.Id))
                return NotFound();
            throw;
        }

        return RedirectToPage("./Index");
    }
}
