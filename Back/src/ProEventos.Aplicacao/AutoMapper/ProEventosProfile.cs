using ProEventos.Aplicacao.Dto;
using ProEventos.Dominio;
using AutoMapper;

namespace ProEventos.Aplicacao.AutoMapper
{
    public class ProEventosProfile:Profile
    {
         public ProEventosProfile()
         {
          CreateMap<Evento, EventoDto>().ReverseMap();
          CreateMap<Lote, LoteDto>().ReverseMap();
          CreateMap<RedeSocial, RedeSocialDto>().ReverseMap();
          CreateMap<Palestrante, PalestranteDto>().ReverseMap();          
            
         }

    }

}