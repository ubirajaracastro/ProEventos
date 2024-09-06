using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProEventos.Dominio;

namespace ProEventos.Persistencia.Contratos
{
    public interface IPalestrantePersistencia
    {
      Task<Palestrante[]> GetAllPalestrantesByNomeAsync(string nome, bool includeEventos);
      Task<Palestrante[]> GetAllPalestrantesAsync(bool includeEventos);
      Task<Palestrante> GetPalestranteByIdAsync(int palestranteId, bool includeEventos);

    }
}