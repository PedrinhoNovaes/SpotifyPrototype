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
    public class AutorMapping : IEntityTypeConfiguration<Autor>
    {
        public void Configure(EntityTypeBuilder<Autor> builder)
        {
            builder.ToTable(nameof(Autor));
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.Nome).IsRequired().HasMaxLength(50);
            builder.Property(x => x.Descricao).HasMaxLength(500);
            builder.Property(x => x.Backdrop).HasMaxLength(500);
        }
    }
}
