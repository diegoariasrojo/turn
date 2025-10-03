using TurnosConsultorioMedico.DTOs;

namespace TurnosConsultorioMedico.Services.Interfaces
{
    public interface ITurnoService
    {
        void AddOne(AddTurnoDto turno);
        int GetByFechaHoraMatricula(string fecha, string hora, string matricula);
    }
}
