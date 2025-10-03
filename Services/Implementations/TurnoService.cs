using TurnosConsultorioMedico.DTOs;
using TurnosConsultorioMedico.Models;
using TurnosConsultorioMedico.Repositories.Interfaces;
using TurnosConsultorioMedico.Services.Interfaces;

namespace TurnosConsultorioMedico.Services.Implementations
{
    public class TurnoService : ITurnoService
    {
        private ITurnoRepository _turnoRepository;

        // Inyección de dependencias
        public TurnoService(ITurnoRepository turnoRepository)
        {
            _turnoRepository = turnoRepository;
        }

        public void AddOne(AddTurnoDto turnoDto)
        {
            // Convertimos el DTO en un Model
            TTurno turno = turnoDto.ConvertToModel();

            // Validamos datos mínimos
            if (string.IsNullOrEmpty(turno.Paciente) ||
                string.IsNullOrEmpty(turno.Estado) ||
                turno.TDetallesTurnos.Count == 0)
            {
                throw new ArgumentException("El turno debe tener un paciente, un estado y al menos un detalle.");
            }

            List<int> ListMatriculas = new List<int>();

            foreach (TDetallesTurno detalle in turno.TDetallesTurnos)
            {
                DateTime fechaParse = DateTime.Parse(detalle.Fecha);

                // Validamos fecha adecuada
                if (DateTime.Today.AddDays(1) > fechaParse)
                {
                    throw new ArgumentException("La fecha del turno debe ser al menos un día después de la fecha actual.");
                }

                // Validamos turno repetido
                if (_turnoRepository.GetByFechaHoraMatricula(detalle.Fecha, detalle.Hora, detalle.Matricula) > 0)
                {
                    throw new InvalidOperationException("Ya existe un turno para el mismo profesional en la misma fecha y hora.");
                }

                // Validamos médico repetido
                if (ListMatriculas.Contains(detalle.Matricula))
                {
                    throw new InvalidOperationException("No se pueden asignar dos turnos al mismo profesional en una misma solicitud.");
                }
                else
                {
                    ListMatriculas.Add(detalle.Matricula);
                }
            }

            if (!_turnoRepository.AddOne(turno))
            {
                throw new Exception();
            }
        }

        public int GetByFechaHoraMatricula(string fecha, string hora, string matricula)
        {
            // Validamos datos mínimos
            if (string.IsNullOrEmpty(fecha) ||
                string.IsNullOrEmpty(hora) ||
                string.IsNullOrEmpty(matricula))
            {
                throw new ArgumentException("Se requiere fecha, hora y matricula.");
            }

            int matriculaParse = int.Parse(matricula);

            return _turnoRepository.GetByFechaHoraMatricula(fecha, hora, matriculaParse);
        }
    }
}
