namespace Scaffold.Domain.Models.Product.Commands
{
    public sealed class ProductCreateCommand : ProductCommand
    {
        public ProductCreateCommand(int id)
            : base(id)
        {

        }

        public ProductCreateCommand(int id,
            string sku)
            : base(id, sku)
        {

        }

        public override bool IsValid()
        {
            Validator.ValidateSku();

            return Validate(Validator, this);
        }
    }
}
