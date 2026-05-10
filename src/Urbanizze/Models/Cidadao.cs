using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("CIDADAO")]
public class Cidadao
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Required]
    [Column("nome")]
    public string Nome { get; set; } = string.Empty;

    [Required]
    [Column("email")]
    public string Email { get; set; } = string.Empty;

    [Required]
    [Column("senha")]
    public string Senha { get; set; } = string.Empty;

    [Required]
    [Column("telefone")]
    public string Telefone { get; set; } = string.Empty;

    [Required]
    [Column("cpf")]
    public string Cpf { get; set; } = string.Empty;

    [Column("ativo")]
    public bool Ativo { get; set; } = true;

    [Column("criado_em")]
    public DateTime CriadoEm { get; set; } = DateTime.UtcNow;

    [Column("atualizado_em")]
    public DateTime AtualizadoEm { get; set; } = DateTime.UtcNow;

    public Funcionario? Funcionario { get; set; }

    public ICollection<Denuncia> Denuncias { get; set; } = new List<Denuncia>();

    public ICollection<Mensagem> Mensagens { get; set; } = new List<Mensagem>();

    public ICollection<Notificacao> Notificacoes { get; set; } = new List<Notificacao>();
}
