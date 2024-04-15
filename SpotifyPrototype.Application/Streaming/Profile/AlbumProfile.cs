using SpotifyPrototype.Application.Streaming.Dto;
using SpotifyPrototype.Domain.Streaming.Aggregates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyPrototype.Application.Streaming.Profile
{
    public class AlbumProfile : AutoMapper.Profile
    {
        public AlbumProfile()
        {
            CreateMap<Musica, MusicaDto>()
                .AfterMap((s, d) =>
                {
                    d.IdEstiloMusical = s.EstiloMusical.Id;
                    d.NomeEstiloMusical = s.EstiloMusical.Nome;
                    d.Autores = String.Empty;

                    foreach (var item in s.Autores)
                    {
                        var simbolo = s.Autores.IndexOf(item) == 0 ? String.Empty : "; ";

                        d.Autores += simbolo + item.Nome.Trim();
                    }
                });

            CreateMap<Album, AlbumDto>()
                .AfterMap((s, d) =>
                {
                    d.IdAutorPrincipal = s.AutorPrincipal.Id;
                });
        }
    }
}
