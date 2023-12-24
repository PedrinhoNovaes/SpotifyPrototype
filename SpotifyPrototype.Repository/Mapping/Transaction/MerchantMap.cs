using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyPrototype.Repository.Mapping.Transaction
{
    public class MerchantMap : IEntityTypeConfiguration<SpotifyPrototype.Domain.Transaction.ValueObject.Merchant>
    {
        public void Configure(EntityTypeBuilder<SpotifyPrototype.Domain.Transaction.ValueObject.Merchant> builder)
        {
            builder.ToTable(nameof(SpotifyPrototype.Domain.Transaction.ValueObject.Merchant));

            builder.HasKey(m => m.Id);

            builder.Property(m => m.Name)
                .IsRequired();

            builder.Property(m => m.CNPJ)
                .IsRequired();

            builder.Property(m => m.Price)
                .IsRequired();
        }
    }
}