using Scaffold.Domain.Core.Queries;
using System.Collections.Generic;

namespace Scaffold.Domain.Models.Cart.Queries
{
    public sealed class CartGetByIdQuery : Query<Cart, List<Cart>>
    {
        public CartGetByIdQuery(object id = null)
            : base(id)
        {

        }
    }
}
