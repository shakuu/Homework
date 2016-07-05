namespace WarMachines.Machines.Validation
{
    internal interface IValidator
    {
        void CheckIfNull(object obj, string typeName, string propertyName);
        void CheckIfPositive<T>(T value) where T : struct;
    }
}
