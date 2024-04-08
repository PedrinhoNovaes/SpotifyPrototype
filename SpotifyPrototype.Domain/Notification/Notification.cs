using SpotifyPrototype.Domain.Account.Aggregates;
using SpotifyPrototype.Domain.Transaction.ValueObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace SpotifyPrototype.Domain.Notification
{
    public class Notification
    {
        public Guid Id { get; set; }
        public DateTime NotificationDate { get; set; }
        public string Message { get; set; }
        public string Title { get; set; }
        public virtual User DestinationUser { get; set; }
        public virtual User? SourceUser { get; set; }
        public NotificationType NotificationType { get; set; }

        public static Notification Create(string title, string message, NotificationType notificationType, User destination, User source = null)
        {
            if (notificationType == NotificationType.User && source == null)
                throw new ArgumentNullException("For 'user' type of message, you must inform the sender");

            if (string.IsNullOrWhiteSpace(title))
                throw new ArgumentNullException("Please provide the title of the notification");

            if (string.IsNullOrWhiteSpace(message))
                throw new ArgumentNullException("Please provide the message of the notification");

            return new Notification()
            {
                NotificationDate = DateTime.Now,
                Message = message,
                NotificationType = notificationType,
                Title = title,
                DestinationUser = destination,
                SourceUser = source
            };
        }
    }

    public enum NotificationType
    {
        User = 1,
        System = 2
    }
}