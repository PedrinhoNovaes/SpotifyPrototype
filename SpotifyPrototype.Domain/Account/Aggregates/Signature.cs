using SpotifyPrototype.Domain.Streaming.Aggregates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyPrototype.Domain.Account.Aggregates
{
    public class Signature
    {
        public Guid Id { get; set; }
        public virtual Plan Plan { get; set; }
        public bool Active { get; set; }
        public DateTime ActivationDate { get; set; }

    }
}
