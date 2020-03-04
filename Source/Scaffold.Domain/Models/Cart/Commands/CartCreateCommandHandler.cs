using Scaffold.Domain.Core.Bus;
using Scaffold.Domain.Core.Commands;
using Scaffold.Domain.Core.Results;
using Scaffold.Domain.Models.Cart;
using Scaffold.Domain.Models.Cart.Commands;

namespace Scaffold.Infra.Repositories
{
    public sealed class CartCreateCommandHandler : CommandHandler<CartCreateCommand, Cart>
    {
        private readonly ICartRepository _cartRepository;

        public CartCreateCommandHandler(IBus bus, ICartRepository cartRepository)
            : base(bus)
        {
            _cartRepository = cartRepository;
        }

        public override AbstractOperationResult<Cart> Handle(CartCreateCommand command)
        {
            if (!command.IsValid())
            {
                NotifyValidationErrors(command);
                return new FailureOperationResult<Cart>("error creating cart");
            }

            var entity = new Cart(command.Id)
            {
                customerId = command.customerId,
                status = command.status,
                item = command.item,
                items = command.items
            };

            if (Cart.Carts.Exists(x => entity.id.Equals(x.id)))
            {
                return new FailureOperationResult<Cart>("cart with specified id already exists");
            }

            Cart.Carts.Add(entity);


            //if (_cartRepository.AlreadyExists(command.Id.ToString()))
            //{
            //    return new FailureOperationResult<Cart>("cart with specified id already exists");
            //}

            //_cartRepository.AddCart(entity).Wait();

            //var py = _cartRepository.GetAllCarts().Result;

            //var px = _cartRepository.GetCart(entity.id.ToString()).Result;

            //if (Commit())
            //{
            //    return new FailureOperationResult<Cart>("error creating cart");
            //}

            return new SuccessOperationResult<Cart>("cart created", entity);
        }
    }
}
