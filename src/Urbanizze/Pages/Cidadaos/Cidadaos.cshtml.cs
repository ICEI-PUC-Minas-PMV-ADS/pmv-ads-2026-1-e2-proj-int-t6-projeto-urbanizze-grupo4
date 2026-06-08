using Microsoft.AspNetCore.Mvc.RazorPages;
 
namespace Urbanizze.Pages.Cidadaos
{
    public class IndexModel : PageModel
    {
        // TODO: injetar o service/repository via construtor
        // private readonly ICidadaoService _service;
        // public IndexModel(ICidadaoService service) => _service = service;
 
        // TODO: substituir por lista real vinda do banco
        // public IEnumerable<Cidadao> Cidadaos { get; set; }
 
        public void OnGet()
        {
            // TODO: carregar dados
            // Cidadaos = _service.ListarTodos();
        }
    }
}