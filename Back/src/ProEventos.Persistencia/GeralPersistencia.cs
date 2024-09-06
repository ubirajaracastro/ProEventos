using System.Threading.Tasks;
using ProEventos.Persistencia.Contexto;
using ProEventos.Persistencia.Contratos;

namespace ProEventos.Persistencia
{
    public class GeralPersistencia : IGeralPersistencia
    {
        private readonly ProEventoContext _context;

        public GeralPersistencia(ProEventoContext context)
        {
            _context = context;
        }
        public void Add<T>(T entity) where T : class
        {
            _context.AddAsync(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
             _context.Remove(entity);
        }

        public void DeleteRange<T>(T[] entity) where T : class
        {
             _context.RemoveRange(entity);
        }

        public async Task<bool> SaveChangesAsync()
        {
             return (await _context.SaveChangesAsync()) > 0;
        }

        public void Update<T>(T entity) where T : class
        {
            _context.Update(entity);
        }
    }
}