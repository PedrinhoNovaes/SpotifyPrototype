using SpotifyPrototype.Domain.Transaction.Aggregates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace SpotifyPrototype.Tests.Domain
{
    public class CardTests
    {
        [Fact]
        public void ShouldCreateTransactionSuccessfully()
        {
            Card card = new Card()
            {
                Id = Guid.NewGuid(),
                Active = true,
                Limit = 1000M,
                Number = "6465465466",
            };

            var merchant = new SpotifyPrototype.Domain.Transaction.ValueObject.Merchant()
            {
                Name = "Dummy"
            };

            card.CreateTransaction(merchant, 19M, "Dummy Transaction");
            Assert.True(card.Transactions.Count > 0);
            Assert.True(card.Limit == 981M);
        }

        [Fact]
        public void ShouldNotCreateTransactionWithInactiveCard()
        {
            Card card = new Card()
            {
                Id = Guid.NewGuid(),
                Active = false,
                Limit = 1000M,
                Number = "6465465466",
            };

            var merchant = new SpotifyPrototype.Domain.Transaction.ValueObject.Merchant()
            {
                Name = "Dummy"
            };

            Assert.Throws<Exception>(
                () => card.CreateTransaction(merchant, 19M, "Dummy Transaction"));
        }

        [Fact]
        public void ShouldNotCreateTransactionWithCardWithoutLimit()
        {
            Card card = new Card()
            {
                Id = Guid.NewGuid(),
                Active = true,
                Limit = 10M,
                Number = "6465465466",
            };

            var merchant = new SpotifyPrototype.Domain.Transaction.ValueObject.Merchant()
            {
                Name = "Dummy"
            };

            Assert.Throws<Exception>(
                () => card.CreateTransaction(merchant, 19M, "Dummy Transaction"));
        }

        [Fact]
        public void ShouldNotCreateTransactionWithDuplicateCardValue()
        {
            Card card = new Card()
            {
                Id = Guid.NewGuid(),
                Active = true,
                Limit = 1000M,
                Number = "6465465466",
            };

            card.Transactions.Add(new Transaction()
            {
                TransactionDate = DateTime.Now,
                Id = Guid.NewGuid(),
                Merchant = new SpotifyPrototype.Domain.Transaction.ValueObject.Merchant()
                {
                    Name = "Dummy"
                },
                Value = 19M,
                Description = "saljasdlak"
            });

            var merchant = new SpotifyPrototype.Domain.Transaction.ValueObject.Merchant()
            {
                Name = "Dummy"
            };

            Assert.Throws<Exception>(
                () => card.CreateTransaction(merchant, 19M, "Dummy Transaction"));
        }

        [Fact]
        public void ShouldNotCreateTransactionWithHighFrequencyCard()
        {
            Card card = new Card()
            {
                Id = Guid.NewGuid(),
                Active = true,
                Limit = 1000M,
                Number = "6465465466",
            };

            card.Transactions.Add(new Transaction()
            {
                TransactionDate = DateTime.Now.AddMinutes(-1),
                Id = Guid.NewGuid(),
                Merchant = new SpotifyPrototype.Domain.Transaction.ValueObject.Merchant()
                {
                    Name = "Dummy"
                },
                Value = 19M,
                Description = "saljasdlak"
            });

            card.Transactions.Add(new Transaction()
            {
                TransactionDate = DateTime.Now.AddMinutes(-0.5),
                Id = Guid.NewGuid(),
                Merchant = new SpotifyPrototype.Domain.Transaction.ValueObject.Merchant()
                {
                    Name = "Dummy"
                },
                Value = 19M,
                Description = "saljasdlak"
            });

            card.Transactions.Add(new Transaction()
            {
                TransactionDate = DateTime.Now,
                Id = Guid.NewGuid(),
                Merchant = new SpotifyPrototype.Domain.Transaction.ValueObject.Merchant()
                {
                    Name = "Dummy"
                },
                Value = 19M,
                Description = "saljasdlak"
            });

            var merchant = new SpotifyPrototype.Domain.Transaction.ValueObject.Merchant()
            {
                Name = "Dummy"
            };

            Assert.Throws<Exception>(
                () => card.CreateTransaction(merchant, 19M, "Dummy Transaction"));
        }
    }

}
