using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldFever3
{
    public class GoldFever3
    {
        public static void Main()
        {
            var daysCount = int.Parse(Console.ReadLine());
            var quotes = Console.ReadLine().Split(' ').Select(int.Parse);

            // item1 = profit, item2 = ounces
            var results = new LinkedList<KeyValuePair<long, int>>();
            results.AddLast(new KeyValuePair<long, int>(0, 0));
            results.AddLast(new KeyValuePair<long, int>(-quotes.First(), 1));

            quotes = quotes.Skip(1);

            foreach (var nextQuote in quotes)
            {
                //var nextQuote = quotes[quoteIndex];

                var currentBestOunces = new KeyValuePair<long, int>(long.MinValue, -1);
                var currentBestProfit = new KeyValuePair<long, int>(long.MinValue, 1);

                foreach (var result in results)
                {
                    var buyPair = new KeyValuePair<long, int>(result.Key - nextQuote, result.Value + 1);
                    var sellPair = new KeyValuePair<long, int>(result.Value * nextQuote + result.Key, 0);

                    var currentPairs = new KeyValuePair<long, int>[3]
                    {
                        buyPair,
                        sellPair,
                        result
                    };

                    //currentPairs.AddLast(buyPair);
                    //currentPairs.AddLast(sellPair);
                    //currentPairs.AddLast(result);

                    foreach (var pair in currentPairs)
                    {
                        if (currentBestOunces.Value < pair.Value)
                        {
                            currentBestOunces = pair;
                        }
                        else if (currentBestOunces.Value == pair.Value && currentBestOunces.Key < pair.Key)
                        {
                            currentBestOunces = pair;
                        }

                        if (currentBestProfit.Key < pair.Key)
                        {
                            currentBestProfit = pair;
                        }
                        else if (currentBestProfit.Key == pair.Key && currentBestProfit.Value < pair.Value)
                        {
                            currentBestProfit = pair;
                        }
                    }
                }

                // best ounces + best profit only
                results = new LinkedList<KeyValuePair<long, int>>();
                results.AddLast(currentBestOunces);
                results.AddLast(currentBestProfit);
            }

            long bestProfit = 0;
            foreach (var result in results)
            {
                if (bestProfit < result.Key)
                {
                    bestProfit = result.Key;
                }
            }

            Console.WriteLine(bestProfit);
        }
    }
}
