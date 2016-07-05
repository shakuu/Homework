namespace WarMachines.Machines.Validation
{
    using System;

    internal class Validator : IValidator
    {
        // Class: Type.Name, Property: Prop.Name cannot be null
        private const string IsNullFormat = "Null value in Class: {0}, Property: {1}";

        public void CheckIfNull(
            object obj,
            string typeName = "Unknown",
            string propertyName = "Unknown")
        {
            // TODO: add meaningful message

            if (obj == null)
            {
                throw new ArgumentNullException(
                    string.Format(
                        IsNullFormat,
                        typeName,
                        propertyName));
            }
        }

        public void CheckIfPositive<T>(T value)
            where T : struct
        {
            dynamic tValue = value;

            if (tValue <= 0)
            {
                throw new ArgumentOutOfRangeException("Value must be positive");
            }
        }
    }
}
