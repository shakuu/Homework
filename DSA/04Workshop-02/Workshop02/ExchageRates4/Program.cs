using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExchageRates4
{
    public class Program
    {
        public static void Main()
        {
            var initialCurrency = double.Parse(Console.ReadLine());
            var numberOfDays = int.Parse(Console.ReadLine());

            // [0] -> C1 -> C2; [1] C2 -> C1
            var firstLinePair = Console.ReadLine().Split(' ').Select(double.Parse).ToArray();
            var maximumCurrencyTwo = initialCurrency * firstLinePair[0];

            for (int i = 1; i < numberOfDays; i++)
            {
                var nextLinePair = Console.ReadLine().Split(' ').Select(double.Parse).ToArray();
            }
        }
    }
}
