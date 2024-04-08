using SpotifyPrototype.Application.Streaming.Dto;
using SpotifyPrototype.Domain.Streaming.Aggregates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyPrototype.Application.Streaming.Profile
{
    public class BandProfile : AutoMapper.Profile
    {
        public BandProfile()
        {
            CreateMap<BandDto, Band>()
                .ReverseMap();
        }
    }

}
