using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProEventos.Api.Models;

namespace ProEventos.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EventoController : ControllerBase
    {
        private readonly List<Evento> Eventos = new List<Evento>();
        private readonly ILogger<EventoController> _logger;

        

        public EventoController(ILogger<EventoController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public List<Evento> Get()
        {
             Evento ev=new Evento {
             Data = DateTime.Now.AddDays(2).ToShortDateString(),
             Id = 1,
             Local = "Curitiba",
             Nome = "IATEC"
             };           
            
             Evento ev2 = new Evento{
             Data = DateTime.Now.AddDays(5).ToShortDateString(),
             Id = 2,
             Local = "Sao Paulo",
             Nome = "AWS Center"
            };

             Evento ev3 = new Evento{
             Data = DateTime.Now.AddDays(9).ToShortDateString(),
             Id = 1,
             Local = "Rio de Janeiro",
             Nome = "Expotec.NET"
            };                      
            
            Eventos.Add(ev);
            Eventos.Add(ev2);
            Eventos.Add(ev3);            

            return Eventos;
        }
    }
}
