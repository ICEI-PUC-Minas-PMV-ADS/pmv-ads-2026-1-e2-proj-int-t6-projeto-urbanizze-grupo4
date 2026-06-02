using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Urbanizze.Pages.Usuarios;

public class IndexModel : PageModel
{
    // _context é nossa conexão com o banco de dados
    private readonly AppDbContext _context;

    // O ASP.NET injeta o contexto automaticamente aqui
    public IndexModel(AppDbContext context)
    {
        _context = context;
    }
    // Lista que vai guardar os funcionários buscados do banco
    public IList<Funcionario> Funcionarios { get; set; } = new List<Funcionario>();
    // OnGetAsync é chamado automaticamente quando a página é acessada
    public async Task OnGetAsync()
    {
        Funcionarios = await _context.Funcionarios
            .Include(f => f.Cidadao)       // traz os dados do Cidadao junto
            .Include(f => f.Departamento)  // traz os dados do Departamento junto
            .ToListAsync();
    }
}