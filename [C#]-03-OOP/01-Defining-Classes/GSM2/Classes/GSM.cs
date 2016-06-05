// TODO: Validate input.

namespace GSM
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    class GSM
    {
        private static GSM iphone4s = new GSM("Apple", "Iphone 4S")
        {
            Owner = "Steve Jobs",
            Price = 600,
            BatteryModel = "n/a",
            BatteryIdleTime = 100,
            BatteryTalkTime = 4,
            DisplaySize = 4,
            DisplayColors = 16000000
        };

        // Fields
        private string manufacturer;
        private string model;
        private string owner;
        private int price;

        private Battery battery;
        private Display display;

        private List<Call> calls;

        // Constructors.
        public GSM(string make, string model)
        {
            this.Manufacturer = make;
            this.Model = model;

            this.battery = new Battery();
            this.display = new Display();

            this.calls = new List<Call>();
        }
        public GSM(string make, string model, string owner, int price,
            string batteryModel, int batteryIdelTime, int batteryTalkTime,
            int displaySize, int displayColors) : this(make, model)
        {
            this.Owner = owner;
            this.Price = price;

            this.BatteryModel = model;
            this.BatteryIdleTime = batteryIdelTime;
            this.BatteryTalkTime = batteryTalkTime;

            this.DisplaySize = displaySize;
            this.DisplayColors = displayColors;
        }

        // Properties
        public string Manufacturer
        {
            get
            {
                return this.manufacturer;
            }
            set
            {
                if (!char.IsUpper(value[0]))
                {
                    throw new ArgumentException("Manufacturer Brand should begin with a capital letter");
                }

                this.manufacturer = value;
            }
        }
        public string Model
        {
            get
            {
                return this.model;
            }
            set
            {
                if (!(char.IsUpper(value[0]) || char.IsDigit(value[0])) )
                {
                    throw new ArgumentException("Model should begin with a capital letter or number");
                }

                this.model = value;
            }
        }
        public string Owner
        {
            get
            {
                return this.owner;
            }
            set
            {
                if (!char.IsUpper(value[0]))
                {
                    throw new ArgumentException("Owner name should begin with a capital letter");
                }

                this.owner = value;
            }
        }
        public int Price
        {
            get
            {
                return this.price;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Price cannot be a negative number");
                }

                this.price = value;
            }
        }
        public string BatteryModel
        {
            get
            {
                return this.battery.Model;
            }
            set
            {
                this.battery.Model = value;
            }
        }
        public int BatteryIdleTime
        {
            get
            {
                return this.battery.IdleTime;
            }
            set
            {
                this.battery.IdleTime = value;
            }
        }
        public int BatteryTalkTime
        {
            get
            {
                return this.battery.TalkTime;
            }
            set
            {
                this.battery.TalkTime = value;
            }
        }
        public int DisplaySize
        {
            get
            {
                return this.display.Size;
            }
            set
            {
                this.display.Size = value;
            }
        }
        public int DisplayColors
        {
            get
            {
                return this.display.Colors;
            }
            set
            {
                this.display.Colors = value;
            }
        }
        //public List<Call> CallHistory
        //{
        //    get
        //    {
        //        return this.calls;
        //    }
        //}
        public string DisplayCallHistory
        {
            get
            {
                var separator = '+';
                var fill = new string('-', 10);
                var smallFill = new string('-', 4);

                var format = "|{0, 4}{1}{2}";
                var output = new StringBuilder();

                output.Append(
                    separator + smallFill
                    + separator + fill
                    + separator + fill
                    + separator + fill
                    + separator + fill + fill + separator
                    + Environment.NewLine);

                output.AppendFormat("|{5, 4}|{0, 10}|{1, 10}|{2, 10}|{3, 20}|{4}",
                    "Date ", "Time ", "Duration ", "Number ", Environment.NewLine, "Nr.");

                for (int call = 0; call < this.calls.Count; call++)
                {
                    output.Append(
                        separator + smallFill
                        + separator + fill
                        + separator + fill
                        + separator + fill
                        + separator + fill + fill + separator
                        + Environment.NewLine);

                    output.AppendFormat(format, call, calls[call].ToString(), Environment.NewLine);
                }

                output.Append(
                        separator + smallFill
                        + separator + fill
                        + separator + fill
                        + separator + fill
                        + separator + fill + fill + separator
                        + Environment.NewLine);

                return output.ToString();
            }
        }

        // Static Properties.
        public static GSM Iphone4S
        {
            get
            {
                return iphone4s;
            }
        }

        // Methods.
        public override string ToString()
        {
            var toString = new StringBuilder();
            toString.Append('+' + new String('-', 20) + '+' + new String('-', 20) + '+' + Environment.NewLine);
            toString.AppendFormat("|{0, -20}|{1, 20}|{2}", "Manufacturer", this.Manufacturer, Environment.NewLine);
            toString.AppendFormat("|{0, -20}|{1, 20}|{2}", "Model", this.Model, Environment.NewLine);
            toString.AppendFormat("|{0, -20}|{1, 20}|{2}", "Owner", this.Owner, Environment.NewLine);
            toString.AppendFormat("|{0, -20}|{1, 20}|{2}", "Price", this.Price, Environment.NewLine);
            toString.AppendFormat("|{0, -20}|{1, 20}|{2}", "Battery Model", this.BatteryModel, Environment.NewLine);
            toString.AppendFormat("|{0, -20}|{1, 20}|{2}", "Battery Idle Time", this.BatteryIdleTime, Environment.NewLine);
            toString.AppendFormat("|{0, -20}|{1, 20}|{2}", "Battery Talk Time", this.BatteryTalkTime, Environment.NewLine);
            toString.AppendFormat("|{0, -20}|{1, 20}|{2}", "Display Size", this.DisplaySize, Environment.NewLine);
            toString.AppendFormat("|{0, -20}|{1, 20}|{2}", "Display Colors", this.DisplayColors, Environment.NewLine);
            toString.Append('+' + new String('-', 20) + '+' + new String('-', 20) + '+' + Environment.NewLine);

            return toString.ToString();
        }

        public void ClearCallHistory()
        {
            this.calls = new List<Call>();
        }
        public void AddCall(DateTime start, DateTime end, string number)
        {
            this.calls.Add(new Call(start, end, number));
        }
        public void AddCall(Call addMe)
        {
            this.calls.Add(addMe);
        }
        public void DeleteCall(int ID)
        {
            this.calls.RemoveAt(ID);
        }
        public decimal CallHistoryCost(decimal price)
        {
            var totalCalls = (decimal)0;

            foreach (var call in this.calls)
            {
                totalCalls += call.Duration / (decimal)60;
            }

            return totalCalls * price;
        }
    }
}
