
namespace GSM
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    class GSM
    {
        // statics field
        public static GSM iphone4s = new GSM()
        {
            Manufacturer = "Apple",
            model = "Iphone 4s",
            owner = "unknown",
            price = 1000
        };

        // Fields.
        private string model;
        private string manufacturer;
        private string owner;
        private int? price;
        private Battery battery;
        private Display display;
        private List<Call> calls;

        // Constructors
        public GSM()
        {
            this.Model = null;
            this.Manufacturer = null;
            this.Owner = null;
            this.Price = null;
            this.battery = new Battery();
            this.display = new Display();
            this.calls = new List<Call>();
        }

        public GSM(string manufacturer, string model) : this()
        {
            this.model = model;
            this.manufacturer = manufacturer;
        }

        public GSM(string model,
            string manufacturer,
            string owner,
            int price,
            string btryModel,
            int btryHoursIdle,
            int btryHoursTalk,
            int dispSize,
            int dispColors)
        {
            this.model = model;
            this.manufacturer = manufacturer;
            this.owner = owner;
            this.price = price;

            this.battery = new Battery
                (btryModel, btryHoursIdle, btryHoursTalk);

            this.display = new Display
                (dispSize, dispColors);

            this.calls = new List<Call>();
        }

        // Properties
        public GSM Iphone4s
        {
            get
            {
                return iphone4s;
            }
        }

        public string Model
        {
            get { return this.model; }
            set { this.model = value; }
        }

        public string Manufacturer
        {
            get { return this.manufacturer; }
            set { this.manufacturer = value; }
        }

        public string Owner
        {
            get { return this.owner; }
            set { this.owner = value; }
        }

        public int? Price
        {
            get { return this.price; }
            set { this.price = value; }
        }

        public string BatteryModel
        {
            get { return this.battery.Model; }
            set { this.battery.Model = value; }
        }

        public List<Call> CallHistory
        {
            get
            {
                return this.calls;
            }
        }

        public string Calls
        {
            get
            {
                var output = new StringBuilder();

                for (int call = this.calls.Count - 1; call >= 0; call--)
                {
                    output.AppendFormat("{0, -10}|{1, 15}{2}", "Index", call, Environment.NewLine);
                    output.AppendLine(calls[call].ToString());
                }

                return output.ToString();
            }
        }

        // Overrides.
        public override string ToString()
        {
            var output = new StringBuilder();

            output.AppendFormat
               ("{0,-20}:{1, 10}{2}", "Manufacturer", this.manufacturer, Environment.NewLine);
            output.AppendFormat
               ("{0,-20}:{1, 10}{2}", "Model", this.model, Environment.NewLine);
            output.AppendFormat
               ("{0,-20}:{1, 10}{2}", "Owner", this.owner, Environment.NewLine);
            output.AppendFormat
               ("{0,-20}:{1, 10}{2}", "Price", this.price, Environment.NewLine);
            output.AppendFormat
               ("{0,-20}:{1, 10}{2}", "Battery model", this.battery.Model, Environment.NewLine);
            output.AppendFormat
               ("{0,-20}:{1, 10}{2}", "Battery idle time", this.battery.HoursIdle, Environment.NewLine);
            output.AppendFormat
               ("{0,-20}:{1, 10}{2}", "Battery idle time", this.battery.HoursTalk, Environment.NewLine);
            output.AppendFormat
               ("{0,-20}:{1, 10}{2}", "Display size", this.display.Size, Environment.NewLine);
            output.AppendFormat
               ("{0,-20}:{1, 10}{2}", "Display colors", this.display.Colors, Environment.NewLine);

            return output.ToString();
        }

        // Methods.
        public void AddCall(DateTime start, DateTime end, string dialedNumber)
        {
            this.calls.Add(new Call(start, end, dialedNumber));
        }

        public void ClearCallHistory()
        {
            this.calls = new List<Call>();
        }

        public void DeleteCall()
        {
            Console.WriteLine(this.calls);
            Console.WriteLine("Choose an index to delete");
            var index = int.Parse(Console.ReadLine());

            this.calls.RemoveAt(index);
        }

        public int CallPrice(double price)
        {
            var totalCallDuration = 0;

            foreach (var call in this.calls)
            {
                totalCallDuration += int.Parse( call.Duration);
            }

            var cost = totalCallDuration / 60 * price;
            
            return cost;
        }
    }
}
