
namespace GSM
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    class GSMTest
    {
        private List<GSM> gsmTest = new List<GSM>();

        public void AddGSM(string manufacturer, string model)
        {
            var gsm = new GSM(manufacturer, model);

            this.gsmTest.Add(gsm);
        }

        public void AddGSM(GSM gsm)
        {
            this.gsmTest.Add(gsm);
        }

        public void AddGSM()
        {
            var gms = new GSM();

            this.gsmTest.Add(gms);
        }

        public void DisplayAll()
        {
            foreach (var gsm in this.gsmTest)
            {
                Console.WriteLine(gsm.ToString());
            }
        }

        public void DisplayIphone4s()
        {
            Console.WriteLine(GSM.iphone4s.ToString());
        }
    }
}
