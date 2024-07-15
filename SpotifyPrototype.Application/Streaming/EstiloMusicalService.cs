using AutoMapper;
using SpotifyPrototype.Application.Streaming.Dto;
using SpotifyPrototype.Repository.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyPrototype.Application.Streaming
{
    public class EstiloMusicalService(EstiloMusicalRepository _EstiloMusicalRepository, IMapper mapper)
    {
        public List<EstiloMusicalDto> Obter()
        {
            var result = _EstiloMusicalRepository.GetAll();

            var estilos = mapper.Map<List<EstiloMusicalDto>>(result);

            return estilos ?? [];
        }
    }
}
