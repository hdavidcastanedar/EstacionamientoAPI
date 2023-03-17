public class ResidentePago
{
    public Vehiculo Vehiculo { get; set; }
    public double TiempoEstacionado { get; set; }
    public double MontoAPagar { get; set; }

    public ResidentePago(Vehiculo vehiculo, double tiempoEstacionado, double montoAPagar)
    {
        Vehiculo = vehiculo;
        TiempoEstacionado = tiempoEstacionado;
        MontoAPagar = montoAPagar;
    }
}
