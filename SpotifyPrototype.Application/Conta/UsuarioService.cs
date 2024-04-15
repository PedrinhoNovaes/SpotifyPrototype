using AutoMapper;
using SpotifyPrototype.Application.Conta.DTO;
using SpotifyPrototype.Domain.Conta.Aggregates;
using SpotifyPrototype.Domain.Streaming.Aggregates;
using SpotifyPrototype.Domain.Transacao.Aggregates;
using SpotifyPrototype.Repository.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyPrototype.Application.Conta
{
    public class UsuarioService
    {
        private IMapper Mapper;
        private UsuarioRepository UsuarioRepository;
        private PlanoRepository PlanoRepository;
        private CartaoService CartaoService;

        public UsuarioService(IMapper mapper, UsuarioRepository usuarioRepository, PlanoRepository planoRepository, CartaoService cartaoService)
        {
            Mapper = mapper;
            UsuarioRepository = usuarioRepository;
            PlanoRepository = planoRepository;
            CartaoService = cartaoService;
        }

        public UsuarioDto Criar(UsuarioDto dto)
        {
            if (this.UsuarioRepository.Exists(x => x.Email == dto.Email))
            {
                throw new Exception("Usuário já existente na base.");
            }

            Plano? plano = PlanoRepository.GetById(dto.PlanoId);

            if (plano == null)
            {
                throw new Exception("Plano não localizado.");
            }

            Usuario usuario = new();

            Cartao cartao = CartaoService.ConsultarCartaoAtivo(dto.Cartao);

            usuario.CriarConta(dto.Nome, dto.Email, dto.Senha, dto.Telefone, dto.DataNascimento, plano, cartao);

            this.UsuarioRepository.Save(usuario);

            var result = this.Mapper.Map<UsuarioDto>(usuario);

            return result;
        }

        public UsuarioDto? Obter(Guid id)
        {
            var usuario = this.UsuarioRepository.GetById(id);

            if (usuario == null)
                return null;

            return this.Mapper.Map<UsuarioDto>(usuario);
        }

        public UsuarioDto? Autenticar(string email, string senha)
        {
            var SenhaCriptografada = Usuario.CriptografarSenha(senha);

            var usuario = this.UsuarioRepository.Find(x => x.Email == email && x.Senha == SenhaCriptografada).FirstOrDefault();

            if (usuario == null)
                return null;

            return this.Mapper.Map<UsuarioDto>(usuario);
        }

        public List<PlanoDto> ObterPlanos()
        {
            var plano = this.PlanoRepository.GetAll().ToList();

            return this.Mapper.Map<List<PlanoDto>>(plano);
        }
    }
}
