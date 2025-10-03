using TurnosConsultorioMedico.Models;
using TurnosConsultorioMedico.Repositories.Interfaces;
using TurnosConsultorioMedico.Services.Interfaces;

namespace TurnosConsultorioMedico.Services.Implementations
{
    public class MedicoService : IMedicoService
    {
        private IMedicoRepository _medicoRepository;

        // Inyección de dependencias
        public MedicoService(IMedicoRepository medicoRepository)
        {
            _medicoRepository = medicoRepository;
        }

        public List<TMedico> GetAll()
        {
            return _medicoRepository.GetAll();
        }
    }
}
