using SpotifyPrototype.Domain.Core.Extension;
using SpotifyPrototype.Domain.Core.ValueObject;
using SpotifyPrototype.Domain.Streaming.Aggregates;
using SpotifyPrototype.Domain.Transaction.Aggregates;
using SpotifyPrototype.Domain.Transaction.ValueObject;

namespace SpotifyPrototype.Domain.Account.Aggregates
{
    public class User
    {
        private const string PLAYLIST_NAME = "Favorites";

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime BirthDate { get; set; }
        public virtual IList<Card> Cards { get; set; } = new List<Card>();
        public virtual IList<Signature> Signatures { get; set; } = new List<Signature>();
        public virtual IList<Playlist> Playlists { get; set; } = new List<Playlist>();
        public virtual IList<Notification.Notification> Notifications { get; set; } = new List<Notification.Notification>();

        public void CreateAccount(string name, string email, string password, DateTime birthDate, Plan plan, Card card)
        {
            this.Name = name;
            this.Email = email;
            this.BirthDate = birthDate;

            // Encrypt the password
            this.Password = this.EncryptPassword(password);

            // Subscribe to a plan
            this.SubscribeToPlan(plan, card);

            // Add card to user's account
            this.AddCard(card);

            // Create user's default playlist
            this.CreatePlaylist(name: PLAYLIST_NAME, publicPlaylist: false);
        }

        public void CreatePlaylist(string name, bool publicPlaylist = true)
        {
            this.Playlists.Add(new Playlist()
            {
                Name = name,
                Public = publicPlaylist,
                CreationDate = DateTime.Now,
                User = this
            });
        }

        private void AddCard(Card card)
        {
            this.Cards.Add(card);
        }

        private void SubscribeToPlan(Plan plan, Card card)
        {
            // Debit the plan value from the card
            card.CreateTransaction(new Merchant() { Name = plan.Name }, new Monetary(plan.Value), plan.Description);

            // Deactivate if there's any active account
            DeactivateActiveAccount();

            // Add a new account
            this.Signatures.Add(new Signature()
            {
                Active = true,
                Plan = plan,
                ActivationDate = DateTime.Now,
            });
        }

        private void DeactivateActiveAccount()
        {
            // If there's any active account, deactivate it
            if (this.Signatures.Count > 0 && this.Signatures.Any(x => x.Active))
            {
                var activePlan = this.Signatures.FirstOrDefault(x => x.Active);
                activePlan.Active = false;
            }
        }

        private string EncryptPassword(string password)
        {
            return password.HashSHA256();
        }
    }

}
