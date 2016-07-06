namespace FurnitureManufacturer.Models.Validation
{
    public interface IValidator
    {
        void CheckValidCompanyRegistrationNumber(string value);

        void CheckValidDecimalNumber(decimal value, decimal minValue = 0, decimal maxValue = decimal.MaxValue);

        void CheckValidString(string value, int minLength = 0, int maxLenght = int.MaxValue);
    }
}