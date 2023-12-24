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
    public class AlbumMap : IEntityTypeConfiguration<Album>
    {
        public void Configure(EntityTypeBuilder<Album> builder)
        {
            builder.ToTable(nameof(Album)); 

            builder.HasKey(x => x.Id); 

            builder.Property(x => x.Name)
                .IsRequired(); 

            builder.Property(x => x.Avatar)
                .IsRequired(); 

            builder.Property(x => x.Description)
                .IsRequired(); 
        }
    }
}