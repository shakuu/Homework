namespace WarMachines.Machines.Validation
{
    internal interface IValidator
    {
        void CheckIfNull(object obj);
        void CheckIfPositive<T>(T value) where T : struct;
    }
}
