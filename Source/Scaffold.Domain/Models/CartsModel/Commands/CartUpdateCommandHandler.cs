using Scaffold.Domain.Core.Bus;
using Scaffold.Domain.Core.Commands;
using Scaffold.Domain.Core.Results;
using Scaffold.Domain.Models.CartModel;
using Scaffold.Domain.Models.CartModel.Commands;
using Scaffold.Domain.Models.CartModel.Repositories;
using Scaffold.Domain.Models.ProductModel.Repositories;
using System.Collections.Generic;

namespace Scaffold.Infra.Repositories
{
    public sealed class CartUpdateCommandHandler : CommandHandler<CartUpdateCommand, Cart>
    {
        private readonly ICartRepository _cartRepository;
        private readonly IProductRepository _productRepository;

        public CartUpdateCommandHandler(IBus bus, ICartRepository cartRepository, IProductRepository productRepository)
            : base(bus)
        {
            _cartRepository = cartRepository;
            _productRepository = productRepository;
        }

        public override AbstractOperationResult<Cart> Handle(CartUpdateCommand command)
        {
            if (!command.IsValid())
            {
                NotifyValidationErrors(command);
                return new FailureOperationResult<Cart>("error updating cart");
            }

            if (_cartRepository.ExistsByCustomerId(command.customerId))
            {
                return new FailureOperationResult<Cart>("cart already exists for the specified customer");
            }

            if (!_productRepository.ExistsBySku(command.item.sku))
            {
                return new FailureOperationResult<Cart>("product with specified sku does not exists");
            }

            var product = _productRepository.GetBySku(command.item.sku).Result;
            var item = new CartItem(product);

            // TODO: alterar para bater no worker e fazer o calculo correto
            item.price = command.item.quantity * product.price.amount;

            var entity = new Cart(command.id)
            {
                customerId = command.customerId,
                status = "PENDING",
                item = command.item,
                items = new List<CartItem>() { item }
            };

            _cartRepository.Add(entity).Wait();

            var py = _cartRepository.GetAll().Result;
            var px = _cartRepository.GetByCustomerId(entity.customerId).Result;

            return new SuccessOperationResult<Cart>("cart created", entity);
        }
    }
}
