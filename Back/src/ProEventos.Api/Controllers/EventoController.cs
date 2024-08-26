using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProEventos.Api.Data;
using ProEventos.Api.Models;

namespace ProEventos.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EventoController : ControllerBase
    {
        private readonly DataContext context;
        public EventoController(DataContext contexto)
        {
            this.context = contexto;            
        }
        
        private readonly List<Evento> Eventos = new List<Evento>();
        private readonly ILogger<EventoController> _logger;     
     

        [HttpGet]
        public List<Evento> Get()
        {         
            return context.Eventos.ToList();
        }


        [HttpGet("{id}")]
        public Evento GetById(int id)
        {         
            return context.Eventos.Where(c=>c.Id==id).FirstOrDefault();
        }
    }
}
