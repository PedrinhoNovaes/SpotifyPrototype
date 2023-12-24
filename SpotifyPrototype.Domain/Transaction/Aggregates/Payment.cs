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
    public class Payment : Entity
    {
        public CreditCard CreditCard { get; set; }
        public Value CardLimit { get; set; }
        public bool IsActive { get; set; }

        public Payment()
        {
            CreditCard = new CreditCard();
            CardLimit = new Value(0); 
        }

        public Payment(CreditCard creditCard, Value cardLimit, bool isActive) : base()
        {
            CreditCard = creditCard;
            CardLimit = cardLimit;
            IsActive = isActive;
        }
    }
}
