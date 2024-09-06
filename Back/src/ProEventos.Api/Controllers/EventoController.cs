using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProEventos.Aplicacao.Contratos;
using ProEventos.Dominio;

namespace ProEventos.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventoController : ControllerBase
    {
        #region construtor
        public IEventoService _eventoService { get; }
        public EventoController(IEventoService eventoService)
        {
            _eventoService = eventoService;           
                
        }    
        #endregion
  
        #region HttpVerbs
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            try
            {
                var eventos = await _eventoService.GetAllEventosAsync(true);
                if (eventos == null) return NotFound("Nenhum evento encontrado.");

                return Ok(eventos);
            }
            catch (Exception ex)
            {
                return StatusCode(500,$"Erro ao tentar recuperar eventos. Erro: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(int id)
        {
            try
            {
                var evento = await _eventoService.GetEventoByIdAsync(id, true);
                if (evento == null) return NotFound("Evento por Id não encontrado.");

                return Ok(evento);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro ao tentar recuperar eventos. Erro: {ex.Message}");
            }
        }


        [HttpGet("{tema}/tema")]
        public async Task<ActionResult> GetByTema(string tema)
        {
            try
            {
                var evento = await _eventoService.GetAllEventosByTemaAsync(tema, true);
                if (evento == null) return NotFound("Eventos por tema não encontrados.");

                return Ok(evento);
            }
            catch (Exception ex)
            {
                return StatusCode(500,$"Erro ao tentar recuperar eventos. Erro: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<ActionResult> Post(Evento model)
        {
            try
            {
                var evento = await _eventoService.AddEvento(model);
                if (evento == null) return BadRequest("Erro ao tentar adicionar evento.");

                return Ok(evento);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro ao tentar adicionar eventos. Erro: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, Evento model)
        {
            try
            {
                var evento = await _eventoService.UpdateEvento(id, model);
                if (evento == null) return BadRequest("Erro ao tentar adicionar evento.");

                return Ok(evento);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro ao tentar atualizar eventos. Erro: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                return await _eventoService.DeleteEvento(id) ? Ok("Deletado") : BadRequest("Evento não deletado");
            }
            catch (Exception ex)
            {
                return StatusCode(500,$"Erro ao tentar deletar eventos. Erro: {ex.Message}");
            }
        }
        #endregion

    }
}