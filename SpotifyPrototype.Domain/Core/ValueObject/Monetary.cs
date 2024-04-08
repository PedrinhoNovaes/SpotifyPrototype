using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyPrototype.Domain.Core.ValueObject
{
    public record Monetary
    {
        public decimal Value { get; set; }

        public static implicit operator decimal(Monetary m) => m.Value;
        public static implicit operator Monetary(decimal value) => new Monetary(value);

        public Monetary()
        {

        }

        public Monetary(decimal value)
        {
            if (value < 0)
                throw new ArgumentException("Monetary value cannot be negative");

            Value = value;
        }

        public string Formatted()
        {
            return $"$ {Value.ToString("N2")}";
        }
    }

}
