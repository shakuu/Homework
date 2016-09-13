using System.Threading;

using ThreadTesting.Workers.Models;

namespace ThreadTesting.ConsoleClient
{
    public class Startup
    {
        public static void Main()
        {
            var tester = new PrimeTester(17);
            var first = new Thread(tester.RunTest);
            first.Start();
            first.Join();

            System.Console.WriteLine(tester.IsPassing);
        }
    }
}
