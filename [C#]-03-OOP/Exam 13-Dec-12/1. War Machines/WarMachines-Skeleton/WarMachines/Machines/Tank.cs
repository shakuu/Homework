namespace WarMachines.Machines
{
    using System.Text;

    using WarMachines.Interfaces;

    internal class Tank : Machine, ITank
    {
        private const string FormatDefenseMode = " *Defense: {0}";
        private const string FormatDefenseModeON = "ON";
        private const string FormatDefenseModeOFF = "OFF";
        
        private const double DefenseModeOnDefenseBonus = 30;
        private const double DefenseModeOnAttackBonus = -40;

        private const double TankInitialHealthPoints = 100;

        private bool defenseMode;

        public Tank(string name, double attackPoints, double defensePoints)
            : base(name, attackPoints, defensePoints)
        {
            base.HealthPoints = TankInitialHealthPoints;
            this.ToggleDefenseMode();
        }

        public bool DefenseMode
        {
            get
            {
                return this.defenseMode;
            }
            private set
            {

                // TODO: Validate
                this.defenseMode = value;
            }
        }

        public void ToggleDefenseMode()
        {
            if (this.DefenseMode)
            {
                this.DefenseMode = false;
                this.DefensePoints -= DefenseModeOnDefenseBonus;
                this.AttackPoints -= DefenseModeOnAttackBonus;
            }
            else
            {
                this.DefenseMode = true;
                this.DefensePoints += DefenseModeOnDefenseBonus;
                this.AttackPoints += DefenseModeOnAttackBonus;
            }
        }

        public override string ToString()
        {
            var output = new StringBuilder();

            output.Append(base.ToString());

            output.AppendFormat(FormatDefenseMode, 
                this.DefenseMode 
                ? FormatDefenseModeON
                : FormatDefenseModeOFF);

            return output.ToString();
        }
    }
}
