using FluentValidation;
using Scaffold.Domain.Core.Validators;
using Scaffold.Domain.Models.CartModelModel.Commands;
using System.Collections.Generic;

namespace Scaffold.Domain.Models.CartModel
{
    public sealed class CartValidator : Validator<CartCommand>
    {
        public void ValidateId()
        {
            RuleFor(x => x.id)
                .Must(ValidateGuid).WithMessage("'id' is not a valid UUID");
        }

        public void ValidateCustomerId()
        {
            RuleFor(x => x.customerId)
                .NotNull()
                .NotEmpty();
        }

        public void ValidateStatus()
        {
            var acceptedStatuses = new List<string> { "PENDING", "CANCEL", "DONE" };
            RuleFor(x => x.status)
                .Must(x => acceptedStatuses.Contains(x)).WithMessage("'status' must be one of ['" + string.Join("', '", acceptedStatuses) + "']");
        }

        public void ValidateItem()
        {
            RuleFor(x => x.item.sku)
                .NotNull()
                .NotEmpty();

            RuleFor(x => x.item.quantity)
                .GreaterThan(0);
        }
    }
}
