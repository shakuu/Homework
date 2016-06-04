
namespace GSM
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    class Call
    {
        private DateTime start;
        private DateTime end;
        private string dialed;

        public Call(DateTime start, DateTime end, string dialedPhoneNumber)
        {
            this.start = start;
            this.end = end;
            this.DialedPhoneNumber = dialedPhoneNumber; 
        }

        public string Date
        {
            get
            {
                return this.start.ToShortDateString();
            }
        }

        public string Time
        {
            get
            {
                return this.start.ToShortTimeString();
            }
        }

        public string DialedPhoneNumber
        {
            get
            {
                return this.dialed;
            }
            set
            {
                this.dialed = value;
            }
        }

        public string Duration
        {
            get
            {
                var dur = this.end - this.start;

                var convert = double.Parse( dur.TotalSeconds.ToString());
                convert = convert * 60 / 100;

                return string.Format("{0} sec", convert.ToString("f0"));
            }
        }

        public override string ToString()
        {
            var output = new StringBuilder();

            output.AppendFormat("{0, -10}|{1, 15}{2}", "Date", this.Date, Environment.NewLine);
            output.AppendFormat("{0, -10}|{1, 15}{2}", "Time", this.Time, Environment.NewLine);
            output.AppendFormat("{0, -10}|{1, 15}{2}", "Duration", this.Duration, Environment.NewLine);
            output.AppendFormat("{0, -10}|{1, 15}{2}", "To Number", this.DialedPhoneNumber, Environment.NewLine);

            return output.ToString();
        }
    }
}
