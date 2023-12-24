using SpotifyPrototype.Domain.Shared;
using SpotifyPrototype.Domain.Transaction.ValueObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace SpotifyPrototype.Domain.Notification
{
    public class Notification : Entity
    {
        public string MerchantId { get; set; }
        public Value Amount { get; set; }
        public TransactionStatus TransactionStatus { get; set; }

        public Notification()
        {
            Amount = new Value(0);
        }

        public Notification(string merchantId, Value amount, TransactionStatus transactionStatus) : base()
        {
            MerchantId = merchantId;
            Amount = amount;
            TransactionStatus = transactionStatus;
        }
    }
}