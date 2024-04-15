using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SpotifyPrototype.Domain.Conta.Aggregates;
using SpotifyPrototype.Domain.Notificacao.Aggregates;
using SpotifyPrototype.Domain.Streaming.Aggregates;
using SpotifyPrototype.Domain.Transacao.Aggregates;
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
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Assinatura> Assinaturas { get; set; }
        public DbSet<Playlist> Playlists { get; set; }
        public DbSet<Notificacao> Notificacoes { get; set; }
        public DbSet<Cartao> Cartoes { get; set; }
        public DbSet<Transacao> Transacao { get; set; }
        public DbSet<Interprete> Interpretes { get; set; }
        public DbSet<EstiloMusical> EstilosMusicais { get; set; }
        public DbSet<Autor> Autores { get; set; }
        public DbSet<Album> Albuns { get; set; }
        public DbSet<Musica> Musicas { get; set; }
        public DbSet<Plano> Planos { get; set; }

        public SpotifyPrototypeContext(DbContextOptions<SpotifyPrototypeContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(SpotifyPrototypeContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLoggerFactory(LoggerFactory.Create(x => x.AddConsole()));
            base.OnConfiguring(optionsBuilder);
        }
    }
}