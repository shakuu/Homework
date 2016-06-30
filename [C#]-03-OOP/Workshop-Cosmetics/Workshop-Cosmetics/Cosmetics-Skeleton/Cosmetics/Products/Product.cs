namespace Cosmetics.Products
{
    using Common;
    using Contracts;

    public abstract class Product : IProduct
    {
        private const string ProductNameErrorMessagePrefix = "Product name";
        private const string ProductBrandErrorMessagePrefix = "Product brand";

        private const string PrintFormat = "- {0} - {1}:\r\n  * Price: ${2}\r\n  * For gender: {3}\r\n";


        private decimal price;
        private string name;
        private string brand;

        protected Product(string name, string brand, decimal price, GenderType gender)
        {
            this.Name = name;
            this.Brand = brand;
            this.Price = price;
            this.Gender = gender;
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                Validator.CheckIfStringLengthIsValid(
                    value,
                    GlobalValidationConstants.ProductNameLengthMax,
                    GlobalValidationConstants.ProductNameLengthMin,
                    string.Format(
                        GlobalErrorMessages.InvalidStringLength,
                        ProductNameErrorMessagePrefix,
                        GlobalValidationConstants.ProductNameLengthMin,
                        GlobalValidationConstants.ProductNameLengthMax));

                Validator.CheckIfStringIsNullOrEmpty(
                    value,
                    string.Format(
                        GlobalErrorMessages.StringCannotBeNullOrEmpty,
                        ProductNameErrorMessagePrefix));

                this.name = value;
            }
        }

        public string Brand
        {
            get
            {
                return this.brand;
            }
            protected set
            {

                Validator.CheckIfStringLengthIsValid(
                   value,
                   GlobalValidationConstants.ProductBrandLengthMax,
                   GlobalValidationConstants.ProductBrandLengthMin,
                   string.Format(
                       GlobalErrorMessages.InvalidStringLength,
                       ProductBrandErrorMessagePrefix,
                       GlobalValidationConstants.ProductBrandLengthMin,
                       GlobalValidationConstants.ProductBrandLengthMax));

                Validator.CheckIfStringIsNullOrEmpty(
                    value,
                    string.Format(
                        GlobalErrorMessages.StringCannotBeNullOrEmpty,
                        ProductBrandErrorMessagePrefix));

                this.brand = value;
            }
        }

        public virtual decimal Price
        {
            get
            {
                return this.price;
            }
            protected set
            {
                Validator.CheckIfNumberIsPositive(
                    value,
                    GlobalErrorMessages.PriceNegativeMessage);

                this.price = value;
            }
        }

        public GenderType Gender { get; set; }

        public virtual string Print()
        {
            return string.Format(
                PrintFormat,
                this.Brand,
                this.Name,
                this.Price,
                this.Gender);
        }
    }
}
