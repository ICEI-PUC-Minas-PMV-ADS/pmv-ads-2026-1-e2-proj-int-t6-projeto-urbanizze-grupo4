using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("ANEXO")]
public class Anexo
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("id_mensagem")]
    public int MensagemId { get; set; }

    [Required]
    [Column("nome_arquivo")]
    public string NomeArquivo { get; set; } = string.Empty;

    [Required]
    [Column("url")]
    public string Url { get; set; } = string.Empty;

    [Column("criado_em")]
    public DateTime CriadoEm { get; set; } = DateTime.UtcNow;

    public Mensagem Mensagem { get; set; } = null!;
}
