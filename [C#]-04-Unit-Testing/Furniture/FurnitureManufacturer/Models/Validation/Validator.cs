
namespace FurnitureManufacturer.Models.Validation
{
    using System;
    using System.Linq;

    /// <summary>
    /// TODO: Messages
    /// </summary>
    internal class Validator : IValidator
    {
        private const string StringIsNullOrEmpty = "string cannot be null or empty";

        private const string StringLengthOutOfRange = "string length must be between {1} and {2}";

        private const string InvalidRegistrationNumber = "Registration Number can only contain digits";

        private const string InvalidNumber = "Value must be between {0} and {1}";

        public readonly string ValidStringErrorMessage = "Propery: {0}, Class: {1} ";

        string IValidator.ValidStringErrorMessage
        {
            get
            {
                return this.ValidStringErrorMessage;
            }
        }

        public void CheckValidString(string value, int minLength = 0, int maxLenght = int.MaxValue, string message = null)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentNullException(BuildErrorMessage(message, Validator.StringIsNullOrEmpty));
            }

            var inputLength = value.Length;

            if (inputLength < minLength || maxLenght < inputLength)
            {
                throw new ArgumentException(BuildErrorMessage(
                    message,
                    string.Format(
                        Validator.StringLengthOutOfRange,
                        minLength,
                        maxLenght)));
            }
        }

        public void CheckValidDecimalNumber(decimal value, decimal minValue = 0, decimal maxValue = decimal.MaxValue, string message = null)
        {
            if (value <= minValue || maxValue < value)
            {
                throw new ArgumentOutOfRangeException(string.Format(
                    Validator.InvalidNumber,
                        minValue,
                        maxValue));
            }
        }

        public void CheckValidCompanyRegistrationNumber(string value, string message = null)
        {
            if (value.Any(chr => !char.IsDigit(chr)))
            {
                throw new ArgumentException(Validator.InvalidRegistrationNumber);
            }
        }

        private string BuildErrorMessage(string message, string baseMessage)
        {
            return message == null
                ? message + baseMessage
                : baseMessage;
        }
    }
}
