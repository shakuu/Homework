namespace Cosmetics.Tests.Products
{
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
        }
    }
}
