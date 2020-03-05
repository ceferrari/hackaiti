using Scaffold.Domain.Core.Queries;

namespace Scaffold.Domain.Models.CartModel.Queries
{
    public sealed class CartGetByIdQuery : Query<Cart, Cart>
    {
        public CartGetByIdQuery(string id)
            : base(id)
        {

        }
    }
}
