using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyPrototype.Domain.Transaction.ValueObject
{
    public record Merchant
    {
        public string Name { get; set; }
    }
}
