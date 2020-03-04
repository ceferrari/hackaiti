using System.Collections.Generic;
using System.Linq;

namespace Scaffold.Domain.Core.Notifications
{
    public class NotificationHandler : INotificationHandler
    {
        public List<Notification> Notifications { get; }

        public NotificationHandler()
        {
            Notifications = new List<Notification>();
        }

        public void Handle(Notification notification)
        {
            Notifications.Add(notification);
        }

        public bool HasNotifications()
        {
            return Notifications.Any();
        }

        public void Dispose()
        {
            Notifications.Clear();
        }
    }
}
