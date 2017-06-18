using System;
using System.Collections.Generic;
using System.Linq;

namespace PotterShoppingCart.Calculates
{
    /// <summary>
    /// Potter系列優惠
    /// </summary>
    /// <seealso cref="PotterShoppingCart.Calculates.BaseCalculate" />
    public class PotterDiscounted : BaseCalculate
    {
        /// <summary>
        /// 優惠的 同系列不同本的數量
        /// </summary>
        private int _count;

        /// <summary>
        /// 優惠的折扣
        /// </summary>
        private double _discounted;

        /// <summary>
        /// 哈利波特 折扣計算
        /// </summary>
        /// <param name="count">優惠的 同系列不同本的數量</param>
        /// <param name="discounted">優惠的折扣</param>
        public PotterDiscounted(int count, double discounted)
        {
            _count = count;
            _discounted = discounted;
        }

        /// <summary>
        /// 計算總金額
        /// </summary>
        /// <param name="products">要計算的商品</param>
        /// <returns></returns>
        public override double Calculate(IDictionary<Product, int> products)
        {
            if (products == null)
                throw new ArgumentNullException(
                    $"{nameof(products)} can`t be null.");

            // 過濾 哈利波特 系列商品
            var potters = products.Where(p => p.Value > 0)
                .Where(p => p.Key.Series == "Harry Potter")
                .ToArray();

            var price = 0.0;
            IDictionary<Product, int> uncalculate = products;
            if (potters.Length >= _count)
            {
                // 取得符合條件書籍
                potters = potters.Take(_count)
                    .ToArray();

                // 符合條件 的 組數
                var groupNum = potters.Min(p => p.Value);

                // 符合條件 的 優惠價
                price = potters.Sum(p => p.Key.Price * groupNum)
                        * _discounted;

                // 剩餘尚未計算的商品
                foreach (var potter in potters)
                {
                    if (products.ContainsKey(potter.Key))
                    {
                        products[potter.Key] -= groupNum;
                        if (products[potter.Key] <= 0)
                        {
                            products.Remove(potter.Key);
                        }
                    }
                }
            }

            // 回傳套用此優惠的價格 剩下還沒被計算的商品 套用下一個計算方式
            return price + (uncalculate.Count > 0 ? base.Calculate(uncalculate) : 0);
        }
    }
}