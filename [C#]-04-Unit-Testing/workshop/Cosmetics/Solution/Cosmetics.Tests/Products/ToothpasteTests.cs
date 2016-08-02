namespace Cosmetics.Tests.Products
{
    using System.Collections.Generic;
    using System.Text;

    using NUnit.Framework;

    using Cosmetics.Common;
    using Cosmetics.Products;

    [TestFixture]
    public class ToothpasteTests
    {
        [Test]
        public void Print_ShouldReturnAStringInTheRequiredFormat()
        {
            var name = "name";
            var brand = "brand";
            var price = 10m;
            var gender = GenderType.Unisex;
            var ingerdients = new List<string>()
            {
                "ingredient"
            };

            var toothpaste = new Toothpaste(name, brand, price, gender,ingerdients);

            var expected = new StringBuilder();
            expected.AppendLine(string.Format("- {0} - {1}:", brand, name));
            expected.AppendLine(string.Format("  * Price: ${0}", price));
            expected.AppendLine(string.Format("  * For gender: {0}", gender));
            expected.Append(string.Format("  * Ingredients: {0}", string.Join(", ", ingerdients)));

            var actual = toothpaste.Print();

            Assert.AreEqual(expected.ToString(), actual);
        }
    }
}
