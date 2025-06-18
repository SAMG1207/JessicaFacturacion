using JessicaFacturacion.Models;
using Microsoft.EntityFrameworkCore;

namespace JessicaFacturacion.Data
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Paciente> Pacientes { get; set; }
        public DbSet<Cita> Citas { get; set; }
        public DbSet<Pago> Pagos { get; set; }
        public DbSet<TipoServicio> TipoServicios { get; set; }
        public DbSet<TipoFacturacion> TipoFacturaciones { get; set; }

        public DbSet<Jessica> jessicas { get; set; }

        public DbSet<LoggerPersonalizado> logger { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Estrategia TPC para herencia
            modelBuilder.Entity<Cliente>().UseTpcMappingStrategy();
            modelBuilder.Entity<Paciente>().UseTpcMappingStrategy();

            modelBuilder.Entity<Cliente>().ToTable("Clientes");
            modelBuilder.Entity<Paciente>().ToTable("Pacientes");

            // Cliente -> TipoFacturacion (uno a muchos)
            modelBuilder.Entity<Cliente>()
                .HasOne(c => c.TipoFacturacion)
                .WithMany(tf => tf.Clientes)
                .HasForeignKey(c => c.TipoFacturacionId)
                .OnDelete(DeleteBehavior.Restrict);

            // Cliente -> Paciente (uno a muchos)
            modelBuilder.Entity<Paciente>()
                .HasOne(p => p.Cliente)
                .WithMany(c => c.Pacientes)
                .HasForeignKey(p => p.ClienteId)
                .OnDelete(DeleteBehavior.Restrict);

            // Cliente -> TipoServicio (uno a muchos)
            modelBuilder.Entity<TipoServicio>()
                .HasOne(ts => ts.Cliente)
                .WithMany(c => c.TipoServicio) // Nota: asegurarse que propiedad en Cliente se llama "TipoServicios"
                .HasForeignKey(ts => ts.ClienteId)
                .OnDelete(DeleteBehavior.Restrict);

            // Pago -> TipoServicio (muchos a uno)
            modelBuilder.Entity<Pago>()
                .HasOne(p => p.TipoServicio)
                .WithMany()
                .HasForeignKey(p => p.TipoServicioId)
                .OnDelete(DeleteBehavior.Restrict);

            // Pago -> Cliente (muchos a uno)
            modelBuilder.Entity<Pago>()
                .HasOne<Cliente>() // Sin propiedad de navegación inversa
                .WithMany()
                .HasForeignKey(p => p.TipoServicioId)
                .OnDelete(DeleteBehavior.Restrict);

            // Cita -> TipoServicio (muchos a uno)
            modelBuilder.Entity<Cita>()
                .HasOne(c => c.TipoServicio)
                .WithMany()
                .HasForeignKey(c => c.TipoServicioId)
                .OnDelete(DeleteBehavior.Restrict);

            // Cita -> Pago (uno a uno opcional)
            modelBuilder.Entity<Cita>()
                .HasOne(c => c.Pago)
                .WithOne()
                .HasForeignKey<Cita>(c => c.PagoId)
                .OnDelete(DeleteBehavior.Restrict);

            // Cita -> Paciente (muchos a uno)
            modelBuilder.Entity<Cita>()
                .HasOne(c => c.Paciente)
                .WithMany(p => p.Cita)
                .HasForeignKey(c => c.PacienteId)
                .OnDelete(DeleteBehavior.Restrict);


            modelBuilder.Entity<Jessica>(entity =>
            {
                entity.HasKey(j => j.Id);
                entity.Property(j => j.Id).ValueGeneratedNever();
            });
        }
    }
}
