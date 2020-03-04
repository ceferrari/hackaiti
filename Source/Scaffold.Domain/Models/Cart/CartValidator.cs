using FluentValidation;
using Scaffold.Domain.Core.Validators;
using Scaffold.Domain.Models.Cart.Commands;

namespace Scaffold.Domain.Models.Cart
{
    public sealed class CartValidator : Validator<CartCommand>
    {
        public void ValidateCustomerId()
        {
            RuleFor(x => x.customerId)
                .NotNull()
                .NotEmpty();
        }

        public void ValidateItem()
        {
            RuleFor(x => x.item.sku)
                .NotNull()
                .NotEmpty();

            RuleFor(x => x.item.quantity)
                .NotNull()
                .NotEmpty();
        }
    }
}
