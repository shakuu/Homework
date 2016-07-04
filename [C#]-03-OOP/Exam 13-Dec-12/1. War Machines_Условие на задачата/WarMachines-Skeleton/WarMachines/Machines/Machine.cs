namespace WarMachines.Machines
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Text;
    using WarMachines.Interfaces;
    using WarMachines.Machines.Validation;

    class Machine : IMachine
    {
        private const string FormatMachineName = "- {0}";
        private const string FormatMachineType = " *Type: {0}";
        private const string FormatMachineHealthPoints = " *Health: {0}";
        private const string FormatMachineAttackPoints = " *Attack: {0}";
        private const string FormatMachineDefensePoints = " *Defense: {0}";
        private const string FormatMachineTargets = " *Targets: {0}"; // None / Coma separated
        //*Defense: (“ON”/”OFF” – when applicable)
        //*Stealth: (“ON”/”OFF” – when applicable)

        private IValidator validator;

        private string name;
        private double attackPoints;
        private double defensePoints;
        private double healthPoints;
        private IPilot pilot;
        private Collection<string> targets;

        public Machine(string name, double attackPoints, double defensePoints)
        {
            this.name = name;
            this.AttackPoints = attackPoints;
            this.DefensePoints = defensePoints;

            this.targets = new Collection<string>();
            this.validator = new Validator();
        }

        // TODO: validation
        public double AttackPoints
        {
            get
            {
                return this.attackPoints;
            }
            protected set
            {
                //this.validator.CheckIfNull(value);

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
                // TODO: Validate positive

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
                this.validator.CheckIfNull(value);

                this.pilot = value;
            }
        }

        public IList<string> Targets
        {
            get
            {
                // TODO: Return copy

                return this.targets;
            }
        }

        public void Attack(string target)
        {
            this.Targets.Add(target);
        }
       
        public override string ToString()
        {
            // TODO:
            var output = new StringBuilder();

            output.Append(
                string.Format(
                    FormatMachineName, this.Name)
                    + Environment.NewLine);

            output.Append(
                string.Format(
                    FormatMachineType, this.GetType().Name)
                    + Environment.NewLine);

            output.Append(
                string.Format(
                    FormatMachineHealthPoints, this.HealthPoints)
                    + Environment.NewLine);

            output.Append(
                string.Format(
                    FormatMachineAttackPoints, this.AttackPoints)
                    + Environment.NewLine);

            output.Append(
                string.Format(
                    FormatMachineDefensePoints, this.DefensePoints)
                    + Environment.NewLine);


            output.Append(
                string.Format(
                    FormatMachineTargets,
                        this.Targets.Count == 0
                            ? "None"
                            : string.Join(", ", this.Targets))
                    + Environment.NewLine);


            return output.ToString();
        }
    }
}
