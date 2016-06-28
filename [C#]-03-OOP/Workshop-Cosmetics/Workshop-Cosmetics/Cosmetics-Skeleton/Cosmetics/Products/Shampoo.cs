namespace Cosmetics.Products
{
    using Cosmetics.Common;
    using Cosmetics.Contracts;

    public class Shampoo : Product, IShampoo, IProduct
    {
        // 0 brand
        // 1 name
        // 2 price
        // 3 gender
        // 4 usage
        private const string printFormat =
            "- {0} – {1}:\r\n  * Price: ${2}\r\n  * For gender: {3}\r\n  * Quantity: {4} ml\r\n  * Usage: {5}";

        public Shampoo(string name, string brand, decimal price, GenderType gender, uint milliliters, UsageType usage)
            : base(name, brand, price, gender)
        {

            this.Milliliters = milliliters;
            this.Usage = usage;

        }

        public new decimal Price
        {
            get { return base.Price * this.Milliliters; }
        }

        public uint Milliliters { get; set; }

        public UsageType Usage { get; set; }

        public override string Print() // override abstract ? 
        {
            return string.Format(
                printFormat,
                this.Brand,
                this.Name,
                this.Price,
                this.Gender,
                this.Milliliters,
                this.Usage);
        }

    }
}
