using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyPrototype.Repository.Mapping.Notification
{
    public class NotificationMapping : IEntityTypeConfiguration<SpotifyPrototype.Domain.Notification.Notification>
    {
        public void Configure(EntityTypeBuilder<Domain.Notification.Notification> builder)
        {
            builder.ToTable(nameof(Domain.Notification.Notification));

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.Title).IsRequired().HasMaxLength(150);
            builder.Property(x => x.Message).IsRequired().HasMaxLength(250);
            builder.Property(x => x.NotificationDate).IsRequired();
            builder.Property(x => x.NotificationType).IsRequired();

            builder.HasOne(x => x.DestinationUser).WithMany(x => x.Notifications).IsRequired().OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(x => x.SourceUser).WithMany().IsRequired(false);

        }
    }

}
