using Scaffold.Domain.Core.Commands;
using Scaffold.Domain.Models.Product;
using System;
using System.Linq.Expressions;

namespace Scaffold.Domain.Models.Cart.Commands
{
    public sealed class CartDeleteCommand : Command<Guid, Cart, Cart>
    {public readonly CartValidator Validator;

        public CartDeleteCommand(Guid id)
            : base(id)
        {
            Validator = new CartValidator();
        }

        public override bool IsValid()
        {
            Validator.ValidateId();

            return Validate(Validator, this);
        }
    }
}
