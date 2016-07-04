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
    }
}
