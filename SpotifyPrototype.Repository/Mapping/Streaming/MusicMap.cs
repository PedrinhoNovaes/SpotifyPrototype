using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SpotifyPrototype.Domain.Streaming.Aggregates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyPrototype.Repository.Mapping.Streaming
{
    public class MusicMap : IEntityTypeConfiguration<Music>
    {
        public void Configure(EntityTypeBuilder<Music> builder)
        {
            builder.ToTable(nameof(Music));

            builder.HasKey(m => m.Id); 

            builder.Property(m => m.Name)
                .IsRequired(); 

            builder.Property(m => m.Lyrics)
                .IsRequired(); 

           
            builder.Property(m => m.DurationInSeconds)
                .IsRequired()
                .HasColumnName("DurationInSeconds"); 
        }
    }
}
