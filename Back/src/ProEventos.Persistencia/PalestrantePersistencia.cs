using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProEventos.Dominio;
using ProEventos.Persistencia.Contexto;
using ProEventos.Persistencia.Contratos;

namespace ProEventos.Persistencia
{
    public class PalestrantePersistencia:IPalestrantePersistencia
    {
        private readonly ProEventoContext _context;
        public PalestrantePersistencia(ProEventoContext context)
        {
            _context = context;
        }

        public async Task<Palestrante[]> GetAllPalestrantesAsync(bool includeEventos)
        {
            IQueryable<Palestrante> query = _context.Palestrante
                .Include(p => p.RedesSociais);

            if (includeEventos)
            {
                query = query
                    .Include(p => p.PalestrantesEventos)
                    .ThenInclude(pe => pe.Evento);
            }

            query = query.AsNoTracking().OrderBy(p => p.Id);

            return await query.ToArrayAsync();
        }

        public async  Task<Palestrante[]> GetAllPalestrantesByNomeAsync(string nome, bool includeEventos)
        {
             IQueryable<Palestrante> query = _context.Palestrante
                .Include(p => p.RedesSociais);

            if (includeEventos)
            {
                query = query
                    .Include(p => p.PalestrantesEventos)
                    .ThenInclude(pe => pe.Evento);
            }

            query = query.AsNoTracking().OrderBy(p => p.Id)
                         .Where(p => p.Nome.ToLower().Contains(nome.ToLower()));

            return await query.ToArrayAsync();
        }

        public async Task<Palestrante> GetPalestranteByIdAsync(int palestranteId, bool includeEventos)
        {
              IQueryable<Palestrante> query = _context.Palestrante
                .Include(p => p.RedesSociais);

            if (includeEventos)
            {
                query = query
                    .Include(p => p.PalestrantesEventos)
                    .ThenInclude(pe => pe.Evento);
            }

            query = query.AsNoTracking().OrderBy(p => p.Id)
                         .Where(p => p.Id == palestranteId);

            return await query.FirstOrDefaultAsync();
        }
    }
}