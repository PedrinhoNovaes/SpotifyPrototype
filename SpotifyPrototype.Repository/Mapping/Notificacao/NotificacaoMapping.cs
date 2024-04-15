using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyPrototype.Repository.Mapping.Notificacao
{
    public class NotificacaoMapping : IEntityTypeConfiguration<SpotifyPrototype.Domain.Notificacao.Aggregates.Notificacao>
    {
        public void Configure(EntityTypeBuilder<SpotifyPrototype.Domain.Notificacao.Aggregates.Notificacao> builder)
        {
            builder.ToTable(nameof(SpotifyPrototype.Domain.Notificacao.Aggregates.Notificacao));

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.Titulo).IsRequired().HasMaxLength(150);
            builder.Property(x => x.Mensagem).IsRequired().HasMaxLength(250);
            builder.Property(x => x.Data).IsRequired();
            builder.Property(x => x.TipoNotificacao).IsRequired();

            builder.HasOne(x => x.Destinatario).WithMany(x => x.Notificacoes).IsRequired().OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(x => x.Remetente).WithMany().IsRequired(false);
        }
    }
}
