// Find Longest Call and Remove it

namespace GSM
{
    using System;

    public class GSMCallHistoryTest
    {
        public static void Test()
        {
            // Creath a GSM
            var testGSM = GSM.Iphone4S;

            var random = new Random();

            for (int i = 0; i < 5; i++)
            {
                testGSM.AddCall(
                        DateTime.Now, 
                        DateTime.Now.AddSeconds(random.Next(1 , 300)), 
                        "00359888818284");
            }

            Console.WriteLine(testGSM.DisplayCallHistory);

            Console.WriteLine(testGSM.CallHistoryCost((decimal)0.37).ToString("F2"));

            var remove = int.Parse(Console.ReadLine());

            testGSM.DeleteCall(remove);

            Console.WriteLine(testGSM.CallHistoryCost((decimal)0.37).ToString("F2"));

            testGSM.ClearCallHistory();

            Console.WriteLine(testGSM.DisplayCallHistory);
        }
    }
}
