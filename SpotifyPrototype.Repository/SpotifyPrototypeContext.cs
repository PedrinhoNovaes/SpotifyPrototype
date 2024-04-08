using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SpotifyPrototype.Domain.Account.Aggregates;
using SpotifyPrototype.Domain.Notification;
using SpotifyPrototype.Domain.Streaming.Aggregates;
using SpotifyPrototype.Domain.Transaction.Aggregates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyPrototype.Repository
{
    public class SpotifyPrototypeContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Signature> Signatures { get; set; }
        public DbSet<Playlist> Playlists { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<Card> Cards { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<Band> Bands { get; set; }
        public DbSet<Album> Albuns { get; set; }
        public DbSet<Song> Songs{ get; set; }

        public SpotifyPrototypeContext(DbContextOptions<SpotifyPrototypeContext> options) : base(options)
        {

        }


        //Escrever protected internal e vai aparecer OnModelCreating
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(SpotifyPrototypeContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}