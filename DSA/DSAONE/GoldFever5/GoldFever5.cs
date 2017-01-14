using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldFever5
{
    public class GoldFever5
    {
        public static void Main()
        {
            var daysCount = int.Parse(Console.ReadLine());
            var quotes = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            // item1 = profit, item2 = ounces
            long bestProfit = 0;

            var results = Enumerable.Range(0, daysCount + 1).Select(x => long.MinValue).ToList();
            results[0] = 0;
            results[1] = -quotes[0];

            var keysToCheck = new HashSet<int>() { 0, 1 };

            for (int quoteIndex = 1; quoteIndex < quotes.Length; quoteIndex++)
            {
                var nextQuote = quotes[quoteIndex];

                var nextKeysToCheck = new HashSet<int>();
                var newResults = Enumerable.Range(0, quoteIndex + 2).Select(x => long.MinValue).ToList();
                //foreach (var key in keysToCheck)
                for (int key = 0; key <= quoteIndex; key++)
                {
                    var ounces = key;
                    var profit = results[key];

                    var buyKey = ounces + 1;
                    var potentialBuyValue = profit - nextQuote;

                    var holdKey = ounces;
                    var potentialHoldValue = profit;

                    var sellKey = 0;
                    var sellValue = ounces * nextQuote + profit;

                    newResults[buyKey] = results[buyKey] >= potentialBuyValue ? results[buyKey] : potentialBuyValue;
                    newResults[holdKey] = results[holdKey] >= potentialHoldValue ? results[holdKey] : potentialHoldValue;
                    newResults[sellKey] = results[sellKey] >= sellValue ? results[sellKey] : sellValue;
                }

                results = newResults;
                results.Add(long.MinValue);
            }

            foreach (var key in keysToCheck)
            {
                if (bestProfit < results[key])
                {
                    bestProfit = results[key];
                }
            }

            Console.WriteLine(bestProfit);
        }
    }
}
