using System;
using Scaffold.Domain.Core.Events;

namespace Scaffold.Domain.Core.Notifications
{
    public class Notification : Event, INotification
    {
        public Notification(Type type, string message, int version = 1)
            : base(type, message, version)
        {
            
        }
    }
}
