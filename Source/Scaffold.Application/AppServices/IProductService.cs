using Scaffold.Domain.Models.Product;
using System;
using System.Collections.Generic;
using System.Text;

namespace Scaffold.Application.AppServices
{
    public interface IProductService
    {
        Product Create(Product product);
    }
}
