using Scaffold.Application.Results;
using Scaffold.Domain.Core.Bus;
using Scaffold.Domain.Core.Notifications;
using Scaffold.Domain.Models.Product;
using Scaffold.Domain.Models.Product.Commands;
using Scaffold.Domain.Models.Product.Queries;
using System.Collections.Generic;
using System.Net;

namespace Scaffold.Application.AppServices
{
    public class ProductService : AbstractService, IProductService
    {
        public ProductService(IBus bus, INotificationHandler notificationHandler)
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

        public Result Create(Product product)
        {
            var command = new ProductCreateCommand(product);
            var result = Bus.Submit(command);

            if (NotificationHandler.HasNotifications()) return ValidationErrorResult();

            return result.Success
                ? (Result)new SuccessResult(HttpStatusCode.Created, result.Data)
                : (Result)new FailureResult(HttpStatusCode.BadRequest, result.Message);
        }
    }
}
