namespace Cosmetics.Products
{
    using Cosmetics.Common;
    using Cosmetics.Contracts;

    public class Shampoo : Product, IShampoo, IProduct
    {
        private const string printFormat =
            "- {0} - {1}:\r\n  * Price: ${2}\r\n  * For gender: {3}\r\n  * Quantity: {4} ml\r\n  * Usage: {5}";

        private const string PrintFormatLine1 = "  * Quantity: {0} ml\r\n";

        private const string PrintFormatLine2 = "  * Usage: {0}";

        private uint milliliters;

        public Shampoo(string name, string brand, decimal price, GenderType gender, uint milliliters, UsageType usage)
            : base(name, brand, price, gender)
        {

            this.Milliliters = milliliters;
            this.Usage = usage;

        }

        public override decimal Price
        {
            get { return base.Price * this.Milliliters; }
        }

        public uint Milliliters
        {
            get
            {
                return this.milliliters;
            }
            set
            {
                Validator.CheckIfNumberIsPositive(value);

                this.milliliters = value;
            }
        }

        public UsageType Usage { get; set; }

        public override string Print() // override abstract ? 
        {
            return base.Print()
                   + string.Format(PrintFormatLine1, this.Milliliters)
                   + string.Format(PrintFormatLine2, this.Usage);
        }

    }
}
