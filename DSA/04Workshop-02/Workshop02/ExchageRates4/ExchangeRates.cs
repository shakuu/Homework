using System;
using System.Linq;

namespace ExchageRates4
{
    public class ExchangeRates
    {
        public static void Main()
        {
            var initialCurrency = double.Parse(Console.ReadLine());
            var numberOfDays = int.Parse(Console.ReadLine());

            // [0] -> C1 -> C2; [1] C2 -> C1
            var firstLinePair = Console.ReadLine().Split(' ').Select(double.Parse).ToArray();
            var maximumCurrencyTwo = initialCurrency * firstLinePair[0];
            var maximumCurrencyOne = initialCurrency;

            for (int i = 1; i < numberOfDays; i++)
            {
                var nextLinePair = Console.ReadLine().Split(' ').Select(double.Parse).ToArray();

                var currentCurrencyTwo = maximumCurrencyOne * nextLinePair[0];
                var currentCurrencyOne = maximumCurrencyTwo * nextLinePair[1];

                if (maximumCurrencyTwo < currentCurrencyTwo)
                {
                    maximumCurrencyTwo = currentCurrencyTwo;
                }

                if (maximumCurrencyOne < currentCurrencyOne)
                {
                    maximumCurrencyOne = currentCurrencyOne;
                }
            }

            Console.WriteLine("{0:F2}", maximumCurrencyOne);
        }
    }
}
