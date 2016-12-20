using System;
using System.Diagnostics;
using Wintellect.PowerCollections;

namespace ProductsOrderedBag
{
    public class Program
    {
        public static void Main()
        {
            var productsBag = new OrderedBag<Product>();

            var random = new Random();
            for (int i = 0; i < 500000; i++)
            {
                var price = random.Next(1, 1000000);
                var product = new Product()
                {
                    Price = price,
                    Name = "product"
                };

                productsBag.Add(product);
            }

            var stopwatch = new Stopwatch();
            for (int i = 0; i < 10000; i++)
            {
                var minRange = 0;
                var maxRange = 0;
                while (minRange >= maxRange)
                {
                    minRange = random.Next(1, 1000000);
                    maxRange = random.Next(1, 1000000);
                }

                stopwatch.Start();
                var query = productsBag.Range(new Product() { Price = minRange }, true, new Product() { Price = maxRange }, true);
                stopwatch.Stop();

                Console.WriteLine($"MinRange: {minRange}, MaxRange: {maxRange}, Count: {query.Count}, Time: {stopwatch.Elapsed}");
                stopwatch.Reset();
            }
        }
    }
}
