using SpotifyPrototype.Domain.Core.ValueObject;
using SpotifyPrototype.Domain.Transaction.ValueObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyPrototype.Domain.Transaction.Aggregates
{
    public class Transaction
    {
        public Guid Id { get; set; }
        public DateTime TransactionDate { get; set; }
        public Monetary Value { get; set; }
        public string Description { get; set; }
        public Merchant Merchant { get; set; }
    }
}
