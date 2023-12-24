using SpotifyPrototype.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyPrototype.Domain.Account.Aggregates
{
    public class User : Entity
    {
        private static HashSet<string> _existingEmails = new HashSet<string>();
        private static HashSet<string> _existingCPFs = new HashSet<string>();
        public readonly object CreditCards;

        public string Username { get; set; }
        public string CPF { get; set; }
        public DateTime BirthDate { get; set; }
        public string Avatar { get; set; }
        public string Email { get; set; }
        public object AccountId { get; set; }
        public object CreditCard { get; set; }

        public User()
        {
            Avatar = string.Empty;
        }

        public User(string username, string cpf, DateTime birthDate, string avatar, string email) : base()
        {
            if (_existingEmails.Contains(email))
            {
                throw new InvalidOperationException("Este email já está cadastrado.");
            }

            if (_existingCPFs.Contains(cpf))
            {
                throw new InvalidOperationException("Este CPF já está cadastrado.");
            }

            Username = username;
            CPF = cpf;
            BirthDate = birthDate;
            Avatar = avatar;
            Email = email;

            _existingEmails.Add(email);
            _existingCPFs.Add(cpf);
        }
    }
}
