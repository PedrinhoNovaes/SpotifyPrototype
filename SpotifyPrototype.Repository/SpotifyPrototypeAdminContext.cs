using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SpotifyPrototype.Domain.Admin.Aggregates;
using SpotifyPrototype.Repository.Mapping.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyPrototype.Repository
{
    public class SpotifyPrototypeAdminContext : DbContext
    {
        public DbSet<UsuarioAdmin> UsuariosAdmin { get; set; }

        public SpotifyPrototypeAdminContext(DbContextOptions<SpotifyPrototypeAdminContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UsuarioAdminMapping());
            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLoggerFactory(LoggerFactory.Create(x => x.AddConsole()));
            base.OnConfiguring(optionsBuilder);
        }
    }
}