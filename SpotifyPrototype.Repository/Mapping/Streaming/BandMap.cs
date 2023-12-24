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
    public class BandMap : IEntityTypeConfiguration<Band>
    {
        public void Configure(EntityTypeBuilder<Band> builder)
        {
            builder.ToTable(nameof(Band));

            builder.HasKey(b => b.Id);

            builder.Property(b => b.Name)
                .IsRequired();

            builder.Property(b => b.Genre)
                .IsRequired();

            builder.Property(b => b.Avatar)
                .IsRequired();

            builder.Property(b => b.Description)
                .IsRequired();

            
            builder.HasMany(b => b.Albums)
                .WithOne()
                .HasForeignKey("BandId")
                .OnDelete(DeleteBehavior.Cascade); 
        }
    }
}
