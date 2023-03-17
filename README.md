# EstacionamientoAPI

Esta aplicación permite administrar el acceso de vehículos a un estacionamiento de pago, permitiendo al empleado registrar las entradas y salidas de vehículos y 
calcular los costos asociados según el tipo de vehículo.

## Funcionalidades principales

1. Registrar entrada de vehículo (registrar-entrada)
2. Registrar salida de vehículo (registrar-salida)
3. Dar de alta vehículo oficial (alta-vehiculo-oficial)
4. Dar de alta vehículo de residente (alta-vehiculo-residente)
5. Reiniciar estancias y tiempo estacionado al comienzo del mes (comenzar-mes)
6. Generar informe de pagos de residentes (pagos-residentes)

## Requisitos

- .NET 7.0 
- Entity Framework Core 6.0
- Sql Server 2008 express o superior.

## Instalación

1. Clone este repositorio en su máquina local.
2. Abra la solución en Visual Studio o cualquier otro IDE compatible con .NET.
3. Abra el archivo appsettings.json en la carpeta del proyecto EstacionamientoAPI y ajuste la cadena de conexión "DefaultConnection" 
con el nombre de usuario y contraseña adecuados para su instancia de SQL Server (tener en cuenta que el usuario necesitara permisos suficientes para ejecutar las migraciones) 

```json
{
 "ConnectionStrings": {
    "DefaultConnection": "Server=WINTERSOLDIER\\TEST;Database=Estacionamiento;User Id=test;Password=test123"
  }
}
```

4.Ejecute el comando Update-Database en la consola del Administrador de paquetes para aplicar las migraciones de la base de datos.
Esto creará la base de datos y las tablas necesarias, así como insertará datos de prueba.

Ejecución
Ejecute el proyecto EstacionamientoAPI desde Visual Studio o Visual Studio Code.
La API se iniciará y se abrirá automáticamente la página de Swagger en su navegador web.
Utilice la interfaz de Swagger para probar los distintos puntos finales de la API.

Diagrama de clases:

![Diagrama de clases](https://github.com/hdavidcastanedar/EstacionamientoAPI/blob/master/Docs/1%20Diagrama%20de%20Clases%20EstacionamientoAPI.jpg)

Diagrama de Secuencias:

![Diagrama de secuencias Resgistra entrada](https://github.com/hdavidcastanedar/EstacionamientoAPI/blob/master/Docs/1%20Registrada%20Entrada.jpg)

![Diagrama de secuencias Resgistra salida](https://github.com/hdavidcastanedar/EstacionamientoAPI/blob/master/Docs/2%20Registrada%20Salida.jpg)

![Diagrama de secuencias Alta vehículo oficial](https://github.com/hdavidcastanedar/EstacionamientoAPI/blob/master/Docs/3%20dar%20de%20alta%20veh%C3%ADculo%20oficial.jpg)

![Diagrama de secuencias Alta vehículo residente](https://github.com/hdavidcastanedar/EstacionamientoAPI/blob/master/Docs/4%20dar%20de%20alta%20veh%C3%ADculo%20residente.jpg)

![Diagrama de secuencias Alta Comienza mes](https://github.com/hdavidcastanedar/EstacionamientoAPI/blob/master/Docs/5%20Comienza%20mes.jpg)

![Diagrama de secuencias Pagos de residentes](https://github.com/hdavidcastanedar/EstacionamientoAPI/blob/master/Docs/6%20Pagos%20de%20residentes.jpg)


