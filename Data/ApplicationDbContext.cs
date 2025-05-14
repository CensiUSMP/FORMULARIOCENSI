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
    public DbSet<FORMULARIOCENSI.Models.Ambiente> DataAmbiente { get; set; }
    public DbSet<FORMULARIOCENSI.Models.AmbienteA> DataAmbienteA { get; set; }
    public DbSet<FORMULARIOCENSI.Models.Especifico> DataEspecifico { get; set; }
    public DbSet<FORMULARIOCENSI.Models.Global> DataGlobal { get; set; }
    public DbSet<FORMULARIOCENSI.Models.Principal> DataPrincipal { get; set; }
    public DbSet<FORMULARIOCENSI.Models.RespAcademico> DataRespAcademico { get; set; }
    public DbSet<FORMULARIOCENSI.Models.RespOperador> DataRespOperador { get; set; }
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

        modelBuilder.Entity<FORMULARIOCENSI.Models.Principal>()
                .HasOne(p => p.Global)
                .WithMany()
                .HasForeignKey(p => p.GlobalId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<FORMULARIOCENSI.Models.Principal>()
                .HasOne(p => p.Especifico)
                .WithMany()
                .HasForeignKey(p => p.EspecificoId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<FORMULARIOCENSI.Models.Principal>()
                .HasOne(p => p.RespAcademico)
                .WithMany()
                .HasForeignKey(p => p.RespAcademicoId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<FORMULARIOCENSI.Models.Principal>()
                .HasOne(p => p.RespOperador)
                .WithMany()
                .HasForeignKey(p => p.RespOperadorId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<FORMULARIOCENSI.Models.AmbienteA>()
                .HasOne(a => a.Ambiente)
                .WithMany() // Si un ambiente se puede usar en muchos horarios (AmbienteA)
                .HasForeignKey(a => a.AmbienteId)
                .OnDelete(DeleteBehavior.Restrict); // Para evitar que se borren los horarios si se borra un ambiente


            modelBuilder.Entity<FORMULARIOCENSI.Models.Principal>()
            .HasMany(p => p.AmbienteA)
            .WithOne(e => e.Principal)
            .HasForeignKey(e => e.PrincipalId)
            .OnDelete(DeleteBehavior.Cascade);
    }
    
}
