
namespace GSM
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    class Battery
    {
        // Fields.
        private string model;
        private int? hoursIdle;
        private int? hoursTalk;

        private enum BatteryType { LiIon, NiMH, NiCd };

        // Constructors.
        public Battery()
        {
        }

        public Battery(string model, int hoursIdle, int hoursTalk)
        {
            this.model = model;
            this.hoursIdle = hoursIdle;
            this.hoursTalk = hoursTalk;
        }

        // Properties
        public string Model
        {
            get { return this.model; }
            set { this.model = value; }
        }

        public int? HoursIdle
        {
            get { return this.hoursIdle; }
            set
            {
                if (value < 0) throw new ArgumentException();
                this.hoursIdle = value;
            }
        }

        public int? HoursTalk
        {
            get
            {
                return this.hoursTalk;
            }
            set
            {
                if (value < 0) throw new ArgumentException();
                else this.hoursTalk = value;
            }
        }
    }
}
