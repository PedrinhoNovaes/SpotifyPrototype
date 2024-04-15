﻿using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using SpotifyPrototype.Domain.Conta.Aggregates;
using SpotifyPrototype.Domain.Streaming.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyPrototype.Repository.Mapping.Conta
{
    public class UsuarioMapping : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable(nameof(Usuario));

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.Nome).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Email).IsRequired().HasMaxLength(150);
            builder.Property(x => x.Senha).IsRequired().HasMaxLength(100);
            builder.Property(x => x.DataNascimento).IsRequired();

            builder.HasMany(x => x.Cartoes).WithOne();
            builder.HasMany(x => x.Assinaturas).WithOne();
            builder.HasMany(x => x.Playlists).WithOne(x => x.Autor);
        }
    }
}
