
namespace FurnitureManufacturer.Models
{
    using System;

    using FurnitureManufacturer.Interfaces;
    using Validation;

    /// <summary>
    /// TODO: Validation
    /// </summary>
    internal class Chair : Furniture, IChair
    {
        private const string ToStringFormat = ", Legs: {0}";

        private int numberOfLegs;

        public Chair(string model, MaterialType material, decimal price, decimal height, int numberOfLegs) 
            : base(model, material, price, height)
        {
            this.NumberOfLegs = numberOfLegs;
        }

        public int NumberOfLegs
        {
            get
            {
                return this.numberOfLegs;
            }

            private set
            {
                try
                {
                    new Validator().CheckValidDecimalNumber(value);

                    this.numberOfLegs = value;
                }
                catch (Exception)
                {
                    //continue
                    throw;
                }
            }
        }

        public override string ToString()
        {
            return base.ToString()
                + string.Format(
                    Chair.ToStringFormat,
                    this.NumberOfLegs);
        }
    }
}
