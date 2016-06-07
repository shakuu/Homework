
namespace GSM
{
    using System;

    class StartUp
    {
        static Random random = new Random();

        static void Main()
        {
            // Test 1:
            GSMTest.Test();

            // Test 2:
            GSMCallHistoryTest.Test(random);
        }
    }
}
