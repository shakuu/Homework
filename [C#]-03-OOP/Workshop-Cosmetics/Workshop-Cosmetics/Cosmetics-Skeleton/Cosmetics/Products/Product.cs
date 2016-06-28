namespace Cosmetics.Products
{
    using Common;
    using Contracts;
    public abstract class Product : IProduct
    {
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
                        "Product name",
                        GlobalValidationConstants.ProductNameLengthMin,
                        GlobalValidationConstants.ProductNameLengthMax));

                Validator.CheckIfStringIsNullOrEmpty(
                    value,
                    string.Format(
                        GlobalErrorMessages.StringCannotBeNullOrEmpty,
                        nameof(this.name)));

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
                       "Product brand",
                       GlobalValidationConstants.ProductBrandLengthMin,
                       GlobalValidationConstants.ProductBrandLengthMax));

                Validator.CheckIfStringIsNullOrEmpty(
                    value,
                    string.Format(
                        GlobalErrorMessages.StringCannotBeNullOrEmpty,
                        nameof(this.Brand)));

                this.brand = value;
            }
        }

        public decimal Price
        {
            get
            {
                return this.price;
            }
            protected set
            {
                Validator.CheckIfPriceIsPositive(
                    value,
                    GlobalErrorMessages.PriceNegativeMessage);

                this.price = value;
            }
        }

        public GenderType Gender { get; }

        public abstract string Print();
    }
}
