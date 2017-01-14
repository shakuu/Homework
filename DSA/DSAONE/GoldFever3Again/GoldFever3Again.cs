using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldFever3
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

    public class GoldFever3
    {
        public static void Main()
        {
            var daysCount = int.Parse(Console.ReadLine());
            var quotes = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            // item1 = profit, item2 = ounces
            long bestProfit = 0;

            var results = new HashSet<ResultPair>();
            results.Add(new ResultPair(0, 0));
            results.Add(new ResultPair(-quotes[0], 1));

            for (int quoteIndex = 1; quoteIndex < quotes.Length; quoteIndex++)
            {
                var nextQuote = quotes[quoteIndex];

                var nextResultsSet = new HashSet<ResultPair>();
                foreach (var result in results)
                {
                    nextResultsSet.Add(new ResultPair(result.Profit - nextQuote, result.Ounces + 1));
                    nextResultsSet.Add(result);
                    nextResultsSet.Add(new ResultPair(result.Ounces * nextQuote + result.Profit, 0));
                }

                results = nextResultsSet;
            }

            foreach (var result in results)
            {
                if (bestProfit < result.Profit)
                {
                    bestProfit = result.Profit;
                }
            }

            //var tupleQueue = new Queue<Tuple<long, long>>();
            //tupleQueue.Enqueue(new Tuple<long, long>(0, 0));
            //tupleQueue.Enqueue(new Tuple<long, long>(-quotes[0], 1));

            //for (int quoteIndex = 1; quoteIndex < quotes.Length; quoteIndex++)
            //{
            //    var nextQuote = quotes[quoteIndex];

            //    var resultingQueue = new Queue<Tuple<long, long>>();
            //    while (tupleQueue.Count > 0)
            //    {
            //        var nextTuple = tupleQueue.Dequeue();
            //        if (bestProfit < nextTuple.Item1)
            //        {
            //            bestProfit = nextTuple.Item1;
            //        }

            //        resultingQueue.Enqueue(new Tuple<long, long>(nextTuple.Item1 - nextQuote, nextTuple.Item2 + 1));
            //        resultingQueue.Enqueue(nextTuple);
            //        resultingQueue.Enqueue(new Tuple<long, long>(nextTuple.Item2 * nextQuote + nextTuple.Item1, 0));
            //    }

            //    tupleQueue = resultingQueue;
            //}

            //while (tupleQueue.Count > 0)
            //{
            //    var nextTuple = tupleQueue.Dequeue();
            //    if (bestProfit < nextTuple.Item1)
            //    {
            //        bestProfit = nextTuple.Item1;
            //    }
            //}

            Console.WriteLine(bestProfit);
        }
    }
}
