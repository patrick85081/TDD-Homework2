using System;
using System.Collections.Generic;
using System.Linq;

namespace PotterShoppingCart.Calculates
{
    /// <summary>
    /// 基礎 的裝飾者模式 基底的計算方式 (內含<see cref="DefaultCalculate"/>功能)
    /// </summary>
    /// <seealso cref="PotterShoppingCart.Calculates.ICalculate" />
    public class BaseCalculate : ICalculate
    {
        private ICalculate _calculate = null;

        protected BaseCalculate()
        {
        }

        /// <summary>
        /// 將多個<see cref="BaseCalculate"/>組合起來
        /// </summary>
        /// <param name="calculates">價格計算物件</param>
        /// <returns>組合出來的價格計算</returns>
        public static BaseCalculate ComposeBaseCalculate(params BaseCalculate[] calculates)
        {
            if (calculates == null || calculates.Length == 0)
                return new BaseCalculate();

            BaseCalculate lastCalculate = null;

            using (var enumerator = calculates.Reverse().GetEnumerator())
            {
                while (enumerator.MoveNext())
                {
                    var current = enumerator.Current;
                    if (lastCalculate != null)
                        current.SetCalculate(lastCalculate);
                    lastCalculate = current;
                }
            }

            return lastCalculate;
        }

        /// <summary>
        /// 加入計算物件
        /// </summary>
        /// <param name="calculate">The calculate.</param>
        public void SetCalculate(ICalculate calculate)
        {
            _calculate = calculate;
        }

        /// <summary>
        /// 計算產品總金額
        /// </summary>
        /// <param name="products">購買產品清單及數量</param>
        /// <returns>
        /// 總金額
        /// </returns>
        /// <exception cref="System.ArgumentNullException">products</exception>
        public virtual double Calculate(IDictionary<Product, int> products)
        {
            if (products == null)
                throw new ArgumentNullException(
                    $"{nameof(products)} can`t be null.");

            return _calculate?.Calculate(products) ?? 
                products.Sum(p => p.Key.Price * p.Value);
        }
    }
}