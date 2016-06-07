
namespace Homework3
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Extensions;
    using Testing;

    class StartUp
    {
        static Random rng = new Random();

        static void Main()
        {
            //var test = new StringBuilder().Append("0123456789");
            //var test2 = new[] { 10, 1, 2, 3, 4, 5, 6 };

            //var a =  test2.Max();

            //StudentsTesting.MainTest(rng);
            //TimerTesting.TimedEventTest();
            StudentsListTesting.GroupsTesting();

            //StudentsListTesting.CreateNewList(rng);

        }
    }
}
