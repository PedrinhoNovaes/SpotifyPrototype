using SpotifyPrototype.Domain.Account.Helper;
using SpotifyPrototype.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyPrototype.Domain.Account.Aggregates
{
    public class Account : Entity
    {
        private static HashSet<Guid> _existingUserIds = new HashSet<Guid>();

        public bool IsActive { get; set; }
        public string Password
        {
            get => _password;
            set => _password = EncryptionHelper.EncryptPassword(value);
        }
        private string _password;

        public Guid UserId { get; set; }
        public List<CreditCard> UserCreditCards { get; set; }
        public object User { get; set; }

        public Account()
        {
            UserId = Guid.Empty; 
            IsActive = false; 
            Password = string.Empty;
            UserCreditCards = new List<CreditCard>();
        }

        public Account(bool isActive, string password, Guid userId, List<CreditCard> userCreditCards) : base()
        {
            if (_existingUserIds.Contains(userId))
            {
                throw new InvalidOperationException("Usuário já existe em uma conta.");
            }

            IsActive = isActive;
            Password = password;
            UserId = userId;
            UserCreditCards = userCreditCards;

            _existingUserIds.Add(userId);
        }
    }
}
