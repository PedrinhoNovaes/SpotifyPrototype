﻿using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using SpotifyPrototype.Domain.Core.ValueObject;
using SpotifyPrototype.Domain.Streaming.Aggregates;
using SpotifyPrototype.Domain.Streaming.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyPrototype.Repository.Mapping.Streaming
{
    public class PlanoMapping : IEntityTypeConfiguration<Plano>
    {
        public void Configure(EntityTypeBuilder<Plano> builder)
        {
            builder.ToTable(nameof(Plano));

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.Nome).IsRequired().HasMaxLength(50);
            builder.Property(x => x.Descricao).IsRequired().HasMaxLength(1024);

            builder.OwnsOne<Monetario>(x => x.Valor, c =>
            {
                c.Property(x => x.Valor).IsRequired();
            });

            builder.OwnsOne<Periodo>(x => x.Vigencia, c =>
            {
                c.Property(x => x.Inicio).HasColumnName("PeriodoInicio").IsRequired();
                c.Property(x => x.Fim).HasColumnName("PeriodoFim").IsRequired();
            });
        }
    }
}
