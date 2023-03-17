namespace EstacionamientoAPI.Data
{
    public interface IEstacionamientoRepository
    {
        void AgregarVehiculo(Vehiculo vehiculo);
        Vehiculo ObtenerVehiculoPorPlaca(string placa);
        List<Vehiculo> ObtenerVehiculos();
        void AgregarEstancia(Estancia estancia);
        List<Estancia> ObtenerEstancias();
        void LimpiarEstancias();
    }
}
