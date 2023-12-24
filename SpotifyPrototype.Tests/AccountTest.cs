using SpotifyPrototype.Domain.Account.Aggregates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace SpotifyPrototype.Tests
{
    public class AccountTests
    {
        [Fact]
        public void Account_Should_Only_Accept_One_User()
        {
            // Arrange
            var account = new Account();
            var user1 = new object(); // Simulated user object
            var user2 = new object(); // Another simulated user object

            // Act
            account.User = user1;

            // Assert
            Assert.NotNull(account.User);
            Assert.Same(user1, account.User);

            // Try assigning a second user to the same account
            var exception = Record.Exception(() => account.User = user2);

            // Assert
            Assert.NotNull(account.User); // User should not change if assignment fails
            Assert.Same(user1, account.User); // User should remain as the first assigned user
            Assert.IsType<InvalidOperationException>(exception); // Check for the specific exception type
            Assert.Equal("Usuário já existe em uma conta.", exception.Message); // Check exception message
        }
    }
}
