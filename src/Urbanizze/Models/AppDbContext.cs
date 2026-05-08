using Microsoft.EntityFrameworkCore;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<PrefeituraCidade> PrefeiturasCidades { get; set; } = null!;
    public DbSet<Departamento> Departamentos { get; set; } = null!;
    public DbSet<Cidadao> Cidadaos { get; set; } = null!;
    public DbSet<Funcionario> Funcionarios { get; set; } = null!;
    public DbSet<Denuncia> Denuncias { get; set; } = null!;
    public DbSet<Mensagem> Mensagens { get; set; } = null!;
    public DbSet<Anexo> Anexos { get; set; } = null!;
    public DbSet<Notificacao> Notificacoes { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<PrefeituraCidade>()
            .HasMany(p => p.Departamentos)
            .WithOne(d => d.PrefeituraCidade)
            .HasForeignKey(d => d.PrefeituraCidadeId);

        modelBuilder.Entity<Departamento>()
            .HasMany(d => d.Funcionarios)
            .WithOne(f => f.Departamento)
            .HasForeignKey(f => f.DepartamentoId);

        modelBuilder.Entity<Cidadao>()
            .HasOne(c => c.Funcionario)
            .WithOne(f => f.Cidadao)
            .HasForeignKey<Funcionario>(f => f.CidadaoId);

        modelBuilder.Entity<Cidadao>()
            .HasMany(c => c.Denuncias)
            .WithOne(d => d.Cidadao)
            .HasForeignKey(d => d.CidadaoId);

        modelBuilder.Entity<Funcionario>()
            .HasMany(f => f.Denuncias)
            .WithOne(d => d.Funcionario)
            .HasForeignKey(d => d.FuncionarioId);

        modelBuilder.Entity<Departamento>()
            .HasMany(d => d.Denuncias)
            .WithOne(dn => dn.Departamento)
            .HasForeignKey(dn => dn.DepartamentoId);

        modelBuilder.Entity<Denuncia>()
            .HasMany(d => d.Mensagens)
            .WithOne(m => m.Denuncia)
            .HasForeignKey(m => m.DenunciaId);

        modelBuilder.Entity<Mensagem>()
            .HasMany(m => m.Anexos)
            .WithOne(a => a.Mensagem)
            .HasForeignKey(a => a.MensagemId);

        modelBuilder.Entity<Cidadao>()
            .HasMany(c => c.Mensagens)
            .WithOne(m => m.Cidadao)
            .HasForeignKey(m => m.CidadaoId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Funcionario>()
            .HasMany(f => f.Mensagens)
            .WithOne(m => m.Funcionario)
            .HasForeignKey(m => m.FuncionarioId);

        modelBuilder.Entity<Cidadao>()
            .HasMany(c => c.Notificacoes)
            .WithOne(n => n.Cidadao)
            .HasForeignKey(n => n.CidadaoId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Denuncia>()
            .HasMany(d => d.Notificacoes)
            .WithOne(n => n.Denuncia)
            .HasForeignKey(n => n.DenunciaId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}