using SpotifyPrototype.Domain.Conta.Aggregates;
using SpotifyPrototype.Domain.Streaming.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyPrototype.Domain.Streaming.Aggregates
{
    public class Playlist
    {
        public Guid Id { get; set; }
        public String Nome { get; set; }
        public TipoPlayList TipoPlayList { get; set; }
        public virtual Usuario Autor { get; set; }
        public DateTime DataCriacao { get; set; }
        public bool Publica { get; set; }
        public virtual IList<Musica> Musicas { get; set; } = [];

        public static Playlist Criar(String Nome, TipoPlayList tipo, Usuario autor, bool publica)
        {
            if (String.IsNullOrEmpty(Nome)) throw new Exception("E obrigatorio informar o nome.");

            return new Playlist
            {
                Nome = Nome,
                TipoPlayList = tipo,
                Autor = autor,
                Publica = publica,
                DataCriacao = DateTime.Now,
            };
        }
    }
}
