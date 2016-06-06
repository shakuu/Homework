
namespace Homework3
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Extensions;
    class StartUp
    {
        static Random rng = new Random();

        static void Main()
        {
            var test = new StringBuilder().Append("0123456789");

            Console.WriteLine(test.Substring(10));
        }
    }
}
