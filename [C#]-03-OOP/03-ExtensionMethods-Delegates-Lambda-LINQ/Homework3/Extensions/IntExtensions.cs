
namespace Homework3.Extensions
{
    using System;
    using System.Linq;

    public static class IntExtensions
    {
        public static void PrintDivBy7And3(this int[] array)
        {
            var output = array
                .Where(number => number % 7 == 0 && number % 3 == 0)
                .ToArray();

            Console.WriteLine(string.Join(", ", output));
        }
    }
}
