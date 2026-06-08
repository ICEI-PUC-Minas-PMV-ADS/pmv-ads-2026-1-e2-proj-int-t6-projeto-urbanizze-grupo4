using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Urbanizze.Pages.Departamentos;

public class CreateModel : PageModel
{
    private readonly AppDbContext _context;

    public CreateModel(AppDbContext context)
    {
        _context = context;
    }

    [BindProperty]
    public Departamento Departamento { get; set; } = new();

    public SelectList Prefeituras { get; set; } = null!;

    public async Task OnGetAsync()
    {
        Prefeituras = new SelectList(
            await _context.PrefeiturasCidades.ToListAsync(),
            nameof(PrefeituraCidade.Id),
            nameof(PrefeituraCidade.Nome));
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

        _context.Departamentos.Add(Departamento);
        await _context.SaveChangesAsync();

        return RedirectToPage("./Index");
    }
}
