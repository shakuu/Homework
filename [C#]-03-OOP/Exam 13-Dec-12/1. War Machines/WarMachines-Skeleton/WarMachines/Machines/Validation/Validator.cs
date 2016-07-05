namespace WarMachines.Machines.Validation
{
    using System;

    internal class Validator : IValidator
    {
        public void CheckIfNull(object obj)
        {
            // TODO: add meaningful message

            if (obj == null)
            {
                throw new ArgumentNullException();
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
