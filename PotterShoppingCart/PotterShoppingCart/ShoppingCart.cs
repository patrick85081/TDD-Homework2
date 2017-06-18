using PotterShoppingCart.CalculateFactorys;
using PotterShoppingCart.Calculates;
using System;
using System.Collections.Generic;

namespace PotterShoppingCart
{
    /// <summary>
    /// 購物車系統
    /// </summary>
    public class ShoppingCart
    {
        /// <summary>
        /// 商品來源
        /// </summary>
        private readonly IProductService _productService = null;

        private ICalculate _calculate = null;

        /// <summary>
        /// 紀錄商品數量
        /// </summary>
        private readonly Dictionary<Product, int> _products = new Dictionary<Product, int>();

        public ShoppingCart()
            : this(new ProductSqlService())
        {
        }

        internal ShoppingCart(IProductService productService)
            :this(productService, new CalculateFactory())
        {
        }

        private ShoppingCart(IProductService productService, ICalculateFactory calculateFactory)
        {
            this._productService = productService;
            this._calculate = calculateFactory.CreateCalculate();
        }

        /// <summary>
        /// 將商品加入購物車
        /// </summary>
        /// <param name="productId">商品Id</param>
        /// <param name="count">數量</param>
        public void AddProduct(string productId, int count = 1)
        {
            var mProduct = _productService.FindProduct(productId);

            if (mProduct == null)
                return;

            if (_products.ContainsKey(mProduct))
                this._products[mProduct] += count;
            else
                this._products[mProduct] = count;
        }

        /// <summary>
        /// 計算商品金額
        /// </summary>
        /// <returns>總金額</returns>
        public double CalculatePrice()
        {
            return _calculate.Calculate(_products);
        }
    }
}