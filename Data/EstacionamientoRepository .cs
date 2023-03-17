using Microsoft.EntityFrameworkCore;

namespace EstacionamientoAPI.Data
{
    public class EstacionamientoRepository : IEstacionamientoRepository
    {
        private readonly EstacionamientoContext _context;

        public EstacionamientoRepository(EstacionamientoContext context)
        {
            _context = context;
        }

        public void AgregarVehiculo(Vehiculo vehiculo)
        {
            _context.Vehiculos.Add(vehiculo);
            _context.SaveChanges();
        }

        public Vehiculo ObtenerVehiculoPorPlaca(string placa)
        {
            return _context.Vehiculos.First(v => v.Placa == placa);
        }

        public List<Vehiculo> ObtenerVehiculos()
        {
            return _context.Vehiculos.ToList();
        }

        public void AgregarEstancia(Estancia estancia)
        {
            var nuevaEstancia = new Estancia
            {
                HoraEntrada = estancia.HoraEntrada,
                HoraSalida = estancia.HoraSalida,
                Placa = estancia.Placa,
                Vehiculo = estancia.Vehiculo
            };
            _context.Estancias.Add(nuevaEstancia);
            _context.SaveChanges();
        }

        public List<Estancia> ObtenerEstancias()
        {
            return _context.Estancias.Include(e => e.Vehiculo).ToList();
        }

        public void LimpiarEstancias()
        {
            _context.Estancias.RemoveRange(_context.Estancias);
            _context.SaveChanges();
        }
    }
}
