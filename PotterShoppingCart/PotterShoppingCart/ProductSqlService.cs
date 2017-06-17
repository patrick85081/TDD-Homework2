using System;
using System.Collections.Generic;

namespace PotterShoppingCart
{
    /// <summary>
    /// 從資料庫抓取產品資料
    /// </summary>
    /// <seealso cref="PotterShoppingCart.IProductService" />
    internal class ProductSqlService : IProductService
    {
        public ProductSqlService()
        {
        }

        public Product FindProduct(string productId)
        {
            //TODO 真實從資料庫搜尋資料
            throw new NotImplementedException();
        }
    }
}