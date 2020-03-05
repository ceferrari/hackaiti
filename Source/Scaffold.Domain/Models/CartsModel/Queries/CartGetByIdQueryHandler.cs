using Scaffold.Domain.Core.Queries;
using Scaffold.Domain.Core.Results;
using Scaffold.Domain.Models.CartModel.Repositories;

namespace Scaffold.Domain.Models.CartModel.Queries
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
            var result = _repository.GetById(query.Id.ToString()).Result;

            return new SuccessOperationResult<Cart>(result);
        }
    }
}
