using PotterShoppingCart.Calculates;

namespace PotterShoppingCart.CalculateFactorys
{
    /// <summary>
    /// 價錢計算 工廠
    /// </summary>
    public interface ICalculateFactory
    {
        /// <summary>
        /// 產生價錢計算方式
        /// </summary>
        /// <returns></returns>
        ICalculate CreateCalculate();
    }
}