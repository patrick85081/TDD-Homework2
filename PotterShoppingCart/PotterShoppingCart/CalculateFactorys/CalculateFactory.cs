using PotterShoppingCart.Calculates;

namespace PotterShoppingCart.CalculateFactorys
{
    internal class CalculateFactory : ICalculateFactory
    {
        public ICalculate CreateCalculate()
        {
            return new DefaultCalculate();
        }
    }
}