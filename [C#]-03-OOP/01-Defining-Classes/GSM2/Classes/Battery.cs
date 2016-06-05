// TODO: ADD input validation

namespace GSM
{
    using System;

    class Battery
    {
        private string model;
        private int hoursIdle;
        private int hoursTalk;

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


                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Battery Model is empty");
                }

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
                if (value <= 0)
                {
                    throw new ArgumentException("Battery Idle Time should be a positive number");
                }

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
                if (value <= 0)
                {
                    throw new ArgumentException("Battery Talk Time should be a positive number");
                }

                this.hoursTalk = value;
            }
        }
        public enum BatteryType { LiIon, NiMH, NiCd };
    }
}
