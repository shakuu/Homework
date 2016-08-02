namespace Cosmetics.Tests.Products
{
    using System.Text;
    
    using NUnit.Framework;

    using Cosmetics.Common;
    using Cosmetics.Products;

    [TestFixture]
    public class ShampooTests
    {
        [Test]
        public void Print_ShouldReturnAStringInTheRequiredFormat()
        {
            var name = "name";
            var brand = "brand";
            var price = 10m;
            var gender = GenderType.Unisex;
            var milliliters = (uint)10;
            var usage = UsageType.EveryDay;

            var shampoo = new Shampoo(name, brand, price, gender, milliliters, usage);

            var expected = new StringBuilder();
            expected.AppendLine(string.Format("- {0} - {1}:", brand, name));
            expected.AppendLine(string.Format("  * Price: ${0}", price));
            expected.Append(string.Format("  * For gender: {0}", gender));
            expected.AppendLine(string.Format("  * Quantity: {0} ml", milliliters));
            expected.Append(string.Format("  * Usage: {0}", usage));

            var actual = shampoo.Print();

            Assert.AreEqual(expected.ToString(), actual);
        }
    }
}
