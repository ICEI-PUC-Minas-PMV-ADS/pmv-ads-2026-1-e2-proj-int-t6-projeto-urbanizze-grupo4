using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("MENSAGEM")]
public class Mensagem
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("id_denuncia")]
    public int DenunciaId { get; set; }

    [Column("id_cidadao")]
    public int? CidadaoId { get; set; }

    [Column("id_funcionario")]
    public int? FuncionarioId { get; set; }

    [Required]
    [Column("mensagem")]
    public string Texto { get; set; } = string.Empty;

    [Column("criado_em")]
    public DateTime CriadoEm { get; set; }  = DateTime.UtcNow;

    public Denuncia Denuncia { get; set; } = null!;

    public Cidadao? Cidadao { get; set; }

    public Funcionario? Funcionario { get; set; }

    public ICollection<Anexo> Anexos { get; set; } = new List<Anexo>();
}
