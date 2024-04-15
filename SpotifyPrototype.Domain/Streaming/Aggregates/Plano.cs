using SpotifyPrototype.Domain.Core.Enum;
using SpotifyPrototype.Domain.Core.ValueObject;
using SpotifyPrototype.Domain.Streaming.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyPrototype.Domain.Streaming.Aggregates
{
    public class Plano
    {
        public Guid Id { get; set; }
        public String Nome { get; set; }
        public String Descricao { get; set; }
        public Monetario Valor { get; set; }
        public TipoStatus Status { get; set; }
        public Periodo Vigencia { get; set; }

        public static Plano Criar(string nome, string descricao, Monetario valor, Periodo vigencia)
        {
            if (String.IsNullOrEmpty(nome))
            {
                throw new Exception("E obrigatorio informar o nome do plano.");
            }

            return new()
            {
                Nome = nome,
                Descricao = descricao,
                Valor = valor,
                Vigencia = vigencia,
                Status = TipoStatus.Ativo
            };
        }
    }
}
