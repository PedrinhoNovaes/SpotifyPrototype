﻿using SpotifyPrototype.Domain.Core.Enum;
using SpotifyPrototype.Domain.Core.ValueObject;
using SpotifyPrototype.Domain.Streaming.Aggregates;
using SpotifyPrototype.Domain.Streaming.Enum;
using SpotifyPrototype.Domain.Transacao.Aggregates;
using SpotifyPrototype.Domain.Transacao.ValueObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyPrototype.Domain.Conta.Aggregates
{
    public class Usuario
    {
        private const string PLAYLISTFAVORITA = "Favoritas";
        public Guid Id { get; set; }
        public String Nome { get; set; }
        public String Senha { get; set; }
        public String Email { get; set; }
        public String Telefone { get; set; }
        public DateTime DataNascimento { get; set; }
        public virtual IList<Cartao> Cartoes { get; set; } = new List<Cartao>();
        public virtual IList<Assinatura> Assinaturas { get; set; } = new List<Assinatura>();
        public virtual IList<Playlist> Playlists { get; set; } = new List<Playlist>();
        public virtual IList<Notificacao.Aggregates.Notificacao> Notificacoes { get; set; } = new List<Notificacao.Aggregates.Notificacao>();

        public void CriarConta(String nome, String email, String senha, String Telefone, DateTime dataNascimento, Plano plano, Cartao cartao)
        {
            this.Nome = nome;
            this.Email = email;
            this.Senha = CriptografarSenha(senha);
            this.DataNascimento = dataNascimento;
            this.Telefone = Telefone;
            this.AssinarPlano(plano, cartao);
            this.AdicionarCarto(cartao);
            this.CriarPlayList();
        }

        private void AdicionarCarto(Cartao cartao) => this.Cartoes.Add(cartao);

        private void CriarPlayList()
        {
            CriarPlayList(PLAYLISTFAVORITA, false);
        }

        private void CriarPlayList(string nome, bool publica)
        {
            this.Playlists.Add(new Playlist()
            {
                Nome = nome,
                Autor = this,
                Publica = publica,
                TipoPlayList = TipoPlayList.Favorita,
                DataCriacao = DateTime.Now
            });
        }

        private void AssinarPlano(Plano plano, Cartao cartao)
        {
            cartao.CriarTransacao(
                Merchant.Criar(plano.Nome),
                new Monetario(plano.Valor),
                plano.Nome);

            DesativarAssinaturaAtiva();

            this.Assinaturas.Add(Assinatura.Criar(
                plano: plano,
            DataInicio: DateTime.Now
            ));
        }

        private void DesativarAssinaturaAtiva()
        {
            if (this.Assinaturas.Count > 0 && this.Assinaturas.Any(x => x.Status == TipoStatus.Ativo))
            {
                var assinatura = this.Assinaturas.FirstOrDefault(x => x.Status == TipoStatus.Ativo);

                assinatura?.Inativar();
            }
        }

        public static String CriptografarSenha(string senhaAberta)
        {
            //BCript
            SHA256 criptoProvider = SHA256.Create();

            byte[] texto = Encoding.UTF8.GetBytes(senhaAberta);

            var criptoResult = criptoProvider.ComputeHash(texto);

            return Convert.ToHexString(criptoResult);
        }
    }
}
