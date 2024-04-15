using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyPrototype.Repository.Mapping.Transacao
{
    public class TransacaoMapping : IEntityTypeConfiguration<Domain.Transacao.Aggregates.Transacao>
    {
        public void Configure(EntityTypeBuilder<Domain.Transacao.Aggregates.Transacao> builder)
        {
            builder.ToTable(nameof(Domain.Transacao.Aggregates.Transacao));

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.Data).IsRequired();
            builder.Property(x => x.Descricao).IsRequired().HasMaxLength(100);

            builder.OwnsOne(d => d.Valor, c =>
            {
                c.Property(x => x.Valor).HasColumnName("ValorTransacao").IsRequired();
            });

            builder.OwnsOne(d => d.Merchant, c =>
            {
                c.Property(x => x.Nome).HasColumnName("MerchantNome").IsRequired();
            });

        }
    }
}
