using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldFever4
{
    public class ResultPair
    {
        public ResultPair(long profit, int ounces)
        {
            this.Profit = profit;
            this.Ounces = ounces;
        }

        public long Profit { get; set; }

        public int Ounces { get; set; }

        public override int GetHashCode()
        {
            var hash = 199;

            unchecked
            {
                hash = hash * 257 + this.Profit.GetHashCode();
                hash = hash * 257 + this.Ounces.GetHashCode();
            }

            return hash;
        }

        public override bool Equals(object obj)
        {
            var otherResultPair = obj as ResultPair;
            if (otherResultPair == null)
            {
                return false;
            }

            var profitIsEqual = this.Profit == otherResultPair.Profit;
            var ouncesAreEqual = this.Ounces == otherResultPair.Ounces;

            return profitIsEqual && ouncesAreEqual;
        }
    }

    public class GoldFever4
    {
        public static void Main()
        {
            var daysCount = int.Parse(Console.ReadLine());
            var quotes = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            // item1 = profit, item2 = ounces
            long bestProfit = 0;

            var results = new Dictionary<long, long>();
            results.Add(0, 0);
            results.Add(1, -quotes[0]);

            for (int quoteIndex = 1; quoteIndex < quotes.Length; quoteIndex++)
            {
                var nextQuote = quotes[quoteIndex];

                var nextResultsSet = new Dictionary<long, long>();
                foreach (var result in results)
                {
                    var buyKey = result.Key + 1;
                    var containsBuyKey = nextResultsSet.ContainsKey(buyKey);
                    if (!containsBuyKey)
                    {
                        nextResultsSet.Add(buyKey, result.Value - nextQuote);
                    }
                    else
                    {
                        var potentialValue = result.Value - nextQuote;
                        nextResultsSet[buyKey] = nextResultsSet[buyKey] >= potentialValue ? nextResultsSet[buyKey] : potentialValue;
                    }

                    var holdKey = result.Key;
                    var containsHoldKey = nextResultsSet.ContainsKey(holdKey);
                    if (!containsHoldKey)
                    {
                        nextResultsSet.Add(holdKey, result.Value);
                    }
                    else
                    {
                        var potentialValue = result.Value;
                        nextResultsSet[holdKey] = nextResultsSet[holdKey] >= potentialValue ? nextResultsSet[holdKey] : potentialValue;
                    }

                    var sellKey = 0;
                    var sellValue = result.Key * nextQuote + result.Value;
                    var containsSellKey = nextResultsSet.ContainsKey(sellKey);
                    if (!containsSellKey)
                    {
                        nextResultsSet.Add(sellKey, sellValue);
                    }
                    else
                    {
                        nextResultsSet[sellKey] = nextResultsSet[sellKey] >= sellValue ? nextResultsSet[sellKey] : sellValue;
                    }
                }

                results = nextResultsSet;
            }

            foreach (var result in results)
            {
                if (bestProfit < result.Value)
                {
                    bestProfit = result.Value;
                }
            }
            
            Console.WriteLine(bestProfit);
        }
    }
}
