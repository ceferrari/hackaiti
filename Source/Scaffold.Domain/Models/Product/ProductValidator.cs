using Scaffold.Domain.Core.Validators;
using Scaffold.Domain.Models.Product.Commands;

namespace Scaffold.Domain.Models.Product
{
    public sealed class ProductValidator : Validator<ProductCommand>
    {
        public void ValidateSku()
        {
            RuleFor(x => x.SKU)
        }
    }
}
