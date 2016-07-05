namespace WarMachines.Machines.ToStringFormats
{
    public interface IToStringFormatter
    {
        string this[MachineLineNumberType lineNr] { get; }
    }
}
