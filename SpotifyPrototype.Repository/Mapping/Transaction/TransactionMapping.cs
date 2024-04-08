using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using SpotifyPrototype.Domain.Core.ValueObject;
using SpotifyPrototype.Domain.Transaction.ValueObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyPrototype.Repository.Mapping.Transaction
{
    public class TransactionMapping : IEntityTypeConfiguration<Domain.Transaction.Aggregates.Transaction>
    {
        public void Configure(EntityTypeBuilder<Domain.Transaction.Aggregates.Transaction> builder)
        {
            builder.ToTable(nameof(Domain.Transaction.Aggregates.Transaction));

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.TransactionDate).IsRequired();
            builder.Property(x => x.Description).IsRequired().HasMaxLength(50);

            builder.OwnsOne<Merchant>(d => d.Merchant, c =>
            {
                c.Property(x => x.Name).HasColumnName("MerchantName").IsRequired();
            });

            builder.OwnsOne<Monetary>(d => d.Value, c =>
            {
                c.Property(x => x.Value).HasColumnName("TransactionValue").IsRequired();
            });
        }
    }

}
