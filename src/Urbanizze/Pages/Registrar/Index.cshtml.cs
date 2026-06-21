using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

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

        [BindProperty]
        public string Perfil { get; set; } = "Cidadao";

        [BindProperty]
        public int? DepartamentoId { get; set; }

        public string Erro { get; set; } = "";

        public List<Departamento> DepartamentosDisponiveis { get; set; } = new();

        public async Task OnGetAsync()
        {
            DepartamentosDisponiveis = await _context.Departamentos
                .Include(d => d.PrefeituraCidade)
                .ToListAsync();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            try
            {
                DepartamentosDisponiveis = await _context.Departamentos
                    .Include(d => d.PrefeituraCidade)
                    .ToListAsync();

                if (Senha != ConfirmarSenha)
                {
                    Erro = "As senhas não conferem.";
                    return Page();
                }

                if (Perfil == "Funcionario" && (DepartamentoId == null || DepartamentoId == 0))
                {
                    Erro = "Selecione um departamento para cadastro como funcionário.";
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
                await _context.SaveChangesAsync();

                if (Perfil == "Funcionario" && DepartamentoId.HasValue)
                {
                    var funcionario = new Funcionario
                    {
                        CidadaoId = cidadao.Id,
                        DepartamentoId = DepartamentoId.Value
                    };

                    _context.Funcionarios.Add(funcionario);
                    await _context.SaveChangesAsync();
                }

                return RedirectToPage("/Login/Index");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                Erro = "Erro ao cadastrar. Tente novamente.";
                return Page();
            }
        }
    }
}