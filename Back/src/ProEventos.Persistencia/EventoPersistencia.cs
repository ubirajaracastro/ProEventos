using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProEventos.Dominio;
using ProEventos.Persistencia.Contexto;
using ProEventos.Persistencia.Contratos;


namespace ProEventos.Persistencia
{
    
    public class EventoPersistencia : IEventoPersistencia
    {
        #region Membros
        private readonly ProEventoContext _context;
        #endregion

        #region Construtor
        public EventoPersistencia(ProEventoContext context)
        {
            _context = context;
        }
         
        #endregion
       
       #region  Metodos
       public async Task<Evento[]> GetAllEventosAsync(bool includePalestrantes = false)
        {
            IQueryable<Evento> query = _context.Evento.AsNoTracking()
                .Include(e => e.Lotes)
                .Include(e => e.RedesSociais);

            if (includePalestrantes)
            {
                query = query
                    .Include(e => e.PalestrantesEventos)
                    .ThenInclude(pe => pe.Palestrante);
            }

            query = query.AsNoTracking().OrderBy(e => e.Id);

            return await query.ToArrayAsync();
        }

        public async Task<Evento[]> GetAllEventosByTemaAsync(string tema, bool includePalestrantes = false)
        {
             IQueryable<Evento> query = _context.Evento.AsNoTracking()
                .Include(e => e.Lotes)
                .Include(e => e.RedesSociais);

            if (includePalestrantes)
            {
                query = query
                    .Include(e => e.PalestrantesEventos)
                    .ThenInclude(pe => pe.Palestrante);
            }

            query = query.AsNoTracking().OrderBy(e => e.Id)
                         .Where(e => e.Tema.ToLower().Contains(tema.ToLower()));

            return await query.ToArrayAsync();
        }

        public async Task<Evento> GetEventoByIdAsync(int eventoId, bool includePalestrantes = false)
        {
             IQueryable<Evento> query = _context.Evento.AsNoTracking()
                .Include(e => e.Lotes)
                .Include(e => e.RedesSociais);

            if (includePalestrantes)
            {
                query = query
                    .Include(e => e.PalestrantesEventos)
                    .ThenInclude(pe => pe.Palestrante);
            }

            query = query.AsNoTracking().OrderBy(e => e.Id)
                         .Where(e => e.Id == eventoId);

            return await query.FirstOrDefaultAsync();
        }

        #endregion
    }
}