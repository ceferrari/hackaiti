using Scaffold.Domain.Core.Commands;
using Scaffold.Domain.Models.CartModel;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Scaffold.Domain.Models.CartModelModel.Commands
{
    public abstract class CartCommand : Command<Guid, Cart, Cart>
    {
        public string customerId { get; set; }
        public string status { get; set; }
        public CartEditItem item { get; set; }
        public List<CartItem> items { get; set; }

        protected readonly CartValidator Validator;

        protected CartCommand(Guid id, Expression<Func<Cart, bool>> filter = null)
            : base(id, filter)
        {
            Validator = new CartValidator();
        }

        protected CartCommand(Cart cart)
            : this(Guid.NewGuid())
        {
            customerId = cart.customerId;
            status = cart.status;
            item = cart.item;
            items = cart.items;
        }
    }
}
