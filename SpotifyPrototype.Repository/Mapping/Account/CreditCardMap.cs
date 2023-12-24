using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SpotifyPrototype.Domain.Account.Aggregates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyPrototype.Repository.Mapping.Account
{
    public class CreditCardMap : IEntityTypeConfiguration<SpotifyPrototype.Domain.Account.Aggregates.CreditCard>
    {
        public void Configure(EntityTypeBuilder<SpotifyPrototype.Domain.Account.Aggregates.CreditCard> builder)
        {
            builder.ToTable("CreditCards");

            builder.HasKey(cc => cc.Id);

            builder.Property(cc => cc.Number)
                .IsRequired();

            builder.Property(cc => cc.CVV)
                .IsRequired();

            builder.Property(cc => cc.ExpirationDate)
                .IsRequired();

            builder.HasOne(cc => cc.Account);
        }
    }
}
