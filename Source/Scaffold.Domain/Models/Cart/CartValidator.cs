using FluentValidation;
using Scaffold.Domain.Core.Validators;
using Scaffold.Domain.Models.Cart.Commands;
using Scaffold.Domain.Models.Product.Commands;
using System.Collections.Generic;

namespace Scaffold.Domain.Models.Product
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
