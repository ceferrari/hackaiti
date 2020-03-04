using FluentValidation;
using Scaffold.Domain.Core.Validators;
using Scaffold.Domain.Models.Product.Commands;

namespace Scaffold.Domain.Models.Product
{
    public sealed class ProductValidator : Validator<ProductCommand>
    {
        public void ValidateSku()
        {
            RuleFor(x => x.SKU)
                .NotNull().WithMessage("SKU cannot be null")
                .NotEmpty().WithMessage("SKU cannot be empty");
        }

        public void ValidateName()
        {
            RuleFor(x => x.Name)
                .NotNull().WithMessage("Name cannot be null")
                .NotEmpty().WithMessage("Name cannot be empty")
                .MinimumLength(3).WithMessage("Name must have at least 3 characters");
        }
    }
}
