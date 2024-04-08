using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using SpotifyPrototype.Domain.Core.ValueObject;
using SpotifyPrototype.Domain.Transaction.Aggregates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyPrototype.Repository.Mapping.Transaction
{
    public class CardMapping : IEntityTypeConfiguration<Card>
    {
        public void Configure(EntityTypeBuilder<Card> builder)
        {
            builder.ToTable(nameof(Card));

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.Active).IsRequired();
            builder.Property(x => x.Number).IsRequired().HasMaxLength(100);

            builder.OwnsOne<Monetary>(d => d.Limit, c =>
            {
                c.Property(x => x.Value).HasColumnName("Limit").IsRequired();
            });

            builder.HasMany(x => x.Transactions).WithOne();
        }
    }

}
