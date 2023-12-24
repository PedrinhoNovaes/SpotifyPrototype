using SpotifyPrototype.Domain.Account.Aggregates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace SpotifyPrototype.Tests
{
    public class UserTests
    {
        [Theory]
        [InlineData("12345678900")]
        [InlineData("98765432100")]
        public void User_Should_Accept_Valid_CPF(string cpf)
        {
            var user = new User();
            user.CPF = cpf;
            Assert.Equal(cpf, user.CPF);
        }

        [Theory]
        [InlineData("user@example.com")]
        [InlineData("anotheruser@gmail.com")]
        public void User_Should_Accept_Valid_Email(string email)
        {
            var user = new User();
            user.Email = email;
            Assert.Equal(email, user.Email);
        }
    }
}
