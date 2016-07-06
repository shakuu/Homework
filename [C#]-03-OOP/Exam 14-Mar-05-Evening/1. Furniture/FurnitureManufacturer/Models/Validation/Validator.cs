
namespace FurnitureManufacturer.Models.Validation
{
    using System;
    using System.Linq;

    /// <summary>
    /// TODO: Messages
    /// </summary>
    internal class Validator : IValidator
    {
        public void CheckValidString(string value, int minLength = 0, int maxLenght = int.MaxValue)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentNullException();
            }

            var inputLength = value.Length;

            if (inputLength < minLength || maxLenght < inputLength)
            {
                throw new ArgumentException();
            }
        }

        public void CheckValidDecimalNumber(decimal value, decimal minValue = 0, decimal maxValue = decimal.MaxValue)
        {
            if (value <= minValue || maxValue < value)
            {
                throw new ArgumentOutOfRangeException();
            }
        }

        public void CheckValidCompanyRegistrationNumber(string value)
        {
            if (value.Any(chr => !char.IsDigit(chr)))
            {
                throw new ArgumentException();
            }
        }
    }
}
