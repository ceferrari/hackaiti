using Scaffold.Domain.Core.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace Scaffold.Domain.Models.Product.Commands
{
    public abstract class ProductCreateCommand : Command<int, Product, Product>
    {
        protected readonly ProductValidator Validator;

        protected PrczCategoriaCommand(string id, Expression<Func<PrczCategoria, bool>> filter = null)
            : base(id, filter)
        {
            Validator = new PrczCategoriaValidator();
        }

        protected PrczCategoriaCommand(string id, string nome)
            : this(id)
        {
            Nome = nome;
        }
    }
}
