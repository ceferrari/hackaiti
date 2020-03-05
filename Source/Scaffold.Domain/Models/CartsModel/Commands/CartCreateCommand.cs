using Scaffold.Domain.Models.CartModelModel.Commands;

namespace Scaffold.Domain.Models.CartModel.Commands
{
    public sealed class CartCreateCommand : CartCommand
    {
        public CartCreateCommand(Cart cart)
            : base(cart)
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
