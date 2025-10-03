using System.Runtime.CompilerServices;
using TurnosConsultorioMedico.Models;

namespace TurnosConsultorioMedico.DTOs
{
    public class AddTurnoDto
    {
        // DTO necesario para solicitar datos en el POST de Turnos
        public string Paciente { get; set; } = null!;
        public string Estado { get; set; } = null!;

        // Listado de DTOs de Detalle de Turnos (definido más abajo)
        public List<AddDetalleTurnoDto> DetallesTurno { get; set; } = new List<AddDetalleTurnoDto>();

        // Método que permite convertir el DTO actual en el modelo de base de datos
        public TTurno ConvertToModel()
        {
            TTurno turno = new TTurno
            {
                Paciente = this.Paciente,
                Estado = this.Estado,
                TDetallesTurnos = new List<TDetallesTurno>()
            };

            foreach (var detalleDto in this.DetallesTurno)
            {
                TDetallesTurno detalle = new TDetallesTurno
                {
                    Matricula = detalleDto.Matricula,
                    MotivoConsulta = detalleDto.MotivoConsulta,
                    Fecha = detalleDto.Fecha,
                    Hora = detalleDto.Hora
                };
                turno.TDetallesTurnos.Add(detalle);
            }

            return turno;
        }
    }

    public class AddDetalleTurnoDto
    {
        public int Matricula { get; set; }
        public string MotivoConsulta { get; set; } = null!;
        public string Fecha { get; set; } = null!;
        public string Hora { get; set; } = null!;
    }
}
