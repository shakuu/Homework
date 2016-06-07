// TODO: Validate

namespace GSM
{
    using System;
    using System.Text;

    class Call
    {
        private DateTime start;
        private DateTime end;
        private string number;

        public Call(DateTime start, DateTime end, string number)
        {
            this.Start = start;
            this.End = end;
            this.DialedPhoneNumber = number;
        }

        // Private Property for validation
        private DateTime Start
        {
            set
            {
                this.start = value;
            }
        }
        private DateTime End
        {
            set
            {
                this.end = value;
            }
        }

        #region Properties
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
                return this.number;
            }
            private set
            {
                this.number = value;
            }

        }
        public int Duration
        {
            get
            {
                var duration = this.end - this.start;
                var output = int.Parse( duration.TotalSeconds.ToString("F0"));
                return output;
            }
        }
        #endregion

        #region Methods
        public override string ToString()
        {
            //var separator = '+';
            var fill = new string('-', 10);
            var output = new StringBuilder();

            //output.Append(separator
            //    + fill + separator
            //    + fill + separator
            //    + fill + separator
            //    + fill + fill + separator
            //    + Environment.NewLine);

            //output.AppendFormat("|{0, 8}|{1, 8}|{2, 8}|{3, 16}|{4}",
            //    "Date", "Time", "Duration", "Number", Environment.NewLine);

            output.AppendFormat("|{0, 10}|{1, 10}|{2, 10}|{3, 20}|", 
                this.Date,
                this.Time, 
                this.Duration,
                this.DialedPhoneNumber);

            //output.Append(separator
            //    + fill + separator
            //    + fill + separator
            //    + fill + separator
            //    + fill + fill + separator);

            return output.ToString();
        }
        #endregion
    }
}
