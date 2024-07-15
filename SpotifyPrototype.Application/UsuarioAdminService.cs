using AutoMapper;
using SpotifyPrototype.Application.Admin.Dto;
using SpotifyPrototype.Domain.Admin.Aggregates;
using SpotifyPrototype.Domain.Extensions;
using SpotifyPrototype.Repository.Repository.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyPrototype.Application
{
    public class UsuarioAdminService(
        UsuarioAdminRepository usuarioAdminRepository,
        IMapper mapper)
    {
        public UsuarioAdmin Autenticate(string email, string senha)
        {
            return usuarioAdminRepository.GetByEmailSenha(email, senha.Criptografar());
        }

        public IEnumerable<UsuarioAdminDto> ObterTodos()
        {
            var result = usuarioAdminRepository.GetAll();

            return mapper.Map<List<UsuarioAdminDto>>(result);
        }

        public void Salvar(UsuarioAdminDto dto)
        {
            var usuario = mapper.Map<UsuarioAdmin>(dto);

            usuario.CriptografarSenha();

            usuarioAdminRepository.Save(usuario);
        }
    }
}
