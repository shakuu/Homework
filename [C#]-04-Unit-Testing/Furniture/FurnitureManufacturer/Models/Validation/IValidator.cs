namespace FurnitureManufacturer.Models.Validation
{
    public interface IValidator
    {
        string ValidStringErrorMessage { get; }

        void CheckValidCompanyRegistrationNumber(string value, string message = null);

        void CheckValidDecimalNumber(decimal value, decimal minValue = 0, decimal maxValue = decimal.MaxValue, string message = null);

        void CheckValidString(string value, int minLength = 0, int maxLenght = int.MaxValue, string message = null);
    }
}