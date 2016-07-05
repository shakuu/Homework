namespace WarMachines.Machines
{
    using System.Collections.ObjectModel;
    using System.Linq;

    using Interfaces;
    using Validation;
    using System.Collections.Generic;
    using System.Text;

    internal class Pilot : IPilot
    {
        private const string FormatPrint = "{0} - {1} {2}";

        private string name;
        private ICollection<IMachine> machines;

        public Pilot(string name)
        {
            this.Name = name;
            this.machines = new Collection<IMachine>();
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                // TODO: Check for null

                this.name = value;
            }
        }

        public void AddMachine(IMachine machine)
        {
            new Validator().CheckIfNull(machine);

            this.machines.Add(machine);

            this.machines = SortMachines(this.machines);
        }

        //(pilot name) – (number of machines/”no”) (“machine”/”machines”)
        public string Report()
        {
            this.machines = SortMachines(this.machines);

            var output = new StringBuilder();

            output.Append(
                string.Format(
                    FormatPrint,
                    this.Name,
                    this.machines.Count == 0
                        ? "no"
                        : this.machines.Count.ToString(),
                    this.machines.Count == 1
                        ? "machine"
                        : "machines")
                    );

            foreach (var machine in this.machines)
            {
                output.AppendLine();
                output.Append(machine.ToString());
            }

            return output.ToString();
        }

        private ICollection<IMachine> SortMachines(IEnumerable<IMachine> machines)
        {
            var output = machines
                 .OrderBy(x => x.HealthPoints)
                 .ThenBy(x => x.Name)
                 .ToList();

            return output;
        }
    }
}
