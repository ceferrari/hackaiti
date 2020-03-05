using Scaffold.Domain.Core.ValueObjects;
using System.Collections.Generic;

namespace Scaffold.Domain.Models.ProductModel
{
    public class ProductPrice : ValueObject
    {
        public long? amount { get; set; }
        public long? scale { get; set; }
        public string currencyCode { get; set; }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return amount;
            yield return scale;
            yield return currencyCode;
        }
    }
}