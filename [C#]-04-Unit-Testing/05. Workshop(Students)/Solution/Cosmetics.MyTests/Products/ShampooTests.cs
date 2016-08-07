namespace Cosmetics.MyTests.Products
{
    using System.Text;

    using NUnit.Framework;

    using Cosmetics.Common;
    using Cosmetics.Products;

    [TestFixture]
    public class ShampooTests
    {
        // Shampoo.Print() should return a string with 
        // the shampoo details in the required format.
        [Test]
        public void Print_ShouldReturnAStringInTheRequiredFormat()
        {
            var name = "name";
            var brand = "brand";
            var price = 10m;
            var gender = GenderType.Unisex;
            var milliliters = (uint)100;
            var usage = UsageType.Medical;

            var expectedBuilder = new StringBuilder();
            expectedBuilder.AppendLine(string.Format("- {0} - {1}:", brand, name));
            expectedBuilder.AppendLine(string.Format("  * Price: ${0}", price * milliliters));
            expectedBuilder.AppendLine(string.Format("  * For gender: {0}", gender));
            expectedBuilder.AppendLine(string.Format("  * Quantity: {0} ml", milliliters));
            expectedBuilder.Append(string.Format("  * Usage: {0}", usage));
            var expectedString = expectedBuilder.ToString();

            var shampoo = new Shampoo(name, brand, price, gender, milliliters, usage);
            var actualString = shampoo.Print();

            Assert.AreEqual(expectedString, actualString);
        }
    }
}
