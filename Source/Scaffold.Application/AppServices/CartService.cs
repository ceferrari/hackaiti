using Scaffold.Application.Results;
using Scaffold.Domain.Core.Bus;
using Scaffold.Domain.Core.Notifications;
using Scaffold.Domain.Models.Cart;
using Scaffold.Domain.Models.Cart.Commands;
using Scaffold.Domain.Models.Product.Queries;
using System;
using System.Net;

namespace Scaffold.Application.AppServices
{
    public class CartService : AbstractService, ICartService
    {
        public CartService(IBus bus, INotificationHandler notificationHandler)
            : base(bus, notificationHandler)
        {

        }

        public Result Get(object id)
        {
            var query = new ProductGetQuery(id);
            var result = Bus.Request(query);

            if (NotificationHandler.HasNotifications()) return ValidationErrorResult();

            return result.Success
                ? (Result)new SuccessResult(HttpStatusCode.OK, result.Data)
                : (Result)new FailureResult(HttpStatusCode.BadRequest, result.Message);
        }

        public Result Create(Cart cartCreate)
        {
            var command = new CartCreateCommand(cartCreate);
            var result = Bus.Submit(command);

            if (NotificationHandler.HasNotifications()) return ValidationErrorResult();

            return result.Success
                ? (Result)new SuccessResult(HttpStatusCode.Created, result.Data)
                : (Result)new FailureResult(HttpStatusCode.BadRequest, result.Message);
        }

        public Result Delete(Guid id)
        {
            var command = new CartDeleteCommand(id);
            var result = Bus.Submit(command);

            if (NotificationHandler.HasNotifications()) return ValidationErrorResult();

            return result.Success
                ? (Result)new SuccessResult(HttpStatusCode.NoContent, result.Data)
                : (Result)new FailureResult(HttpStatusCode.BadRequest, result.Message);
        }
    }
}
