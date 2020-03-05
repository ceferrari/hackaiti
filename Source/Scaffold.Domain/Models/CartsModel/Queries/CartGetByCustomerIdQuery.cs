using Scaffold.Domain.Core.Queries;
using System.Collections.Generic;

namespace Scaffold.Domain.Models.CartModel.Queries
{
    public sealed class CartGetByCustomerIdQuery : Query<Cart, List<Cart>>
    {
        public CartGetByCustomerIdQuery(string customerId)
            : base(customerId)
        {

        }
    }
}
