using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("PREFEITURA_CIDADE")]
public class PrefeituraCidade
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Required]
    [Column("nome")]
    public string Nome { get; set; } = string.Empty;

    [Required]
    [Column("uf")]
    public string Uf { get; set; } = string.Empty;

    public ICollection<Departamento> Departamentos { get; set; } = new List<Departamento>();
}
