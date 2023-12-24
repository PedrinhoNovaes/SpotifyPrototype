using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyPrototype.Repository.Mapping.Transaction
{
    public class PaymentMap : IEntityTypeConfiguration<SpotifyPrototype.Domain.Transaction.Aggregates.Payment>
    {
        public void Configure(EntityTypeBuilder<SpotifyPrototype.Domain.Transaction.Aggregates.Payment> builder)
        {
            builder.ToTable(nameof(SpotifyPrototype.Domain.Transaction.Aggregates.Payment));

            builder.HasKey(p => p.Id);

            builder.HasOne(p => p.CreditCard)
                .WithMany()
                .HasForeignKey(p => p.CreditCard)
                .IsRequired();

            builder.Property(p => p.IsActive)
                .IsRequired();
        }
    }
}
