namespace Cosmetics.MyTests.Products
{
    using System.Collections.Generic;
    using System.Text;

    using NUnit.Framework;

    using Cosmetics.Common;
    using Cosmetics.Products;

    [TestFixture]
    public class ToothpasteTests
    {
        // Toothpaste.Print() should return a string
        // with the toothpaste details in the required format.
        [Test]
        public void Print_ShouldReturnAStringInTheRequiredFormat()
        {
            var name = "name";
            var brand = "brand";
            var price = 10m;
            var gender = GenderType.Unisex;
            var ingredients = new List<string>() { "ing0", "ing1" };

            var expectedBuilder = new StringBuilder();
            expectedBuilder.AppendLine(string.Format("- {0} - {1}:", brand, name));
            expectedBuilder.AppendLine(string.Format("  * Price: ${0}", price));
            expectedBuilder.AppendLine(string.Format("  * For gender: {0}", gender));
            expectedBuilder.Append(string.Format("  * Ingredients: {0}", string.Join(", ", ingredients)));
            var expectedString = expectedBuilder.ToString();

            var toothpaste = new Toothpaste(name, brand, price, gender, ingredients);
            var actualString = toothpaste.Print();

            Assert.AreEqual(expectedString, actualString);
        }
    }
}
