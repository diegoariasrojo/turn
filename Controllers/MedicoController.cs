using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TurnosConsultorioMedico.Models;
using TurnosConsultorioMedico.Services.Interfaces;

namespace TurnosConsultorioMedico.Controllers
{
    [Route("api/medico")]
    public class MedicoController : Controller
    {
        IMedicoService _medicoService;

        // Inyección de dependencias
        public MedicoController(IMedicoService medicoService)
        {
            _medicoService = medicoService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                List<TMedico> medicoList = _medicoService.GetAll();

                return Ok(medicoList);
            }
            catch (Exception)
            {
                return StatusCode(500, "Ocurrió un error al procesar la solicitud.");
            }
        }
    }
}
