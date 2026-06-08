using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Urbanizze.Pages.Funcionarios;

public class DeleteModel : PageModel
{
    private readonly AppDbContext _context;

    public DeleteModel(AppDbContext context)
    {
        _context = context;
    }

    [BindProperty]
    public Funcionario Funcionario { get; set; } = null!;

    public async Task<IActionResult> OnGetAsync(int id)
    {
        var funcionario = await _context.Funcionarios
            .Include(f => f.Cidadao)
            .Include(f => f.Departamento)
            .FirstOrDefaultAsync(f => f.Id == id);

        if (funcionario == null)
            return NotFound();

        Funcionario = funcionario;
        return Page();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        var funcionario = await _context.Funcionarios.FindAsync(Funcionario.Id);
        if (funcionario != null)
        {
            _context.Funcionarios.Remove(funcionario);
            await _context.SaveChangesAsync();
        }

        return RedirectToPage("./Index");
    }
}
