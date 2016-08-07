namespace Cosmetics.MyTests.Products
{
    using System.Text;

    using Moq;
    using NUnit.Framework;

    using Cosmetics.Contracts;
    using Cosmetics.Products;
    using Cosmetics.MyTests.Products.Mocks;

    [TestFixture]
    public class CategoryTests
    {
        // Category.Print() should return a string
        // with the category details in the required format.
        [Test]
        public void Print_ShouldReturnAStringInTheRequiredFormat_WhenNoProductsHaveBeenAdded()
        {
            var name = "category";
            var productsCount = 0;

            var categoryString =
                string.Format("{0} category - {1} {2} in total", name, productsCount, productsCount != 1 ? "products" : "product");
            var expectedBuilder = new StringBuilder();
            expectedBuilder.AppendLine(categoryString);
            var expectedString = expectedBuilder.ToString().Trim();

            var category = new Category(name);
            var actualString = category.Print();

            Assert.AreEqual(expectedString, actualString);
        }

        [Test]
        public void Print_ShouldReturnAStringInTheRequiredFormat_WhenOneProductHasBeenAdded()
        {
            var mockPrintString = "mocked";
            var mockProduct = new Mock<IShampoo>();
            mockProduct.Setup(mock => mock.Print()).Returns(mockPrintString);

            var name = "category";
            var productsCount = 1;

            var categoryString =
                string.Format("{0} category - {1} {2} in total", name, productsCount, productsCount != 1 ? "products" : "product");
            var expectedBuilder = new StringBuilder();
            expectedBuilder.AppendLine(categoryString);
            expectedBuilder.AppendLine(mockPrintString);
            var expectedString = expectedBuilder.ToString().Trim();

            var category = new Category(name);
            category.AddProduct(mockProduct.Object);
            var actualString = category.Print();

            Assert.AreEqual(expectedString, actualString);
        }

        [Test]
        public void Print_ShouldReturnAStringInTheRequiredFormat_WhenTowProductsHaveBeenAdded()
        {
            var mockPrintString = "mocked";
            var mockProduct = new Mock<IShampoo>();
            mockProduct.Setup(mock => mock.Print()).Returns(mockPrintString);

            var mockPrintStringTwo = "another mock";
            var mockProductTwo = new Mock<IToothpaste>();
            mockProductTwo.Setup(mock => mock.Print()).Returns(mockPrintStringTwo);

            var name = "category";
            var productsCount = 2;

            var categoryString =
                string.Format("{0} category - {1} {2} in total", name, productsCount, productsCount != 1 ? "products" : "product");
            var expectedBuilder = new StringBuilder();
            expectedBuilder.AppendLine(categoryString);
            expectedBuilder.AppendLine(mockPrintString);
            expectedBuilder.AppendLine(mockPrintStringTwo);
            var expectedString = expectedBuilder.ToString().Trim();

            var category = new Category(name);
            category.AddProduct(mockProduct.Object);
            category.AddProduct(mockProductTwo.Object);
            var actualString = category.Print();

            Assert.AreEqual(expectedString, actualString);
        }

        // AddCosmetics should add the passed cosmetic to the products list.
        [Test]
        public void AddCosmetics_ShouldAddThePassedIProductParameterToIListProducts()
        {
            var mockProduct = new Mock<IProduct>();

            var category = new ExposedIListProductsMockedCategory("category");
            category.AddProduct(mockProduct.Object);

            CollectionAssert.Contains(category.Products, mockProduct.Object);
        }

        // RemoveCosmetics should remove the passed cosmetic from the products list.
        [Test]
        public void RemoveCosmetics_ShouldRemoveThePassedIProductParameterFromIListProducts()
        {
            var mockProduct = new Mock<IProduct>();

            var category = new ExposedIListProductsMockedCategory("category");
            category.Products.Add(mockProduct.Object);
            category.RemoveProduct(mockProduct.Object);

            CollectionAssert.DoesNotContain(category.Products, mockProduct.Object);
        }
    }
}
