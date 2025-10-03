using Microsoft.EntityFrameworkCore;
using TurnosConsultorioMedico.Models;
using TurnosConsultorioMedico.Repositories.Interfaces;

namespace TurnosConsultorioMedico.Repositories.Implementations
{
    public class MedicoRepository : IMedicoRepository
    {
        private TurnosContext _db;

        // Inyección de dependencias
        public MedicoRepository(TurnosContext db)
        {
            _db = db;
        }

        public List<TMedico> GetAll()
        {
            return _db.TMedicos.Include(m => m.TDetallesTurnos).ToList();
        }
    }
}
