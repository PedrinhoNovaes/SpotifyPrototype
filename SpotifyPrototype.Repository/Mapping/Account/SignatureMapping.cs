using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpotifyPrototype.Domain.Account.Aggregates;

namespace SpotifyPrototype.Repository.Mapping.Account
{
    public class SignatureMapping : IEntityTypeConfiguration<Signature>
    {
        public void Configure(EntityTypeBuilder<Signature> builder)
        {
            builder.ToTable(nameof(Signature));

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.Active).IsRequired();
            builder.Property(x => x.ActivationDate).IsRequired();

            builder.HasOne(x => x.Plan).WithMany();
        }
    }
}
