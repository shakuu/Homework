// Find Longest Call and Remove it

namespace GSM
{
    using System;

    public class GSMCallHistoryTest
    {
        public static void Test(Random random)
        {
            Console.WriteLine(Environment.NewLine 
                + "Problem 12. Call history test"
                + Environment.NewLine);


            // Creath a GSM
            var testGSM = GSM.Iphone4S;

            // Add Calls
            var numberOfCalls = random.Next(5, 21);
            for (int i = 0; i < numberOfCalls; i++)
            {
                testGSM.AddCall(
                        DateTime.Now,
                        DateTime.Now.AddSeconds(random.Next(1, 300)),
                        "00359888818284");
            }

            // Display Call History And total cost
            Console.WriteLine(testGSM.DisplayCallHistory);
            Console.WriteLine("Total Cost: {0}",
                testGSM.CallHistoryCost((decimal)0.37).ToString("C2"));

            #region Optional
            //Console.WriteLine("Which Call To Remove");
            //var remove = int.Parse(Console.ReadLine());
            //testGSM.DeleteCall(remove);
            #endregion

            // Remove the longest call
            testGSM.RemoveLongestCall();

            // Display New Call History
            Console.WriteLine();
            Console.WriteLine(testGSM.DisplayCallHistory);
            Console.WriteLine("Total Cost: {0}",
                testGSM.CallHistoryCost((decimal)0.37).ToString("C2"));

            testGSM.ClearCallHistory();
        }
    }
}
