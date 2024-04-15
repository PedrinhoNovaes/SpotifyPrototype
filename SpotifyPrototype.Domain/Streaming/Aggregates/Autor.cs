using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyPrototype.Domain.Streaming.Aggregates
{
    public class Autor
    {
        public Guid Id { get; set; }
        public String Nome { get; set; }
        public String? Descricao { get; set; }
        public String? Backdrop { get; set; }

        public virtual IList<Musica> Musicas { get; set; } = [];

        public static Autor Criar(String Nome, String? Descricao = null, String? Backdrop = null)
        {
            if (String.IsNullOrEmpty(Nome)) throw new Exception("E obrigatorio informar o nome.");

            return new Autor { Nome = Nome };
        }
    }
}
