using Scaffold.Application.Results;
using Scaffold.Domain.Core.Bus;
using Scaffold.Domain.Core.Notifications;
using Scaffold.Domain.Models.CartModel;
using Scaffold.Domain.Models.CartModel.Commands;
using Scaffold.Domain.Models.CartModel.Queries;
using System.Net;

namespace Scaffold.Application.Services
{
    public class CartService : AbstractService, ICartService
    {
        public CartService(IBus bus, INotificationHandler notificationHandler)
            : base(bus, notificationHandler)
        {

        }

        public AbstractApiResult GetAll()
        {
            var query = new CartGetAllQuery();
            var result = Bus.Request(query);

            if (NotificationHandler.HasNotifications()) return ValidationErrorResult();

            return result.Success
                ? (AbstractApiResult)new SuccessApiResult(HttpStatusCode.OK, result.Data)
                : (AbstractApiResult)new FailureApiResult(HttpStatusCode.BadRequest, result.Message);
        }

        public AbstractApiResult GetById(string id)
        {
            var query = new CartGetByIdQuery(id);
            var result = Bus.Request(query);

            if (NotificationHandler.HasNotifications()) return ValidationErrorResult();

            return result.Success
                ? (AbstractApiResult)new SuccessApiResult(HttpStatusCode.OK, result.Data)
                : (AbstractApiResult)new FailureApiResult(HttpStatusCode.BadRequest, result.Message);
        }

        public AbstractApiResult GetByCustomerId(string customerId)
        {
            var query = new CartGetByCustomerIdQuery(customerId);
            var result = Bus.Request(query);

            if (NotificationHandler.HasNotifications()) return ValidationErrorResult();

            return result.Success
                ? (AbstractApiResult)new SuccessApiResult(HttpStatusCode.OK, result.Data)
                : (AbstractApiResult)new FailureApiResult(HttpStatusCode.BadRequest, result.Message);
        }

        public AbstractApiResult Create(Cart cartCreate)
        {
            var command = new CartCreateCommand(cartCreate);
            var result = Bus.Submit(command);

            if (NotificationHandler.HasNotifications()) return ValidationErrorResult();

            return result.Success
                ? (AbstractApiResult)new SuccessApiResult(HttpStatusCode.Created, result.Data)
                : (AbstractApiResult)new FailureApiResult(HttpStatusCode.BadRequest, result.Message);
        }

        public AbstractApiResult Update(string id, CartEditItem item)
        {
            var command = new CartUpdateCommand(id, item);
            var result = Bus.Submit(command);

            if (NotificationHandler.HasNotifications()) return ValidationErrorResult();

            return result.Success
                ? (AbstractApiResult)new SuccessApiResult(HttpStatusCode.OK, result.Data)
                : (AbstractApiResult)new FailureApiResult(HttpStatusCode.BadRequest, result.Message);
        }

        public AbstractApiResult Delete(string id)
        {
            var command = new CartDeleteCommand(id);
            var result = Bus.Submit(command);

            if (NotificationHandler.HasNotifications()) return ValidationErrorResult();

            return result.Success
                ? (AbstractApiResult)new SuccessApiResult(HttpStatusCode.NoContent, result.Data)
                : (AbstractApiResult)new FailureApiResult(HttpStatusCode.BadRequest, result.Message);
        }
    }
}
