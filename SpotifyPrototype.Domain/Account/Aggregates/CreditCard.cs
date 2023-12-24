using SpotifyPrototype.Domain.Shared;
using SpotifyPrototype.Domain.Transaction.ValueObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyPrototype.Domain.Account.Aggregates
{
    public class CreditCard : Entity
    {
        public string Number { get; set; }
        public User User { get; set; }
        public string CVV { get; set; }
        public string ExpirationDate { get; set; }
        public Value Limit { get; set; }
        public object AccountId { get; set; }
        public object Account { get; set; }


        public CreditCard()
        {

            User = new User();
            Limit = new Value(0);
        }

        public CreditCard(string number, User user, string cvv, string expirationDate, Value limit) : base()
        {
            Number = number;
            User = user;
            CVV = cvv;
            ExpirationDate = expirationDate;
            Limit = limit;
        }
    }
}
