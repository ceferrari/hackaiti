using Scaffold.Domain.Core.ValueObjects;
using System.Collections.Generic;

namespace Scaffold.Domain.Models.Product
{
    public class ProductPrice : ValueObject
    {
        public long Amount { get; set; }
        public long Scale { get; set; }
        public string CurrencyMode { get; set; }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Amount;
            yield return Scale;
            yield return CurrencyMode;
        }
    }
}