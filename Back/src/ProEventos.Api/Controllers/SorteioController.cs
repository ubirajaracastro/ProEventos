using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProEventos.Api.Models;

namespace ProEventos.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SorteioController : ControllerBase
    {
        List<Sorteio> sorteios=new List<Sorteio>();

       [HttpGet]
        public List<Sorteio> Get() {               

            return sorteios;
        }

       [HttpGet("{id}")]
        public Sorteio GetById(int id)
        {         
            return sorteios.Where(s=>s.Id==id).FirstOrDefault();
        }

        [HttpGet("{clientId}")]
        public List<Sorteio> GetByClienteId(int clientId)
        {         
            return sorteios.Where(s=>s.ClienteID==clientId).ToList();
        }

        [HttpGet("{NumeroSorteioId,clienteId}")]
        public List<Sorteio> GetListNumerosSorte(int SorteioID, int clientId)
        {         
            return sorteios.Where(s=>s.Id==SorteioID && s.ClienteID==clientId).ToList();
        }



    }
}