using Scaffold.Domain.Core.Queries;
using Scaffold.Domain.Core.Results;
using Scaffold.Domain.Models.CartModel.Repositories;

namespace Scaffold.Domain.Models.CartModel.Queries
{
    public sealed class CartGetByCustomerIdQueryHandler : QueryHandler<CartGetByCustomerIdQuery, Cart>
    {
        private readonly ICartRepository _repository;

        public CartGetByCustomerIdQueryHandler(ICartRepository repository)
        {
            _repository = repository;
        }

        public override AbstractOperationResult<Cart> Handle(CartGetByCustomerIdQuery query)
        {
            var result = _repository.GetByCustomerId(query.Id.ToString()).Result;

            return new SuccessOperationResult<Cart>(result);
        }
    }
}
