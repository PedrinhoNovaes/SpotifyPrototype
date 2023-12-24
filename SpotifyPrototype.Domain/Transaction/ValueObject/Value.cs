using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyPrototype.Domain.Transaction.ValueObject
{
    public record Value
    {
        public decimal Amount { get; init; }

        public Value(decimal amount)
        {
            Amount = amount;
        }

        public string Format()
        {
            return $"${Amount.ToString("N2")}";
        }
    }
}
