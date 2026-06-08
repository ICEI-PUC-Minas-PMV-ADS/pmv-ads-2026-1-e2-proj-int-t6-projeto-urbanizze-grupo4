using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Urbanizze.Pages.Funcionarios;

public class CreateModel : PageModel
{
    private readonly AppDbContext _context;

    public CreateModel(AppDbContext context)
    {
        _context = context;
    }

    [BindProperty]
    public Funcionario Funcionario { get; set; } = new();

    public SelectList Cidadaos { get; set; } = null!;
    public SelectList Departamentos { get; set; } = null!;

    public async Task OnGetAsync()
    {
        await CarregarSelectLists();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            await CarregarSelectLists();
            return Page();
        }

        _context.Funcionarios.Add(Funcionario);
        await _context.SaveChangesAsync();

        return RedirectToPage("./Index");
    }

    private async Task CarregarSelectLists()
    {
        // Só mostra cidadãos que ainda NÃO são funcionários
        var cidadaosDisponiveis = await _context.Cidadaos
            .Where(c => !_context.Funcionarios.Any(f => f.CidadaoId == c.Id))
            .ToListAsync();

        Cidadaos = new SelectList(cidadaosDisponiveis,
            nameof(Cidadao.Id),
            nameof(Cidadao.Nome));

        Departamentos = new SelectList(
            await _context.Departamentos
                .Include(d => d.PrefeituraCidade)
                .ToListAsync(),
            nameof(Departamento.Id),
            nameof(Departamento.Nome));
    }
}
