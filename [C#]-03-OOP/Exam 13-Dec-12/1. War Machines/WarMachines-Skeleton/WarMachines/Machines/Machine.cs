namespace WarMachines.Machines
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Text;
    using ToStringFormats;
    using WarMachines.Interfaces;
    using WarMachines.Machines.Validation;

    class Machine : IMachine
    {
        private IValidator validator;
        private IToStringFormatter formatStorage;

        private string name;
        private double attackPoints;
        private double defensePoints;
        private double healthPoints;
        private IPilot pilot;
        private Collection<string> targets;

        public Machine(string name, double attackPoints, double defensePoints)
        {
            this.validator = new Validator();

            this.name = name;
            this.AttackPoints = attackPoints;
            this.DefensePoints = defensePoints;

            this.targets = new Collection<string>();
        }

        protected IValidator Validator
        {
            get
            {
                return this.validator;
            }
        }

        public double AttackPoints
        {
            get
            {
                return this.attackPoints;
            }
            protected set
            {
                //this.validator.CheckIfPositive(value);
                this.attackPoints = value;
            }
        }

        public double DefensePoints
        {
            get
            {
                return this.defensePoints;
            }

            protected set
            {
                //this.validator.CheckIfPositive(value);
                this.defensePoints = value;
            }
        }

        public double HealthPoints
        {
            get
            {
                return this.healthPoints;
            }

            set
            {
                //this.validator.CheckIfPositive(value);
                this.healthPoints = value;
            }
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                this.validator.CheckIfNull(
                    value,
                    this.GetType().Name,
                    nameof(Name));

                this.name = value;
            }
        }

        public IPilot Pilot
        {
            get
            {
                return this.pilot;
            }

            set
            {
                this.validator.CheckIfNull(
                    value,
                    this.GetType().Name,
                    nameof(this.Pilot));

                this.pilot = value;
            }
        }

        public IList<string> Targets
        {
            get
            {
                return new Collection<string>(this.targets);
            }
        }

        public void Attack(string target)
        {
            this.Targets.Add(target);
        }

        /// <summary>
        /// Returns a string for each child to update with it's class 
        /// specific properties.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            this.formatStorage = new ToStringFormat();

            var output = new StringBuilder();

            output.Append(
                string.Format(
                    formatStorage[MachineLineNumberType.Line01], this.Name)
                    + Environment.NewLine);

            output.Append(
                string.Format(
                    formatStorage[MachineLineNumberType.Line02], this.GetType().Name)
                    + Environment.NewLine);

            output.Append(
                string.Format(
                    formatStorage[MachineLineNumberType.Line03], this.HealthPoints)
                    + Environment.NewLine);

            output.Append(
                string.Format(
                    formatStorage[MachineLineNumberType.Line04], this.AttackPoints)
                    + Environment.NewLine);

            output.Append(
                string.Format(
                    formatStorage[MachineLineNumberType.Line05], this.DefensePoints)
                    + Environment.NewLine);

            output.Append(
                string.Format(
                    formatStorage[MachineLineNumberType.Line06],
                        this.Targets.Count == 0
                            ? "None"
                            : string.Join(", ", this.Targets))
                    + Environment.NewLine);


            return output.ToString();
        }
    }
}
