namespace WarMachines.Machines.ToStringFormats
{
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Reflection;

    internal class ToStringFormat : IToStringFormatter
    {
        private const string MachineID = "Machine";

        private readonly string Line0FormatMachineNotSet = string.Empty;
        private readonly string Line1FormatMachineName = "- {0}";
        private readonly string Line2FormatMachineType = " *Type: {0}";
        private readonly string Line3FormatMachineHealthPoints = " *Health: {0}";
        private readonly string Line4FormatMachineAttackPoints = " *Attack: {0}";
        private readonly string Line5FormatMachineDefensePoints = " *Defense: {0}";
        private readonly string Line6FormatMachineTargets = " *Targets: {0}";

        Collection<string> machineFormatStrings;

        public ToStringFormat()
        {
            this.InitializeMachineFormatStrings();
        }

        public string this[MachineLineNumberType lineNr]
        {
            get
            {
                return this.machineFormatStrings[(int)lineNr];
            }
        }

        private void InitializeMachineFormatStrings()
        {
            this.machineFormatStrings =
                new Collection<string>();
            
            var fields = this.GetType()
                .GetFields(
                    BindingFlags.NonPublic | BindingFlags.Instance)
                .Where(field => field.Name.Contains(MachineID))
                .OrderBy(field => field.Name);

            foreach (var field in fields)
            {
                this.machineFormatStrings.Add(
                    field.GetValue(this).ToString());
            }
        }
    }
}
