// TODO: ADD input validation

namespace GSM
{
    using System;

    class Battery
    {
        private string model;
        private int hoursIdle;
        private int hoursTalk;

        private enum BatteryType { LiIon, NiMH, NiCd };

        public Battery() { }
        public Battery(string model, int hoursIdle, int hoursTalk)
        {
            this.Model = model;
            this.IdleTime = hoursIdle;
            this.TalkTime = hoursTalk;
        }

        // Properties
        public string Model
        {
            get
            {
                return this.model;
            }
            set
            {
                this.model = value;
            }
        }
        public int IdleTime
        {
            get
            {
                return this.hoursIdle;
            }
            set
            {
                this.hoursIdle = value;
            }
        }
        public int TalkTime
        {
            get
            {
                return this.hoursTalk;
            }
            set
            {
                this.hoursTalk = value;
            }
        }
    }
}
