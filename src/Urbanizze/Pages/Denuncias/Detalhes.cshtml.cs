using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Urbanizze.Pages.Denuncias;

public class DetalhesModel : PageModel
{
    private readonly AppDbContext _context;

    public DetalhesModel(AppDbContext context)
    {
        _context = context;
    }

    public Denuncia Denuncia { get; set; } = null!;
    public IList<Mensagem> Mensagens { get; set; } = new List<Mensagem>();

    [BindProperty]
    public string NovaMsg { get; set; } = string.Empty;

    public async Task<IActionResult> OnGetAsync(int id)
    {
        var denuncia = await _context.Denuncias
            .Include(d => d.Cidadao)
            .Include(d => d.Departamento)
            .Include(d => d.Funcionario)
            .FirstOrDefaultAsync(d => d.Id == id);

        if (denuncia == null) return NotFound();

        Denuncia = denuncia;

        Mensagens = await _context.Mensagens
            .Include(m => m.Cidadao)
            .Include(m => m.Funcionario)
            .Where(m => m.DenunciaId == id)
            .OrderBy(m => m.CriadoEm)
            .ToListAsync();

        return Page();
    }

    public async Task<IActionResult> OnPostAsync(int id)
    {
        if (string.IsNullOrWhiteSpace(NovaMsg))
            return RedirectToPage(new { id });

        var mensagem = new Mensagem
        {
            DenunciaId = id,
            FuncionarioId = 1,
            Texto = NovaMsg,
            CriadoEm = DateTime.UtcNow
        };

        _context.Mensagens.Add(mensagem);
        await _context.SaveChangesAsync();

        return RedirectToPage(new { id });
    }
}