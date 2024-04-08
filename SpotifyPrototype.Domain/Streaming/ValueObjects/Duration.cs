using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyPrototype.Domain.Streaming.ValueObjects
{
    public record Duration
    {
        public int Value { get; init; }

        public Duration(int value)
        {
            if (value < 0)
                throw new ArgumentException("Song duration cannot be negative");

            Value = value;
        }

        public string Formatted()
        {
            int minutes = Value / 60;
            int seconds = Value % 60;

            return $"{minutes.ToString().PadLeft(1, '0')}:{seconds.ToString().PadLeft(1, '0')}";
        }

        public static implicit operator int(Duration duration) => duration.Value;
        public static implicit operator Duration(int value) => new Duration(value);
    }

}
