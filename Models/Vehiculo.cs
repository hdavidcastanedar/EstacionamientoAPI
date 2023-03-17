public class Vehiculo
{
    public string Placa { get; set; }
    public TipoVehiculo Tipo { get; set; }

    public Vehiculo()
    {
        
    }

    public Vehiculo(string placa, TipoVehiculo tipo)
    {
        Placa = placa;
        Tipo = tipo;
    }
}