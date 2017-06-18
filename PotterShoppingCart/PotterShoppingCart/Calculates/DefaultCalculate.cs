using System;
using System.Collections.Generic;
using System.Linq;

namespace PotterShoppingCart.Calculates
{
    public class DefaultCalculate : ICalculate
    {
        public DefaultCalculate()
        {
        }

        public double Calculate(IDictionary<Product, int> products)
        {
            if (products == null)
                throw new ArgumentNullException(
                    $"{nameof(products)} can`t be null.");

            return products.Sum(p => p.Key.Price * p.Value);
        }
    }
}