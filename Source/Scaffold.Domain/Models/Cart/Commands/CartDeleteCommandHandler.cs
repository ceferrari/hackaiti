using Scaffold.Domain.Core.Bus;
using Scaffold.Domain.Core.Commands;
using Scaffold.Domain.Core.Results;
using Scaffold.Domain.Models.Cart;
using Scaffold.Domain.Models.Cart.Commands;

namespace Scaffold.Infra.Repositories
{
    public sealed class CartDeleteCommandHandler : CommandHandler<CartDeleteCommand, Cart>
    {
        private readonly ICartRepository _cartRepository;

        public CartDeleteCommandHandler(IBus bus, ICartRepository cartRepository)
            : base(bus)
        {
            _cartRepository = cartRepository;
        }

        public override AbstractOperationResult<Cart> Handle(CartDeleteCommand command)
        {
            if (!command.IsValid())
            {
                NotifyValidationErrors(command);
                return new FailureOperationResult<Cart>("error deleting cart");
            }

            if (!_cartRepository.AlreadyExists(command.Id.ToString()))
            {
                return new FailureOperationResult<Cart>("cart with specified id does not exists");
            }

            //_cartRepository.AddCart(entity).Wait();

            //var py = _cartRepository.GetAllCarts().Result;

            //var px = _cartRepository.GetCart(entity.id).Result;

            //if (Commit())
            //{
            //    return new FailureOperationResult<Cart>("error creating cart");
            //}

            return new SuccessOperationResult<Cart>("cart deleted");
        }
    }
}
