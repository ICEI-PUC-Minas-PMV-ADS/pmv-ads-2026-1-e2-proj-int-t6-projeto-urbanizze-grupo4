using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Urbanizze.Pages.PrefeiturasCidades;

public class CreateModel : PageModel
{
    private readonly AppDbContext _context;

    public CreateModel(AppDbContext context)
    {
        _context = context;
    }

    [BindProperty]
    public PrefeituraCidade Prefeitura { get; set; } = new();

    public void OnGet() { }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
            return Page();

        _context.PrefeiturasCidades.Add(Prefeitura);
        await _context.SaveChangesAsync();

        return RedirectToPage("./Index");
    }
}
