namespace Cosmetics.Products
{
    using System;

    using Cosmetics.Common;

    internal static class ValidateProperties
    {
        internal static void ValidateStringNames(string value, int minimumLenght, int maximumLenght, string properyName)
        {
            var isNullErrorMessage = string.Format(
                GlobalErrorMessages.StringCannotBeNullOrEmpty, properyName);

            Validator.CheckIfStringIsNullOrEmpty(value, isNullErrorMessage);

            var invalidStringLengthErrorMessage = string.Format(
                GlobalErrorMessages.InvalidStringLength, properyName, minimumLenght, maximumLenght);

            Validator.CheckIfStringLengthIsValid(
                value, maximumLenght, minimumLenght, invalidStringLengthErrorMessage);
        }

        internal static void ValidePrice(decimal value)
        {
            if (value < 0)
            {
                throw new ArgumentException("Price cannot be negative");
            }
        }
    }
}
