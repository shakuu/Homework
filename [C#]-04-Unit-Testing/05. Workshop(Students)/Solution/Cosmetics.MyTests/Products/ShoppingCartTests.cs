namespace Cosmetics.MyTests.Products
{
    using System.Collections.Generic;
    using System.Linq;

    using Moq;
    using NUnit.Framework;

    using Cosmetics.Contracts;
    using Cosmetics.MyTests.Products.Mocks;

    [TestFixture]
    public class ShoppingCartTests
    {
        // AddProduct should add the passed product to the products list.
        [Test]
        public void AddProduct_ShouldAddIProductParameterToIListProducts()
        {
            var mockProduct = new Mock<IProduct>();
            var shoppingCart = new ExposedIListProductsMockShoppingCart();

            shoppingCart.AddProduct(mockProduct.Object);

            CollectionAssert.Contains(shoppingCart.Products, mockProduct.Object);
        }

        // RemoveProduct should remove the passed product from the products list.
        [Test]
        public void RemoveProduct_ShouldRemoveIProductParameterFromIListProducts()
        {
            var mockProduct = new Mock<IProduct>();
            var shoppingCart = new ExposedIListProductsMockShoppingCart();
            shoppingCart.Products.Add(mockProduct.Object);

            shoppingCart.RemoveProduct(mockProduct.Object);

            CollectionAssert.DoesNotContain(shoppingCart.Products, mockProduct.Object);
        }

        // ContainsProduct should return true if the passed product is contained
        // within the products list.
        [Test]
        public void ContainsProduct_ShouldReturnTrue_IfIListProductsContainsIProductParameter()
        {
            var mockProduct = new Mock<IProduct>();
            var shoppingCart = new ExposedIListProductsMockShoppingCart();
            shoppingCart.Products.Add(mockProduct.Object);

            var actualResult = shoppingCart.ContainsProduct(mockProduct.Object);

            Assert.IsTrue(actualResult);
        }

        // TotalPrice should return the total sum of the prices 
        // of all products in the products list. (or 0 if there are no products)
        [Test]
        public void TotalPrice_ShouldReturnTheCorrectSumOfPricesOfEachIndividualIProductContainedInIListProducts()
        {
            var shoppingCart = new ExposedIListProductsMockShoppingCart();

            var prices = new List<decimal>() { 0.45m, 0.77m, 1234.789m };
            for (int i = 0; i < prices.Count; i++)
            {
                var newProduct = new Mock<IProduct>();
                newProduct.SetupGet(mock => mock.Price).Returns(prices[i]);

                shoppingCart.Products.Add(newProduct.Object);
            }

            var expectedSum = prices.Sum();
            var actualSum = shoppingCart.TotalPrice();

            Assert.AreEqual(expectedSum, actualSum);
        }
    }
}
