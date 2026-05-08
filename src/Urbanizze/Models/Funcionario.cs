using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("FUNCIONARIO")]
public class Funcionario
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Required]
    [Column("id_cidadao")]
    public int CidadaoId { get; set; }

    [Column("id_departamento")]
    public int DepartamentoId { get; set; }

    [Column("criado_em")]
    public DateTime CriadoEm { get; set; } = DateTime.UtcNow;

    [Column("atualizado_em")]
    public DateTime AtualizadoEm { get; set; } = DateTime.UtcNow;

    public Cidadao Cidadao { get; set; } = null!;

    public Departamento Departamento { get; set; } = null!;

    public ICollection<Denuncia> Denuncias { get; set; } = new List<Denuncia>();

    public ICollection<Mensagem> Mensagens { get; set; } = new List<Mensagem>();
}
