public class Estacionamiento
{
    public List<Vehiculo> Vehiculos { get; set; }
    public List<Estancia> Estancias { get; set; }

    public Estacionamiento()
    {
        Vehiculos = new List<Vehiculo>();
        Estancias = new List<Estancia>();
    }
    
}