
namespace FurnitureManufacturer.Models
{
    using System;

    using FurnitureManufacturer.Interfaces;

    /// <summary>
    /// TODO: Exception Messages
    /// TODO: ToString()
    /// </summary>
    internal class Furniture : IFurniture
    {
        private const int ModelStringMinimumLength = 3;
        private const decimal PriceDecimalGreaterThanValue = (decimal)0;
        private const decimal HeightDecimalGreaterThanValue = (decimal)0;

        private const string ToStringFormat = "Type: {0}, Model: {1}, Material: {2}, Price: {3}, Height: {4}";

        private string model;
        private MaterialType material;
        private decimal price;
        private decimal height;

        public Furniture(string model, MaterialType material, decimal price, decimal height)
        {
            this.Model = model;
            this.material = material;
            this.Price = price;
            this.Height = height;
        }

        public string Model
        {
            get
            {
                return this.model;
            }

            private set
            {

                try
                {
                    new Validation.Validator()
                        .CheckValidString(value, Furniture.ModelStringMinimumLength);

                    this.model = value;
                }
                catch (Exception)
                {
                    // Continue execution.
                    //throw;
                }

            }
        }

        public decimal Price
        {
            get
            {
                return this.price;
            }

            set
            {
                try
                {
                    new Validation.Validator()
                        .CheckValidDecimalNumber(value, Furniture.PriceDecimalGreaterThanValue);

                    this.price = value;
                }
                catch (Exception)
                {
                    // Continue execution
                    //throw;
                }
            }
        }

        // Measured in Meters
        public decimal Height
        {
            get
            {
                return this.height;
            }

            protected set
            {
                try
                {
                    new Validation.Validator()
                        .CheckValidDecimalNumber(value, Furniture.HeightDecimalGreaterThanValue);

                    this.height = value;
                }
                catch (Exception)
                {
                    // Continue execution
                    //throw;
                }
            }
        }

        public string Material
        {
            get
            {
                return this.material.ToString();
            }
        }

        public override string ToString()
        {
            return string.Format(
                Furniture.ToStringFormat,
                this.GetType().Name,
                this.Model,
                this.Material,
                this.Price,
                this.Height);
        }
    }
}
