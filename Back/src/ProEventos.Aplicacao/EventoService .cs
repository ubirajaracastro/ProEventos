using ProEventos.Aplicacao.Contratos;
using ProEventos.Dominio;
using ProEventos.Persistencia.Contratos;

namespace ProEventos.Aplicacao
{
    public class EventoService : IEventoService
    {
         #region  Construtor
        public IGeralPersistencia _geralPersist { get; }
        public IEventoPersistencia _eventoPersist { get; }       
        public EventoService (IGeralPersistencia geralPersist, IEventoPersistencia eventoPersist) 
        {
           _geralPersist= geralPersist;
           _eventoPersist = eventoPersist;
            
        }
        #endregion

         #region Metodos
        public async Task<Evento> AddEvento(Evento model)
        {           

         try
            {
                _geralPersist.Add<Evento>(model);
                await _geralPersist.SaveChangesAsync();
                
                return await _eventoPersist.GetEventoByIdAsync(model.Id, false);                

             }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }       
            
            
           }

        public async Task<bool> DeleteEvento(int eventoId)
        {
             try
            {
                var evento = await _eventoPersist.GetEventoByIdAsync(eventoId, false);
                if (evento == null) throw new Exception("Evento para delete não encontrado.");

                _geralPersist.Delete<Evento>(evento);
                return await _geralPersist.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Evento[]> GetAllEventosAsync(bool includePalestrantes = false)
        {
           try
            {
                var eventos = await _eventoPersist.GetAllEventosAsync(includePalestrantes);              
                return eventos;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public  async Task<Evento[]> GetAllEventosByTemaAsync(string tema, bool includePalestrantes = false)
        {
            try
            {
                var eventos = await _eventoPersist.GetAllEventosByTemaAsync(tema, includePalestrantes);              
                return eventos;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Evento> GetEventoByIdAsync(int eventoId, bool includePalestrantes = false)
        {
            try
            {
                var eventos = await _eventoPersist.GetEventoByIdAsync(eventoId, includePalestrantes);                
                return eventos;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Evento> UpdateEvento(int eventoId, Evento model)
        {
             try
            {
                var evento = await _eventoPersist.GetEventoByIdAsync(eventoId, false);              
                model.Id = evento.Id;

                _geralPersist.Update(model);
                await _geralPersist.SaveChangesAsync();    

                return await _eventoPersist.GetEventoByIdAsync(model.Id, false);
                
                
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        #endregion
    }
}