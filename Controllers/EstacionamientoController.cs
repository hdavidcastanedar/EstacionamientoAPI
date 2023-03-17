using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EstacionamientoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstacionamientoController : ControllerBase
    {
        private readonly IEstacionamientoService _estacionamientoService;

        public EstacionamientoController(IEstacionamientoService estacionamientoService)
        {
            _estacionamientoService = estacionamientoService;
        }

        [HttpPost("registrar-entrada")]
        public IActionResult RegistrarEntrada(string placa)
        {
            try
            {
                _estacionamientoService.RegistrarEntrada(placa);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("registrar-salida")]
        public IActionResult RegistrarSalida(string placa)
        {
            try
            {
                var importe = _estacionamientoService.RegistrarSalida(placa);
                return Ok(new { Importe = importe });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("alta-vehiculo-oficial")]
        public IActionResult DarDeAltaVehiculoOficial(string placa)
        {
            try
            {
                _estacionamientoService.AltaVehiculoOficial(placa);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("alta-vehiculo-residente")]
        public IActionResult DarDeAltaVehiculoResidente(string placa)
        {
            try
            {
                _estacionamientoService.AltaVehiculoResidente(placa);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("comenzar-mes")]
        public IActionResult ComenzarMes()
        {
            try
            {
                _estacionamientoService.ComienzaMes();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("pagos-residentes")]
        public IActionResult GenerarInformePagosResidentes()
        {
            try
            {
                var pagosResidentes = _estacionamientoService.GenerarInformePagosResidentes();
                return Ok(pagosResidentes);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
