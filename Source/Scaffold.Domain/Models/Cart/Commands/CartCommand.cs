using Scaffold.Domain.Core.Commands;
using Scaffold.Domain.Models.Product;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Scaffold.Domain.Models.Cart.Commands
{
    public abstract class CartCommand : Command<Guid, Cart, Cart>
    {
        public string customerId { get; set; }
        public CartCommandItem item { get; set; }

        protected readonly CartValidator Validator;

        protected CartCommand(Guid id, Expression<Func<Cart, bool>> filter = null)
            : base(id, filter)
        {
            Validator = new CartValidator();
        }

        protected CartCommand(CartCommand cart)
            : this(Guid.NewGuid())
        {
            customerId = cart.customerId;
            item = cart.item;
        }
    }
}
