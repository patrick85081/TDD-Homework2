namespace PotterShoppingCart
{
    /// <summary>
    /// 抓取商品
    /// </summary>
    public interface IProductService
    {
        /// <summary>
        /// Finds the product.
        /// </summary>
        /// <param name="productId">The product identifier.</param>
        /// <returns>product or null</returns>
        Product FindProduct(string productId);
    }
}