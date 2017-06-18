using System.Collections.Generic;

namespace PotterShoppingCart.Calculates
{
    /// <summary>
    /// 商品計算方式
    /// </summary>
    public interface ICalculate
    {
        /// <summary>
        /// 計算產品總金額
        /// </summary>
        /// <param name="products">購買產品清單及數量</param>
        /// <returns>總金額</returns>
        double Calculate(IDictionary<Product, int> products);
    }
}