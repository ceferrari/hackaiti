using Scaffold.Application.Results;
using Scaffold.Domain.Core.Bus;
using Scaffold.Domain.Core.Notifications;
using Scaffold.Domain.Models.Product;
using Scaffold.Domain.Models.Product.Commands;
using System.Linq;
using System.Net;

namespace Scaffold.Application.AppServices
{
    public class ProductService : AbstractService, IProductService
    {
        public ProductService(IBus bus, INotificationHandler notificationHandler)
            : base(bus, notificationHandler)
        {

        }

        public Result Create(Product product)
        {
            var command = new ProductCreateCommand(product);
            var result = Bus.Submit(command).Data;

            if (NotificationHandler.HasNotifications()) return ValidationErrorResult();

            return new SuccessResult(HttpStatusCode.Created, result);
        }
    }
}
