using PotterShoppingCart.Calculates;

namespace PotterShoppingCart.CalculateFactorys
{
    internal class CalculateFactory : ICalculateFactory
    {
        public ICalculate CreateCalculate()
        {
            return BaseCalculate.ComposeBaseCalculate(
                new PotterDiscounted(2, 0.95));
        }
    }
}