using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("DENUNCIA")]
public class Denuncia
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("id_cidadao")]
    public int CidadaoId { get; set; }

    [Column("id_departamento")]
    public int DepartamentoId { get; set; }

    [Column("id_funcionario")]
    public int? FuncionarioId { get; set; }

    [Column("id_status_denuncia")]
    public int StatusDenunciaId { get; set; }

    [Required]
    [Column("titulo")]
    public string Titulo { get; set; } = string.Empty;

    [Required]
    [Column("descricao")]
    public string Descricao { get; set; } = string.Empty;

    [Column("localizacao")]
    public string? Localizacao { get; set; }

    [Column("anonima")]
    public bool Anonima { get; set; } = false;

    [Column("criado_em")]
    public DateTime CriadoEm { get; set; } = DateTime.UtcNow;

    [Column("atualizado_em")]
    public DateTime AtualizadoEm { get; set; } = DateTime.UtcNow;

    public Cidadao Cidadao { get; set; } = null!;

    public Departamento Departamento { get; set; } = null!;

    public Funcionario? Funcionario { get; set; }

    public StatusDenuncia StatusDenuncia { get; set; } = StatusDenuncia.ABERTA;

    public ICollection<Mensagem> Mensagens { get; set; } = new List<Mensagem>();

    public ICollection<Notificacao> Notificacoes { get; set; } = new List<Notificacao>();
}


 public enum StatusDenuncia
{
    ABERTA = 1,
    EM_ANALISE = 2,
    CONCLUIDA = 3,
    INDEFERIDA = 4
}