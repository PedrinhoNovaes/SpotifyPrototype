using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyPrototype.Domain.Transacao.ValueObject
{
    public class Merchant
    {
        public String Nome { get; set; }

        public static Merchant Criar(String nome)
        {
            if (String.IsNullOrEmpty(nome))
                throw new Exception("E obrigatorio informar o nome do Merchant.");

            return new Merchant() { Nome = nome };
        }
    }
}
