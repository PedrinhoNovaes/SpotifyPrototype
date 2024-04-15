using SpotifyPrototype.Domain.Core.ValueObject;
using SpotifyPrototype.Domain.Transacao.ValueObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyPrototype.Domain.Transacao.Aggregates
{
    public class Transacao
    {
        public Guid Id { get; set; }
        public required DateTime Data { get; set; }
        public required Monetario Valor { get; set; }
        public required string Descricao { get; set; }
        public required Merchant Merchant { get; set; }
    }
}
