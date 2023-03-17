using Microsoft.EntityFrameworkCore;

namespace EstacionamientoAPI.Data
{
    public class EstacionamientoContext : DbContext
    {
        public DbSet<Vehiculo> Vehiculos { get; set; }
        public DbSet<Estancia> Estancias { get; set; }

        public EstacionamientoContext(DbContextOptions<EstacionamientoContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Vehiculo>()
              .HasKey(v => v.Placa);

            modelBuilder.Entity<Estancia>()
                .HasKey(e => e.Id);

            modelBuilder.Entity<Estancia>()
                .HasOne(e => e.Vehiculo)
                .WithMany()
                .HasForeignKey(e => e.Placa);

            // Seed data
            modelBuilder.Entity<Vehiculo>().HasData(
                new Vehiculo { Placa = "ABC-12345", Tipo = TipoVehiculo.Oficial },
                new Vehiculo { Placa = "DEF-23456", Tipo = TipoVehiculo.Residente },
                new Vehiculo { Placa = "GHI-34567", Tipo = TipoVehiculo.NoResidente },
                new Vehiculo { Placa = "JKL-45678", Tipo = TipoVehiculo.Residente },
                new Vehiculo { Placa = "MNO-56789", Tipo = TipoVehiculo.NoResidente }
            );

            modelBuilder.Entity<Estancia>().HasData(
            new Estancia { Id = 1, HoraEntrada = new DateTime(2023, 3, 1, 8, 0, 0), HoraSalida = new DateTime(2023, 3, 1, 10, 0, 0), Placa = "ABC-12345" },
            new Estancia { Id = 2, HoraEntrada = new DateTime(2023, 3, 1, 9, 0, 0), HoraSalida = new DateTime(2023, 3, 1, 11, 0, 0), Placa = "DEF-23456" },
            new Estancia { Id = 3, HoraEntrada = new DateTime(2023, 3, 1, 10, 0, 0), HoraSalida = new DateTime(2023, 3, 1, 12, 0, 0), Placa = "GHI-34567" },
            new Estancia { Id = 4, HoraEntrada = new DateTime(2023, 3, 1, 11, 0, 0), HoraSalida = new DateTime(2023, 3, 1, 13, 0, 0), Placa = "JKL-45678" },
            new Estancia { Id = 5, HoraEntrada = new DateTime(2023, 3, 1, 12, 0, 0), HoraSalida = new DateTime(2023, 3, 1, 14, 0, 0), Placa = "MNO-56789" }
             );

        }
    }
}
