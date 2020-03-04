using Scaffold.Domain.Core.Queries;
using Scaffold.Domain.Core.Results;
using System.Collections.Generic;
using System.Linq;

namespace Scaffold.Domain.Models.Cart.Queries
{
    public sealed class CartGetByIdQueryHandler : QueryHandler<CartGetByIdQuery, Cart>
    {
        private readonly ICartRepository _repository;

        public CartGetByIdQueryHandler(ICartRepository repository)
        {
            _repository = repository;
        }

        public override AbstractOperationResult<Cart> Handle(CartGetByIdQuery query)
        {
            //var result = _repository.GetAllCarts().Result.ToList();
            var result = Cart.Carts.FirstOrDefault(x => query.Id.Equals(x.id.ToString()));

            return new SuccessOperationResult<Cart>(result);
        }
    }
}
