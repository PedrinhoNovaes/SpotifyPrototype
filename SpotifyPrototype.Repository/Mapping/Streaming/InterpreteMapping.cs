using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using SpotifyPrototype.Domain.Streaming.Aggregates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyPrototype.Repository.Mapping.Streaming
{
    public class InterpreteMapping : IEntityTypeConfiguration<Interprete>
    {
        public void Configure(EntityTypeBuilder<Interprete> builder)
        {
            builder.ToTable(nameof(Interprete));

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.Nome).IsRequired().HasMaxLength(50);
        }
    }
}
