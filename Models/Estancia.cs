public class Estancia
{
    public int Id { get; set; }
    public DateTime HoraEntrada { get; set; }
    public DateTime HoraSalida { get; set; }
    public string Placa { get; set; }
    public Vehiculo Vehiculo { get; set; }

    public Estancia()
    {
        
    }

    public Estancia(DateTime horaEntrada, DateTime horaSalida, string placa, Vehiculo vehiculo)
    {
        HoraEntrada = horaEntrada;
        HoraSalida = horaSalida;        
        Placa = placa;
        Vehiculo = vehiculo;
    }

    public double DuracionEnMinutos()
    {
        return (HoraSalida - HoraEntrada).TotalMinutes;
    }
}