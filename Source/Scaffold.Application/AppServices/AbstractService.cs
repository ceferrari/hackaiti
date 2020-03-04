using Scaffold.Application.Results;
using Scaffold.Domain.Core.Bus;
using Scaffold.Domain.Core.Notifications;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace Scaffold.Application.AppServices
{
    public abstract class AbstractService
    {
        protected readonly IBus Bus;
        protected readonly INotificationHandler NotificationHandler;

        public AbstractService(IBus bus, INotificationHandler notificationHandler)
        {
            Bus = bus;
            NotificationHandler = notificationHandler;
        }

        public IList<string> GetNotifications() => NotificationHandler.Notifications.Select(x => x.Message).ToList();
        public Result ValidationErrorResult() => new FailureResult(HttpStatusCode.BadRequest, "validation error(s)", GetNotifications());
    }
}
