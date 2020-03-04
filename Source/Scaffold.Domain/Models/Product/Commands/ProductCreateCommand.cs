using System;

namespace Scaffold.Domain.Models.Product.Commands
{
    public sealed class ProductCreateCommand : ProductCommand
    {
        public ProductCreateCommand(Product product)
            : base(product)
        {

        }

        public override bool IsValid()
        {
            Validator.ValidateSku();

            return Validate(Validator, this);
        }
    }
}
