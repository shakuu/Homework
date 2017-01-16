using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldFever7Increasing
{
    class GoldFeverIncreasing
    {
        static void Main(string[] args)
        {
            var daysCount = int.Parse(Console.ReadLine());
            var quotes = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            int currentOunces = 0;
            long currentCost = 0;
            long currentSum = 0;

            var previousQuote = quotes[0];
            for (int nextQuoteIndex = 1; nextQuoteIndex < quotes.Length; nextQuoteIndex++)
            {
                var nextQuote = quotes[nextQuoteIndex];

                if (previousQuote < nextQuote)
                {
                    currentOunces++;
                    currentCost += previousQuote;
                }
                else if (previousQuote == nextQuote)
                {
                    // do nothing ? 
                }
                else
                {
                    currentSum += currentOunces * previousQuote - currentCost;
                    currentOunces = 0;
                    currentCost = 0;
                }

                previousQuote = nextQuote;
            }

            currentSum += currentOunces * previousQuote - currentCost;
            Console.WriteLine(currentSum);
        }
    }
}
