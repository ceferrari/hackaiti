using Scaffold.Domain.Models.CartModelModel.Commands;
using System;

namespace Scaffold.Domain.Models.CartModel.Commands
{
    public sealed class CartDeleteCommand : CartCommand
    {
        public CartDeleteCommand(string id)
            : base(Guid.Parse(id))
        {

        }

        public override bool IsValid()
        {
            Validator.ValidateId();

            return Validate(Validator, this);
        }
    }
}
