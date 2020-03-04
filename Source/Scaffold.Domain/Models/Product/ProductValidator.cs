using Scaffold.Domain.Core.Validators;
using System;
using System.Collections.Generic;
using System.Text;

namespace Scaffold.Domain.Models.Product
{
    public sealed class ProductValidator : Validator<ProductCommand>
    {
        public void ValidateSku()
        {
            RuleFor(x => x.Nome).Length(10, 20);
        }
    }
}
