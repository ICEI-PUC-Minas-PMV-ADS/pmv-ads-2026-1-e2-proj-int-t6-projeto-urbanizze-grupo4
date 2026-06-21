using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("api/funcionarios")]
public class FuncionariosApiController : ControllerBase
{
    private readonly AppDbContext _context;

    public FuncionariosApiController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll(
        [FromQuery] string? busca,
        [FromQuery] string? cargo,
        [FromQuery] string? status)
    {
        var query = _context.Funcionarios
            .Include(f => f.Cidadao)
            .Include(f => f.Departamento)
            .AsQueryable();

        if (!string.IsNullOrEmpty(busca))
            query = query.Where(f =>
                f.Cidadao.Nome.Contains(busca) ||
                f.Departamento.Nome.Contains(busca));

        if (!string.IsNullOrEmpty(cargo))
            query = query.Where(f => f.Departamento.Nome.Contains(cargo));

        var resultado = await query
            .Select(f => new
            {
                id           = f.Id,
                nome         = f.Cidadao.Nome,
                email        = f.Cidadao.Email,
                cargo        = f.Departamento.Nome,
                departamento = f.Departamento.Nome,
                ocorrencias  = _context.Denuncias
                                   .Count(d => d.DepartamentoId == f.DepartamentoId),
                status       = "ativo" // ↓ ajuste quando tiver campo de status no model
            })
            .ToListAsync();

        return Ok(resultado);
    }
}