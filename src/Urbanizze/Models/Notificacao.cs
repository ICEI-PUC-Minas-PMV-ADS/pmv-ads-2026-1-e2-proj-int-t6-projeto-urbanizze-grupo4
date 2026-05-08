using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("NOTIFICACAO")]
public class Notificacao
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("id_cidadao")]
    public int CidadaoId { get; set; }

    [Column("id_denuncia")]
    public int? DenunciaId { get; set; }

    [Required]
    [Column("mensagem")]
    public string Texto { get; set; } = string.Empty;

    [Column("lida")]
    public bool Lida { get; set; }

    [Column("criado_em")]
    public DateTime CriadoEm { get; set; } = DateTime.UtcNow;

    public Cidadao Cidadao { get; set; } = null!;

    public Denuncia? Denuncia { get; set; }
}
