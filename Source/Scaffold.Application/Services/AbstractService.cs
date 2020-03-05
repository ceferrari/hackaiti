using Scaffold.Application.Results;
using Scaffold.Domain.Core.Bus;
using Scaffold.Domain.Core.Notifications;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace Scaffold.Application.Services
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
        public AbstractApiResult ValidationErrorResult() => new FailureApiResult(HttpStatusCode.BadRequest,  GetNotifications());
    }
}
