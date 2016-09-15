using System;
using System.Linq;
using System.Threading;

using ThreadTesting.Workers.Models;

namespace ThreadTesting.ConsoleClient
{
    public class Startup
    {
        public static void Main()
        {
            var constructor = typeof(PrimeTester).GetConstructor(new[] { typeof(int) });
            var rangeTester = new PrimeRangeTester(2, 99999, constructor);

            var nt = new Thread(rangeTester.RunTests);
            nt.Start();
            do
            {
                Console.WriteLine(rangeTester.GetUpdatedRange().Count());
                Thread.Sleep(1000);

            } while (rangeTester.TestsAreRunning);

            Console.WriteLine(rangeTester.GetUpdatedRange().Count());
        }
    }
}
