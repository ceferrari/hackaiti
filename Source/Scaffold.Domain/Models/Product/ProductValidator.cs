using FluentValidation;
using Scaffold.Domain.Core.Validators;
using Scaffold.Domain.Models.Product.Commands;
using System.Collections.Generic;

namespace Scaffold.Domain.Models.Product
{
    public sealed class ProductValidator : Validator<ProductCommand>
    {
        public void ValidateSku()
        {
            RuleFor(x => x.sku)
                .NotNull()
                .NotEmpty();
        }

        public void ValidateName()
        {
            RuleFor(x => x.name)
                .NotNull()
                .NotEmpty()
                .MinimumLength(3);
        }

        public void ValidateShortDescription()
        {
            RuleFor(x => x.shortDescription)
                .NotNull()
                .NotEmpty()
                .MinimumLength(3);
        }

        public void ValidateLongDescription()
        {
            RuleFor(x => x.longDescription)
                .NotNull()
                .NotEmpty()
                .MinimumLength(3);
        }

        public void ValidateImageUrl()
        {
            RuleFor(x => x.imageUrl)
                .NotNull()
                .NotEmpty()
                .MinimumLength(3);
        }

        public void ValidatePrice()
        {
            RuleFor(x => x.price.amount)
                .NotNull()
                .NotEmpty();

            RuleFor(x => x.price.scale)
                .NotNull()
                .NotEmpty();

            var acceptedCurrencies = new List<string> { "USD", "EUR", "BRL" };
            RuleFor(x => x.price.currencyCode)
                .Must(x => acceptedCurrencies.Contains(x)).WithMessage("'price.currencyCode' must be one of ['" + string.Join("', '", acceptedCurrencies) + "']");
        }
    }
}
