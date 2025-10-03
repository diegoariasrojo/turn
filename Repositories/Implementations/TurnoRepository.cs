using TurnosConsultorioMedico.Models;
using TurnosConsultorioMedico.Repositories.Interfaces;

namespace TurnosConsultorioMedico.Repositories.Implementations
{
    public class TurnoRepository : ITurnoRepository
    {
        public TurnosContext _db;

        // Inyección de dependencias
        public TurnoRepository(TurnosContext db)
        {
            _db = db;
        }

        public bool AddOne(TTurno turno)
        {
            _db.TTurnos.Add(turno);

            return _db.SaveChanges() > 0;
        }

        public int GetByFechaHoraMatricula(string fecha, string hora, int matricula)
        {
            /* La siguiente expresión Linq es equivalente a
             * 
             * SELECT COUNT(*)
             * FROM TDetallesTurnos
             * WHERE
             *  matricula = @matricula AND
             *  fecha = @fecha AND
             *  hora = @hora
             */
            return _db.TDetallesTurnos.Count(d =>
                d.Matricula == matricula &&
                d.Fecha == fecha &&
                d.Hora == hora);
        }
    }
}
