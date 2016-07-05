namespace WarMachines.Machines
{
    using System.Text;

    using WarMachines.Interfaces;

    internal class Fighter : Machine, IFighter
    {
        private const string FormatStealthMode = " *Stealth: {0}";
        private const string FormatStealthModeON = "ON";
        private const string FormatStealthModeOFF = "OFF";

        private const double FigtherInitialHealthPoints = 200;

        private bool stealthMode;

        public Fighter(string name, double attackPoints, double defensePoints, bool stealthMode)
            : base(name, attackPoints, defensePoints)
        {
            base.HealthPoints = 200;
            this.StealthMode = stealthMode;
        }

        public bool StealthMode
        {
            get
            {
                return this.stealthMode;
            }
            private set
            {
                this.stealthMode = value;
            }
        }

        public void ToggleStealthMode()
        {
            this.StealthMode = !this.StealthMode;
        }

        public override string ToString()
        {
            var output = new StringBuilder();

            output.Append(base.ToString());

            output.AppendFormat(FormatStealthMode,
                this.StealthMode
                ? FormatStealthModeON
                : FormatStealthModeOFF);

            return output.ToString();
        }
    }
}
