using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldFever3Again
{
    public class GoldFever3LinkedList
    {
        private static int daysCount;
        private static int[] quotes;
        private static long bestOutcome;
        //private static int bestOutcomeOunces;

        public static void Main()
        {
            daysCount = int.Parse(Console.ReadLine());
            quotes = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            //GenerateOutcome(0, 0, 0);
            //GenerateOutcome(0, -quotes[0], 1);

            var profitStack = new List<long>();
            profitStack.Add(0);
            profitStack.Add(-quotes[0]);

            var ouncesStack = new List<int>();
            ouncesStack.Add(0);
            ouncesStack.Add(1);

            var quotesStack = new List<int>();
            quotesStack.Add(0);
            quotesStack.Add(0);

            var profitStackEnumerator = profitStack.GetEnumerator();
            var ouncesStackEnumerator = ouncesStack.GetEnumerator();
            var quotesStackEnumerator = quotesStack.GetEnumerator();

            var nextQuoteIndex = 0;
            while (profitStackEnumerator.MoveNext() && ouncesStackEnumerator.MoveNext() && quotesStackEnumerator.MoveNext())
            {
                var profit = profitStackEnumerator.Current;
                var ounces = ouncesStackEnumerator.Current;
                var quoteIndex = quotesStackEnumerator.Current;

                if (bestOutcome < profit)
                {
                    bestOutcome = profit;
                    //bestOutcomeOunces = ounces;
                }

                nextQuoteIndex = quoteIndex + 1;
                if (daysCount <= nextQuoteIndex)
                {
                    continue;
                }

                var nextQuote = GoldFever3LinkedList.quotes[nextQuoteIndex];

                //profitStack.Push(profit);
                //ouncesStack.Push(ounces);
                //quotesStack.Push(nextQuoteIndex);

                profitStack.Add(profit - nextQuote);
                ouncesStack.Add(ounces + 1);
                quotesStack.Add(nextQuoteIndex);

                var sellProfit = (ounces * nextQuote) + profit;
                if (sellProfit >= 0)
                {
                    profitStack.Add(sellProfit);
                    ouncesStack.Add(0);
                    quotesStack.Add(nextQuoteIndex);
                }
            }

            Console.WriteLine(bestOutcome);
        }

        private static void GenerateOutcome(int currentQuoteIndex, long profit, int ounces)
        {
            if (bestOutcome < profit)
            {
                bestOutcome = profit;
            }

            var nextQuoteIndex = currentQuoteIndex + 1;
            if (daysCount <= nextQuoteIndex)
            {
                return;
            }

            var nextQuote = GoldFever3LinkedList.quotes[nextQuoteIndex];
            GoldFever3LinkedList.GenerateOutcome(nextQuoteIndex, profit, ounces);
            GoldFever3LinkedList.GenerateOutcome(nextQuoteIndex, profit - nextQuote, ounces + 1);
            GoldFever3LinkedList.GenerateOutcome(nextQuoteIndex, ounces * nextQuote + profit, 0);
        }
    }
}
