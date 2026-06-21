using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Linq;

namespace Urbanizze.Pages.RecuperarSenha
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
        public string NovaSenha { get; set; } = "";

        [BindProperty]
        public string ConfirmarSenha { get; set; } = "";

        public string Erro { get; set; } = "";
        public string Mensagem { get; set; } = "";

        public IActionResult OnPost()
        {
            if (NovaSenha != ConfirmarSenha)
            {
                Erro = "As senhas não conferem.";
                return Page();
            }

            var usuario = _context.Cidadaos
                .FirstOrDefault(x => x.Email == Email);

            if (usuario == null)
            {
                Erro = "E-mail não encontrado.";
                return Page();
            }

            usuario.Senha = NovaSenha;
            _context.SaveChanges();

            Mensagem = "Senha alterada com sucesso!";
            return Page();
        }
    }
}