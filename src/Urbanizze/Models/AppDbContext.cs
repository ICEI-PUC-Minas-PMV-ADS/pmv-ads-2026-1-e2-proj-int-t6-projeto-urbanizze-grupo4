// Data/AppDbContext.cs
using Microsoft.EntityFrameworkCore;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    /* public DbSet<Usuario> Usuarios { get; set; } */

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Configurações extras (opcional)
        /* modelBuilder.Entity<Usuario>()
            .HasIndex(u => u.Email)
            .IsUnique(); */
    }
}