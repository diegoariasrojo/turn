using TurnosConsultorioMedico.Models;

namespace TurnosConsultorioMedico.Repositories.Interfaces
{
    public interface IMedicoRepository
    {
        List<TMedico> GetAll();
    }
}
