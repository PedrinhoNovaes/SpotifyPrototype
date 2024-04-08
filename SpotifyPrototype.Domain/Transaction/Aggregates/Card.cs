using SpotifyPrototype.Domain.Core.ValueObject;
using SpotifyPrototype.Domain.Transaction.ValueObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyPrototype.Domain.Transaction.Aggregates
{
    public class Card
    {
        private const int TRANSACTION_INTERVAL = -2;
        private const int MERCHANT_TRANSACTION_REPEAT = 1;

        public Guid Id { get; set; }
        public bool Active { get; set; }
        public Monetary Limit { get; set; }
        public string Number { get; set; }
        public virtual IList<Transaction> Transactions { get; set; } = new List<Transaction>();

        public void CreateTransaction(Merchant merchant, Monetary value, string description = "")
        {
            // Check if the card is active
            CheckIfCardIsActive();

            Transaction transaction = new Transaction();
            transaction.Merchant = merchant;
            transaction.Value = value;
            transaction.Description = description;
            transaction.TransactionDate = DateTime.Now;

            // Check available limit
            CheckLimit(transaction);

            // Check anti-fraud rules
            ValidateTransaction(transaction);

            // Create authorization number
            transaction.Id = Guid.NewGuid();

            // Decrease the limit by the transaction value
            this.Limit -= transaction.Value;

            this.Transactions.Add(transaction);
        }

        private void ValidateTransaction(Transaction transaction)
        {
            var recentTransactions = this.Transactions.Where(x =>
                                                           x.TransactionDate >= DateTime.Now.AddMinutes(TRANSACTION_INTERVAL));
            if (recentTransactions?.Count() >= 3)
                throw new Exception("Card used too many times in a short period");

            var repeatedTransactionByMerchant = recentTransactions?
                                                 .Where(x => x.Merchant.Name.ToUpper() == transaction.Merchant.Name.ToUpper()
                                                        && x.Value == transaction.Value)
                                                 .Count() == MERCHANT_TRANSACTION_REPEAT;

            if (repeatedTransactionByMerchant)
                throw new Exception("Duplicate transaction for the same card and the same merchant");
        }

        private void CheckLimit(Transaction transaction)
        {
            if (this.Limit < transaction.Value)
                throw new Exception("Card does not have sufficient limit for this transaction");
        }

        private void CheckIfCardIsActive()
        {
            if (!this.Active)
                throw new Exception("Card is not active");
        }
    }

}
