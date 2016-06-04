
namespace GSM
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    class GSMTest
    {
        public static void Test()
        {
            var arrGsm = new GSM[]
            {
                GSM.Iphone4S,
                new GSM("Samsung", "Galaxy"),
                new GSM("HTC", "Whatever"),
                GSM.Iphone4S
            };

            foreach (var gsm in arrGsm)
            {
                Console.WriteLine(gsm.ToString());
            }

            Console.WriteLine(GSM.Iphone4S.ToString());
        }
    }
}
