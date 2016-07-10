namespace Cosmetics.Products
{
    using System;
    using System.Text;

    using Common;
    using Cosmetics.Contracts;

    /// <summary>
    /// All products should implement the IProduct interface.
    /// </summary>
    internal class Product : IProduct
    {
        private const int NameMinimumLength = 3;
        private const int NameMaximumLength = 10;

        private const int BrandMinimumLength = 2;
        private const int BrandMaximumLength = 10;

        private const string PrintHeaderFormat = "- {0} - {1}:";
        private const string PrintPriceFormat = "  * Price: ${0}";
        private const string PrintGenderFormat = "  * For gender: {0}";

        private string name;
        private string brand;
        private decimal price;
        private GenderType gender;

        public Product(string name, string brand, decimal price, GenderType gender)
        {
            this.Name = name;
            this.Brand = brand;
            this.Price = price;
            this.Gender = gender;
        }

        /// <summary>
        /// Minimum product name’s length is 3 symbols and maximum is 10 symbols.
        /// The error message should be
        /// "Product name must be between {min} and {max} symbols long!".
        /// </summary>
        public string Name
        {
            get
            {
                return this.name;
            }

            private set
            {
                ValidateProperties.ValidateStringNames(
                    value,
                    Product.NameMinimumLength,
                    Product.NameMaximumLength,
                    "Product name");

                this.name = value;
            }
        }

        /// <summary>
        /// Minimum brand name’s length is 2 symbols and maximum is 10 symbols.
        /// The error message should be 
        /// "Product brand must be between {min} and {max} symbols long!".
        /// </summary>
        public string Brand
        {
            get
            {
                return this.brand;
            }

            private set
            {
                ValidateProperties.ValidateStringNames(
                    value,
                    Product.BrandMinimumLength,
                    Product.BrandMaximumLength,
                    "Product brand");

                this.brand = value;
            }
        }

        /// <summary>
        /// Gender type can be “Men”, “Women” or “Unisex”. 
        /// </summary>
        public GenderType Gender
        {
            get
            {
                return this.gender;
            }

            private set
            {
                this.gender = value;
            }
        }

        /// <summary>
        /// Virtual
        /// </summary>
        public virtual decimal Price
        {
            get
            {
                return this.price;
            }

            private set
            {
                ValidateProperties.ValidePrice(value);

                this.price = value;
            }
        }

        /// <summary>
        /// - {product brand} – {product name}:
        ///   * Price: ${product price}
        ///   * For gender: Men/Women/Unisex
        /// </summary>
        /// <returns></returns>
        public virtual string Print()
        {
            var printBuilder = new StringBuilder();

            printBuilder.AppendFormat(Product.PrintHeaderFormat, this.Brand, this.Name);
            printBuilder.AppendLine();
            printBuilder.AppendFormat(Product.PrintPriceFormat, this.Price);
            printBuilder.AppendLine();
            printBuilder.AppendFormat(Product.PrintGenderFormat, this.Gender.ToString());

            return printBuilder.ToString();
        }
    }
}
