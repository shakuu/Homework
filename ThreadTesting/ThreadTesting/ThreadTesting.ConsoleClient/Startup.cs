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
            var rangeTester = new PrimeRangeTester(constructor);

            IEnumerable<int> values;
            var nt = new Thread(rangeTester.StartTest);
            nt.Start();
            do
            {
                values = rangeTester.GetUpdatedRange();
                var intermediateSum = values.Sum();
                Console.WriteLine(intermediateSum);
                Thread.Sleep(500);

            } while (rangeTester.TestsAreRunning);

            values = rangeTester.GetUpdatedRange();
            var sum = values.Sum();
            Console.WriteLine(sum);
        }
    }
}
