using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using SpotifyPrototype.Domain.Conta.Aggregates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpotifyPrototype.Domain.Streaming.ValueObjects;

namespace SpotifyPrototype.Repository.Mapping.Conta
{
    public class AssinaturaMapping : IEntityTypeConfiguration<Assinatura>
    {
        public void Configure(EntityTypeBuilder<Assinatura> builder)
        {
            builder.ToTable(nameof(Assinatura));

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.Status).IsRequired();
            builder.HasOne(x => x.Plano).WithMany();

            builder.OwnsOne<Periodo>(x => x.Vigencia, c =>
            {
                c.Property(x => x.Inicio).HasColumnName("PeriodoInicio").IsRequired();
                c.Property(x => x.Fim).HasColumnName("PeriodoFim").IsRequired();
            });
        }
    }
}
