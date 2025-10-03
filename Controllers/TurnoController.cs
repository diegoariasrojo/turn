using Microsoft.AspNetCore.Mvc;
using TurnosConsultorioMedico.DTOs;
using TurnosConsultorioMedico.Models;
using TurnosConsultorioMedico.Services.Interfaces;

namespace TurnosConsultorioMedico.Controllers
{
    [Route("api/turno")]
    public class TurnoController : Controller
    {
        private ITurnoService _turnoService;

        // Inyección de dependencias
        public TurnoController(ITurnoService turnoService)
        {
            _turnoService = turnoService;
        }

        [HttpPost]
        public IActionResult AddOne([FromBody] AddTurnoDto turnoDto)
        {
            try
            {
                _turnoService.AddOne(turnoDto);

                // Devolvemos 204 No Content en caso de éxito
                return NoContent();
            }
            catch (ArgumentException e1)
            {
                // 400 
                return BadRequest(e1.Message);
            }
            catch (InvalidOperationException e2)
            {
                // 400
                return BadRequest(e2.Message);
            }
            catch (Exception)
            {
                // 500
                return StatusCode(500, "Ocurrió un error al procesar la solicitud.");
            }
        }

        [HttpGet]
        [Route("{fecha}/{hora}/{matricula}")]
        public IActionResult GetByFechaHoraMatricula(string fecha, string hora, string matricula)
        {
            try
            {
                int cantidad = _turnoService.GetByFechaHoraMatricula(fecha, hora, matricula);

                return Ok(cantidad);
            }
            catch (Exception)
            {
                return StatusCode(500, "Ocurrió un error al procesar la solicitud.");
            }
        }
    }
}
