using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyPrototype.Repository.Mapping.Transaction
{
    public class SignatureMap : IEntityTypeConfiguration<SpotifyPrototype.Domain.Transaction.Aggregates.Signature>
    {
        public void Configure(EntityTypeBuilder<SpotifyPrototype.Domain.Transaction.Aggregates.Signature> builder)
        {
            builder.ToTable(nameof(SpotifyPrototype.Domain.Transaction.Aggregates.Signature));

            builder.HasKey(s => s.Id);

            builder.Property(s => s.Validity)
                .IsRequired();

            builder.Property(s => s.Price)
                .IsRequired();
        }
    }
}
