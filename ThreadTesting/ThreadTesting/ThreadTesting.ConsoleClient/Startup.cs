using System;
using System.Collections.Generic;
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
            var rangeTester = new PrimeRangeTester(500, 1500, constructor);

            var nt = new Thread(rangeTester.RunTests);
            nt.Start();
            do
            {
                Console.WriteLine(rangeTester.GetUpdatedRange().Count());
                Thread.Sleep(500);

            } while (rangeTester.TestsAreRunning);

            Console.WriteLine(rangeTester.GetUpdatedRange().Count());
        }
    }
}
