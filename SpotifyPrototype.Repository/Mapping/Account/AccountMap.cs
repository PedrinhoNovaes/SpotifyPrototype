using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyPrototype.Repository.Mapping.Account
{
    public class AccountMap : IEntityTypeConfiguration<SpotifyPrototype.Domain.Account.Aggregates.Account>
    {
        public void Configure(EntityTypeBuilder<SpotifyPrototype.Domain.Account.Aggregates.Account> builder)
        {
            builder.ToTable(nameof(SpotifyPrototype.Domain.Account.Aggregates.Account));

            builder.HasKey(a => a.Id);

            builder.Property(a => a.IsActive)
                .IsRequired();

            builder.Property(a => a.Password)
                .IsRequired();

            builder.HasOne(a => a.User)
                .WithOne()
                .HasForeignKey<SpotifyPrototype.Domain.Account.Aggregates.User>(u => u.AccountId)
                .IsRequired();

            object value = builder.HasMany(a => a.UserCreditCards)
                .WithOne()
                .HasForeignKey(cc => cc.AccountId)
                .IsRequired();
        }
    }
}
