using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("DEPARTAMENTO")]
public class Departamento
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("id_prefeitura_cidade")]
    public int PrefeituraCidadeId { get; set; }

    [Required]
    [Column("nome")]
    public string Nome { get; set; } = string.Empty;

    [Required]
    [Column("descricao")]
    public string Descricao { get; set; } = string.Empty;

    [Column("criado_em")]
    public DateTime CriadoEm { get; set; }  = DateTime.UtcNow;

    [Column("atualizado_em")]
    public DateTime AtualizadoEm { get; set; } = DateTime.UtcNow;

    public PrefeituraCidade PrefeituraCidade { get; set; } = null!;

    public ICollection<Funcionario> Funcionarios { get; set; } = new List<Funcionario>();

    public ICollection<Denuncia> Denuncias { get; set; } = new List<Denuncia>();
}
