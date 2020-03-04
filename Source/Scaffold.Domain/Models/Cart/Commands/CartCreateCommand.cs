using Scaffold.Domain.Core.Commands;
using Scaffold.Domain.Models.Product;
using System;
using System.Linq.Expressions;

namespace Scaffold.Domain.Models.Cart.Commands
{
    public sealed class CartCreateCommand : Command<Guid, CartCreate, Cart>
    {
        public string customerId { get; set; }
        public CartCommandItem item { get; set; }

        public readonly CartValidator Validator;

        public CartCreateCommand(Guid id, Expression<Func<CartCreate, bool>> filter = null)
            : base(id, filter)
        {
            Validator = new CartValidator();
        }

        public CartCreateCommand(CartCommand cart)
            : this(Guid.NewGuid())
        {
            customerId = cart.customerId;
            item = cart.item;
        }

        public override bool IsValid()
        {
            Validator.ValidateCustomerId();
            Validator.ValidateItem();

            return Validate(Validator, this);
        }
    }
}
