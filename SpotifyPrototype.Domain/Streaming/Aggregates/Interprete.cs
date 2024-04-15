using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyPrototype.Domain.Streaming.Aggregates
{
    public class Interprete
    {
        public Guid Id { get; set; }
        public required String Nome { get; set; }
        public virtual IList<Musica> Musicas { get; set; } = [];

        public static Interprete Criar(String Nome)
        {
            if (String.IsNullOrEmpty(Nome)) throw new Exception("E obrigatorio informar o nome.");

            return new Interprete { Nome = Nome };
        }
    }
}
