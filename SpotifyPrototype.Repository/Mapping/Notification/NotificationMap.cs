using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyPrototype.Repository.Mapping.Notification
{
    public class NotificationMap : IEntityTypeConfiguration<SpotifyPrototype.Domain.Notification.Notification>
    {
        public void Configure(EntityTypeBuilder<SpotifyPrototype.Domain.Notification.Notification> builder)
        {
            builder.ToTable(nameof(SpotifyPrototype.Domain.Notification.Notification));

            builder.HasKey(n => n.Id);

            builder.Property(n => n.MerchantId)
                .IsRequired();

            builder.Property(n => n.Amount)
                .IsRequired();

            builder.Property(n => n.TransactionStatus)
                .IsRequired();
        }
    }
}
