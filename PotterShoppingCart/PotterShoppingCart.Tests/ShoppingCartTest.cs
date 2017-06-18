using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace PotterShoppingCart.Tests
{
    [TestClass]
    public class ShoppingCartTest
    {
        private IProductService _productService = null;

        [TestInitialize]
        public void TestInitialize_商品初始化()
        {
            var products = new Dictionary<string, Product>()
            {
                { "1", new Product{ Name = "Potter Vol. 1", Series = "Harry Potter", Price = 100 }},
                { "2", new Product{ Name = "Potter Vol. 2", Series = "Harry Potter", Price = 100 }},
                { "3", new Product{ Name = "Potter Vol. 3", Series = "Harry Potter", Price = 100 }},
                { "4", new Product{ Name = "Potter Vol. 4", Series = "Harry Potter", Price = 100 }},
                { "5", new Product{ Name = "Potter Vol. 5", Series = "Harry Potter", Price = 100 }},
            };
            _productService = new StubProductService(products);
        }

        [TestMethod]
        public void CalculatePrice_第一集一本_總金額_100()
        {
            //arrange
            var shoppingCart = new ShoppingCart(_productService);
            shoppingCart.AddProduct("1");

            //act
            var price = shoppingCart.CalculatePrice();

            //assert
            Assert.AreEqual(100, price);
        }

        [TestMethod]
        public void CalculatePrice_第一集一本_第二集一本_總金額_190()
        {
            //arrange
            var shoppingCart = new ShoppingCart(_productService);
            shoppingCart.AddProduct("1");
            shoppingCart.AddProduct("2");

            //act
            var price = shoppingCart.CalculatePrice();

            //assert
            Assert.AreEqual(190, price);
        }

        [TestMethod]
        public void CalculatePrice_第一集一本_第二集一本_第三集一本_總金額_270()
        {
            //arrange
            var shoppingCart = new ShoppingCart(_productService);
            shoppingCart.AddProduct("1");
            shoppingCart.AddProduct("2");
            shoppingCart.AddProduct("3");

            //act
            var price = shoppingCart.CalculatePrice();

            //assert
            Assert.AreEqual(270, price);
        }
    }

    internal class StubProductService : IProductService
    {
        private readonly IDictionary<string, Product> _products;

        public StubProductService(IDictionary<string, Product> products)
        {
            _products = products;
        }

        public Product FindProduct(string productId)
        {
            return _products.ContainsKey(productId) ?
                _products[productId] : null;
        }
    }
}