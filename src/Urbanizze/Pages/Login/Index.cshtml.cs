using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Linq;

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

        public IActionResult OnPost()
        {
            var usuario = _context.Cidadaos
                .FirstOrDefault(x =>
                    x.Email == Email &&
                    x.Senha == Senha);

            if (usuario == null)
            {
                ErroLogin = "Email ou senha inválidos.";
                return Page();
            }

            return RedirectToPage("/Index");
        }
    }
}