using SpotifyPrototype.Domain.Shared;
using SpotifyPrototype.Domain.Transaction.ValueObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyPrototype.Domain.Transaction.Aggregates
{
    public class Signature : Entity
    {
        public TimeSpan Validity { get; set; }
        public Value Price { get; set; }

        public Signature()
        {
            Price = new Value(0);
        }

        public Signature(TimeSpan validity, Value price) : base()
        {
            Validity = validity;
            Price = price;
        }
    }
}