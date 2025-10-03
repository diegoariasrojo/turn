using TurnosConsultorioMedico.Models;

namespace TurnosConsultorioMedico.Repositories.Interfaces
{
    public interface ITurnoRepository
    {
        bool AddOne(TTurno turno);
        int GetByFechaHoraMatricula(string fecha, string hora, int matricula);
    }
}
