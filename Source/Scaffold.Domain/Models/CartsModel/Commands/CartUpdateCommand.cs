using Scaffold.Domain.Models.CartModelModel.Commands;
using System;

namespace Scaffold.Domain.Models.CartModel.Commands
{
    public sealed class CartUpdateCommand : CartCommand
    {
        public CartUpdateCommand(string id, CartEditItem item)
            : base(Guid.Parse(id))
        {

        }

        public override bool IsValid()
        {
            Validator.ValidateCustomerId();
            Validator.ValidateItem();

            return Validate(Validator, this);
        }
    }
}
