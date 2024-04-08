using SpotifyPrototype.Domain.Account.Aggregates;
using SpotifyPrototype.Domain.Streaming.Aggregates;
using SpotifyPrototype.Domain.Transaction.Aggregates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace SpotifyPrototype.Tests.Domain
{
    public class UserTest
    {
        [Fact]
        public void ShouldCreateUserSuccessfully()
        {
            Plan plan = new Plan()
            {
                Description = "Lorem ipsum",
                Id = Guid.NewGuid(),
                Name = "Dummy Plan",
                Value = 19.90M
            };

            Card card = new Card()
            {
                Id = Guid.NewGuid(),
                Active = true,
                Limit = 1000M,
                Number = "6465465466",
            };

            string name = "Dummy User";
            string email = "test@test.com";
            string password = "123456";

            //Act
            User user = new User();
            user.CreateAccount(name, email, password, DateTime.Now, plan, card);

            //Assert
            Assert.NotNull(user.Email);
            Assert.NotNull(user.Name);
            Assert.True(user.Email == email);
            Assert.True(user.Name == name);
            Assert.True(user.Password != password);

            Assert.True(user.Signatures.Count > 0);
            Assert.Same(user.Signatures[0].Plan, plan);

            Assert.True(user.Cards.Count > 0);
            Assert.Same(user.Cards[0], card);

            Assert.True(user.Playlists.Count > 0);
            Assert.True(user.Playlists[0].Name == "Favorites");
            Assert.False(user.Playlists[0].Public);
        }

        [Fact]
        public void ShouldNotCreateUserWithCardWithoutLimit()
        {
            Plan plan = new Plan()
            {
                Description = "Lorem ipsum",
                Id = Guid.NewGuid(),
                Name = "Dummy Plan",
                Value = 19.90M
            };

            Card card = new Card()
            {
                Id = Guid.NewGuid(),
                Active = true,
                Limit = 10M,
                Number = "6465465466",
            };

            string name = "Dummy User";
            string email = "test@test.com";
            string password = "123456";

            //Act & Assert
            Assert.Throws<Exception>(() =>
            {
                User user = new User();
                user.CreateAccount(name, email, password, DateTime.Now, plan, card);
            });
        }
    }

}
