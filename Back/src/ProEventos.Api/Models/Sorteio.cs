using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProEventos.Api.Models
{
    public class Sorteio
    {
        public int Id { get; set; }
        public DateTime Data { get; set; }
        public int Numero { get; set; }     
        public int BannerId { get; set; }
        public decimal ValorPremio { get; set; }
        public List<SorteioRealizado>SorteiosRealizados { get; set; }  
        public List<NumerosSorte>NumerosdaSorte { get; set; } 
        public long NumeroSorteado { get; set; } 
        public int ClienteID { get; set; }


        
    }
}