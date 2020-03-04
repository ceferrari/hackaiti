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
            Validator.ValidateName();
            Validator.ValidateShortDescription();
            Validator.ValidateLongDescription();
            Validator.ValidateImageUrl();
            Validator.ValidatePrice();

            return Validate(Validator, this);
        }
    }
}
