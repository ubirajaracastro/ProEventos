using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProEventos.Api.Models;

namespace ProEventos.Api.Data
{
    public class DataContext:DbContext
    {
        public DbSet<Evento>Eventos { get; set; }   




    }
}