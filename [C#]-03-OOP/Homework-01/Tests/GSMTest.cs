
namespace GSM
{
    using System;

    class GSMTest
    {
        public static void Test()
        {
            Console.WriteLine( "Problem 7. GSM test"
                   + Environment.NewLine);

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
