using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Urbanizze.Pages.Registrar
{
    public class IndexModel : PageModel
    {
        private readonly AppDbContext _context;

        public IndexModel(AppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public string Nome { get; set; } = "";

        [BindProperty]
        public string Cpf { get; set; } = "";

        [BindProperty]
        public string Telefone { get; set; } = "";

        [BindProperty]
        public string Email { get; set; } = "";

        [BindProperty]
        public string Senha { get; set; } = "";

        [BindProperty]
        public string ConfirmarSenha { get; set; } = "";

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            try
            {
                Console.WriteLine("ENTROU NO ONPOST");

                if (Senha != ConfirmarSenha)
                {
                    Console.WriteLine("SENHAS DIFERENTES");
                    return Page();
                }

                var cidadao = new Cidadao
                {
                    Nome = Nome,
                    Cpf = Cpf,
                    Telefone = Telefone,
                    Email = Email,
                    Senha = Senha,
                    Ativo = true
                };

                _context.Cidadaos.Add(cidadao);
                _context.SaveChanges();

                Console.WriteLine("SALVO COM SUCESSO");

                return RedirectToPage("/Login/Index");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return Page();
            }
        }
    }
}