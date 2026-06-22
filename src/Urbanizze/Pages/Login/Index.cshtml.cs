using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Urbanizze.Pages.Login
{
    public class IndexModel : PageModel
    {
        private readonly AppDbContext _context;

        public IndexModel(AppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public string Email { get; set; } = "";

        [BindProperty]
        public string Senha { get; set; } = "";

        public string ErroLogin { get; set; } = "";

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var cidadao = await _context.Cidadaos
                .FirstOrDefaultAsync(x => x.Email == Email && x.Senha == Senha);

            if (cidadao == null)
            {
                ErroLogin = "Email ou senha inválidos.";
                return Page();
            }

            var funcionario = await _context.Funcionarios
                .FirstOrDefaultAsync(f => f.CidadaoId == cidadao.Id);

            HttpContext.Session.SetInt32("UsuarioId", cidadao.Id);
            HttpContext.Session.SetString("UsuarioNome", cidadao.Nome);
            HttpContext.Session.SetString("UsuarioEmail", cidadao.Email);

            if (funcionario != null)
            {
                HttpContext.Session.SetString("UsuarioPerfil", "Funcionario");
                HttpContext.Session.SetInt32("FuncionarioId", funcionario.Id);
                return RedirectToPage("/Funcionarios/Index");
            }
            else
            {
                HttpContext.Session.SetString("UsuarioPerfil", "Cidadao");
                return Redirect("/Denuncias");
            }
        }
    }
}