namespace Cosmetics.Tests.Products
{
    using System.Text;

    using Moq;
    using NUnit.Framework;

    using Cosmetics.Contracts;
    using Cosmetics.Products;

    [TestFixture]
    public class CategoryTests
    {
        [Test]
        public void Print_ShouldReturnAStringInTheRequiredFormat()
        {
            var name = "name";
            var category = new Category(name);

            var mockedProduct = new Mock<IProduct>();
            mockedProduct.Setup(mock => mock.Print()).Returns("mock print");

            var categoryString = string.Format("{0} category - {1} {2} in total", name, 1, "product");
            var expectedBuilder = new StringBuilder();
            expectedBuilder.AppendLine(categoryString);
            expectedBuilder.Append("mock print");
            var expected = expectedBuilder.ToString();

            category.AddCosmetics(mockedProduct.Object);
            var actual = category.Print();

            Assert.AreEqual(expected, actual);
        }
    }
}
