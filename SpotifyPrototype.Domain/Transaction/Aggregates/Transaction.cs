using SpotifyPrototype.Domain.Account.Aggregates;
using SpotifyPrototype.Domain.Shared;
using SpotifyPrototype.Domain.Transaction.ValueObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyPrototype.Domain.Transaction.Aggregates
{
    public class Transaction : Entity
    {
        public Value Amount { get; set; }
        public string MerchantId { get; set; }
        public string Description { get; set; }
        public TransactionStatus Status { get; set; }

        public Transaction()
        {
            Amount = new Value(0); // Valor padrão para Amount
            Status = TransactionStatus.Pending; // Valor padrão para Status
        }

        public Transaction(Value amount, string merchantId, string description) : base()
        {
            Amount = amount;
            MerchantId = merchantId;
            Description = description;
            Status = TransactionStatus.Pending;
        }
    }
}
