using SpotifyPrototype.Application.Admin.Dto;
using SpotifyPrototype.Domain.Admin.Aggregates;
using SpotifyPrototype.Domain.Admin.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyPrototype.Application.Admin.Profile
{
    public class UsuarioAdminProfile : AutoMapper.Profile
    {
        public UsuarioAdminProfile()
        {
            CreateMap<UsuarioAdminDto, UsuarioAdmin>()
                .ForMember(x => x.Perfil, m => m.MapFrom(f => (Perfil)f.Perfil))
                .ReverseMap();
        }
    }
}
