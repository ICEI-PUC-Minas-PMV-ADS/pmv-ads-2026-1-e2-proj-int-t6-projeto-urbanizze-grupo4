using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Urbanizze.Pages.Funcionarios;

public class EditModel : PageModel
{
    private readonly AppDbContext _context;

    public EditModel(AppDbContext context)
    {
        _context = context;
    }

    [BindProperty]
    public Funcionario Funcionario { get; set; } = null!;

    public string NomeCidadao { get; set; } = "";
    public SelectList Departamentos { get; set; } = null!;

    public async Task<IActionResult> OnGetAsync(int id)
    {
        var funcionario = await _context.Funcionarios
            .Include(f => f.Cidadao)
            .FirstOrDefaultAsync(f => f.Id == id);

        if (funcionario == null)
            return NotFound();

        Funcionario = funcionario;
        NomeCidadao = funcionario.Cidadao.Nome;
        Departamentos = new SelectList(
            await _context.Departamentos.ToListAsync(),
            nameof(Departamento.Id),
            nameof(Departamento.Nome));

        return Page();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            var cidadao = await _context.Cidadaos.FindAsync(Funcionario.CidadaoId);
            NomeCidadao = cidadao?.Nome ?? "";
            Departamentos = new SelectList(
                await _context.Departamentos.ToListAsync(),
                nameof(Departamento.Id),
                nameof(Departamento.Nome));
            return Page();
        }

        Funcionario.AtualizadoEm = DateTime.UtcNow;
        _context.Attach(Funcionario).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!await _context.Funcionarios.AnyAsync(f => f.Id == Funcionario.Id))
                return NotFound();
            throw;
        }

        return RedirectToPage("./Index");
    }
}
