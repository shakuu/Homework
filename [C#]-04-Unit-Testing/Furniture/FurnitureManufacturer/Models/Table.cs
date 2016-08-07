
namespace FurnitureManufacturer.Models
{
    using System;

    using FurnitureManufacturer.Interfaces;
    using Validation;

    /// <summary>
    /// TODO: ToString()
    /// </summary>
    internal class Table : Furniture, ITable
    {
        private const decimal LengthDecimalGreaterThanValue = (decimal)0;
        private const decimal WidthDecimalGreaterThanValue = (decimal)0;

        private const string ToStringFormat = ", Length: {0}, Width: {1}, Area: {2}";

        private decimal length;
        private decimal width;

        public Table(string model, MaterialType material, decimal price, decimal height, decimal length, decimal width)
            : base(model, material, price, height)
        {
            this.Length = length;
            this.Width = width;
        }

        public decimal Area
        {
            get
            {
                return this.Length * this.Width;
            }
        }

        public decimal Length
        {
            get
            {
                return this.length;
            }

            private set
            {
                try
                {
                    new Validator().CheckValidDecimalNumber(
                        value,
                        Table.LengthDecimalGreaterThanValue);

                    this.length = value;
                }
                catch (Exception)
                {
                    // Continue.
                    throw;
                }
            }
        }

        public decimal Width
        {
            get
            {
                return this.width;
            }

            private set
            {
                try
                {
                    new Validator().CheckValidDecimalNumber(
                        value,
                        Table.WidthDecimalGreaterThanValue);

                    this.width = value;
                }
                catch (Exception)
                {
                    // Continue.
                    throw;
                }
            }
        }

        public override string ToString()
        {
            return base.ToString()
                + string.Format(
                    Table.ToStringFormat,
                    this.Length,
                    this.Width,
                    this.Area);
        }
    }
}
