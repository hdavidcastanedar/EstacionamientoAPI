using EstacionamientoAPI.Data;

public class EstacionamientoService : IEstacionamientoService
{
    private readonly IEstacionamientoRepository _estacionamientoRepository;

    public EstacionamientoService(IEstacionamientoRepository estacionamientoRepository)
    {
        _estacionamientoRepository = estacionamientoRepository;
    }

    public void RegistrarEntrada(string placa)
    {
        var vehiculo = _estacionamientoRepository.ObtenerVehiculoPorPlaca(placa);
        if (vehiculo == null)
            throw new Exception("Vehículo no encontrado.");

        var estancia = new Estancia(DateTime.Now, DateTime.MinValue,placa, vehiculo);
        _estacionamientoRepository.AgregarEstancia(estancia);
    }

    public decimal? RegistrarSalida(string placa)
    {
        var vehiculo = _estacionamientoRepository.ObtenerVehiculoPorPlaca(placa);
        if (vehiculo == null)
            throw new Exception("Vehículo no encontrado.");

        var estancia = _estacionamientoRepository.ObtenerEstancias().FirstOrDefault(e => e.Vehiculo.Placa == placa && e.HoraSalida == DateTime.MinValue);
        if (estancia == null)
            throw new Exception("Estancia no encontrada.");

        estancia.HoraSalida = DateTime.Now;
        _estacionamientoRepository.AgregarEstancia(estancia);

        if (vehiculo.Tipo == TipoVehiculo.Oficial)
            return null;

        decimal tarifa = vehiculo.Tipo == TipoVehiculo.Residente ? 0.05m : 0.5m;
        int duracion = (int)Math.Ceiling((estancia.HoraSalida - estancia.HoraEntrada).TotalMinutes);
        return duracion * tarifa;
    }

    public void AltaVehiculoOficial(string placa)
    {
        var vehiculo = new Vehiculo(placa, TipoVehiculo.Oficial);
        _estacionamientoRepository.AgregarVehiculo(vehiculo);
    }

    public void AltaVehiculoResidente(string placa)
    {
        var vehiculo = new Vehiculo(placa, TipoVehiculo.Residente);
        _estacionamientoRepository.AgregarVehiculo(vehiculo);
    }

    public void ComienzaMes()
    {
        _estacionamientoRepository.LimpiarEstancias();
    }

    public List<ResidentePago> GenerarInformePagosResidentes()
    {
        var residentes = _estacionamientoRepository.ObtenerVehiculos().Where(v => v.Tipo == TipoVehiculo.Residente).ToList();
        var estancias = _estacionamientoRepository.ObtenerEstancias().Where(e => e.HoraSalida != DateTime.MinValue).ToList();

        var pagosResidentes = new List<ResidentePago>();

        foreach (var residente in residentes)
        {
            var estanciasResidente = estancias.Where(e => e.Vehiculo.Placa == residente.Placa).ToList();
            double minutosTotales = estanciasResidente.Sum(e => Math.Ceiling((e.HoraSalida - e.HoraEntrada).TotalMinutes));
            double totalPago = minutosTotales * 0.05;

            pagosResidentes.Add(new ResidentePago(residente, minutosTotales, totalPago));
        }

        return pagosResidentes;
    }

}
