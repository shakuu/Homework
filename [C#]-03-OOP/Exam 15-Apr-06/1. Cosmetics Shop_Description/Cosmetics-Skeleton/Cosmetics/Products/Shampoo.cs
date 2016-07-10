namespace Cosmetics.Products
{
    using System;
    using System.Text;

    using Contracts;
    using Cosmetics.Common;

    /// <summary>
    /// All shampoos should implement the IShampoo interface.
    /// Shampoo’s price is given per milliliter.
    /// </summary>
    internal class Shampoo : Product, IShampoo
    {
        private const string PrintQuantitiyLine = "  * Quantity: {0} ml";
        private const string PrintUsageLine = "  * Usage: {0}";

        private uint milliliters;
        private UsageType usage;

        public Shampoo(string name, string brand, decimal price, GenderType gender, uint milliliters, UsageType usage)
            : base(name, brand, price, gender)
        {
            this.Milliliters = milliliters;
            this.Usage = usage;
        }

        /// <summary>
        /// Validated in base.Price
        /// </summary>
        public override decimal Price
        {
            get
            {
                return base.Price * this.Milliliters;
            }
        }

        public uint Milliliters
        {
            get
            {
                return this.milliliters;
            }

            private set
            {
                var checkIfNullErrorMessage = string.Format(GlobalErrorMessages.ObjectCannotBeNull, "Milliliters");

                Validator.CheckIfNull(value, checkIfNullErrorMessage);

                if (value < 0)
                {
                    throw new ArgumentException("Value cannot be negative");
                }

                this.milliliters = value;
            }
        }

        /// <summary>
        /// Usage type can be “EveryDay” or “Medical”.
        /// </summary>
        public UsageType Usage
        {
            get
            {
                return this.usage;
            }

            private set
            {
                this.usage = value;
            }
        }

        /// <summary>
        ///   * Quantity: {product quantity} ml (when applicable)
        ///   * Usage: EveryDay/Medical(when applicable)
        /// </summary>
        /// <returns></returns>
        public override string Print()
        {
            var printBuilder = new StringBuilder();

            printBuilder.Append(base.Print());
            printBuilder.AppendLine();
            printBuilder.AppendFormat(Shampoo.PrintQuantitiyLine, this.Milliliters);
            printBuilder.AppendLine();
            printBuilder.AppendFormat(Shampoo.PrintUsageLine, this.Usage.ToString());

            return printBuilder.ToString();
        }
    }
}
