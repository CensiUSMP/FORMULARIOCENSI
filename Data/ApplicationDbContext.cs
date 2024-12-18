using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FORMULARIOCENSI.Data;

public class ApplicationDbContext : IdentityDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<FORMULARIOCENSI.Models.Formulario> DataFormulario { get; set; }
    public DbSet<FORMULARIOCENSI.Models.Estados> DataEstados { get; set; }
    public DbSet<FORMULARIOCENSI.Models.Estadosa> DataEstadosa { get; set; }
    public DbSet<FORMULARIOCENSI.Models.Dialogo> DataDialogo { get; set; }
    public DbSet<FORMULARIOCENSI.Models.Status> DataStatus { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder); // Llamar al método base primero

        // Configuración para la relación Prueba-Estados
        modelBuilder.Entity<FORMULARIOCENSI.Models.Formulario>()
            .HasMany(p => p.Estados)
            .WithOne(e => e.Formulario)
            .HasForeignKey(e => e.FormularioId)
            .OnDelete(DeleteBehavior.Cascade);

        // Configuración para la relación Prueba-Estadosa
        modelBuilder.Entity<FORMULARIOCENSI.Models.Formulario>()
            .HasMany(p => p.Estadosa)
            .WithOne(e => e.Formulario)
            .HasForeignKey(e => e.FormularioId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<FORMULARIOCENSI.Models.Formulario>()
        .HasMany(p => p.Dialogo)
        .WithOne(e => e.Formulario)
        .HasForeignKey(e => e.FormularioId)
        .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<FORMULARIOCENSI.Models.Formulario>()
        .HasMany(p => p.Status)
        .WithOne(e => e.Formulario)
        .HasForeignKey(e => e.FormularioId)
        .OnDelete(DeleteBehavior.Cascade);
    }
    
}
