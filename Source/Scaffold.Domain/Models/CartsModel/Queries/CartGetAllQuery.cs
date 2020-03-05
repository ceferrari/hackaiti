using Scaffold.Domain.Core.Queries;
using System.Collections.Generic;

namespace Scaffold.Domain.Models.CartModel.Queries
{
    public sealed class CartGetAllQuery : Query<Cart, List<Cart>>
    {
        public CartGetAllQuery()
            : base(null)
        {

        }
    }
}
