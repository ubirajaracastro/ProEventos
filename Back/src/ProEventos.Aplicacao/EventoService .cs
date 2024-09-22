using AutoMapper;
using ProEventos.Aplicacao.Contratos;
using ProEventos.Aplicacao.Dto;
using ProEventos.Dominio;
using ProEventos.Persistencia.Contratos;

namespace ProEventos.Aplicacao
{
    public class EventoService : IEventoService
    {
         #region  Construtor
        public IGeralPersistencia _geralPersist { get; }
        public IEventoPersistencia _eventoPersist { get; }       
        private readonly IMapper _mapper;
        public EventoService (IGeralPersistencia geralPersist, IEventoPersistencia eventoPersist,IMapper mapper) 
        {
           _mapper = mapper;
           _geralPersist= geralPersist;
           _eventoPersist = eventoPersist;
            
        }
        #endregion

         #region Metodos
        public async Task<EventoDto> AddEvento(EventoDto model)
        {        
         try    
            {
                var evento = _mapper.Map<Evento>(model);
                _geralPersist.Add<Evento>(evento);
                await _geralPersist.SaveChangesAsync();

                var eventoRetorno = await _eventoPersist.GetEventoByIdAsync(model.Id, false);
                
                return _mapper.Map<EventoDto>(eventoRetorno);                 

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

        public async Task<EventoDto[]> GetAllEventosAsync(bool includePalestrantes = false)
        {
           try
            {
                var eventos = await _eventoPersist.GetAllEventosAsync(includePalestrantes);              
                return _mapper.Map<EventoDto[]>(eventos);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public  async Task<EventoDto[]> GetAllEventosByTemaAsync(string tema, bool includePalestrantes = false)
        {
            try
            {
                var eventos = await _eventoPersist.GetAllEventosByTemaAsync(tema, includePalestrantes);              
                return _mapper.Map<EventoDto[]>(eventos);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<EventoDto> GetEventoByIdAsync(int eventoId, bool includePalestrantes = false)
        {
            try
            {
                var evento = await _eventoPersist.GetEventoByIdAsync(eventoId, includePalestrantes);                
                return _mapper.Map<EventoDto>(evento);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<EventoDto> UpdateEvento(int eventoId, EventoDto model)
        {
             try
            {
                var evento = await _eventoPersist.GetEventoByIdAsync(eventoId, false);              
                model.Id = evento.Id;

                _mapper.Map(model, evento);
                _geralPersist.Update<Evento>(evento);

                await _geralPersist.SaveChangesAsync();    
                var eventoRetorno = await _eventoPersist.GetEventoByIdAsync(model.Id, false);

                return _mapper.Map<EventoDto>(eventoRetorno);
                
                
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        #endregion
    }
}