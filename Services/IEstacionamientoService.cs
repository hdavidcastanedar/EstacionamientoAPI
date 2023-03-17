public interface IEstacionamientoService
{
    void RegistrarEntrada(string placa);
    decimal? RegistrarSalida(string placa);
    void AltaVehiculoOficial(string placa);
    void AltaVehiculoResidente(string placa);
    void ComienzaMes();
    List<ResidentePago> GenerarInformePagosResidentes();
}
