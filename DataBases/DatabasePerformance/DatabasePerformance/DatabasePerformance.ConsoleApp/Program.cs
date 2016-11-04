using System;
using System.Diagnostics;
using System.Linq;

using DatabasePerformance.Data;

namespace DatabasePerformance.ConsoleApp
{
    public class Program
    {
        public static void Main()
        {
            var start = new DateTime(2010, 10, 10);
            var end = new DateTime(2011, 11, 11);

            var context = new PerformanceDbContext();

            Program.Warmup(context);
            Program.SearchWithoutIndex(context, start, end);
            Program.SearchWithIndex(context, start, end);
        }

        private static void Warmup(PerformanceDbContext context)
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            var result = context.ModelsWithIndex.FirstOrDefault();
            stopwatch.Stop();

            Console.WriteLine($"Warmup: {stopwatch.ElapsedMilliseconds}ms");
        }

        private static void SearchWithoutIndex(PerformanceDbContext context, DateTime start, DateTime end)
        {
            var stopwatch = new Stopwatch();

            stopwatch.Start();
            var result = context.ModelsWithoutIndex.Where(m => m.Date >= start && m.Date <= end).ToList();
            stopwatch.Stop();

            Console.WriteLine($"Without Index: {stopwatch.ElapsedMilliseconds}ms");
        }

        private static void SearchWithIndex(PerformanceDbContext context, DateTime start, DateTime end)
        {
            var stopwatch = new Stopwatch();

            stopwatch.Start();
            var result = context.ModelsWithIndex.Where(m => m.Date >= start && m.Date <= end).ToList();
            stopwatch.Stop();

            Console.WriteLine($"With Index: {stopwatch.ElapsedMilliseconds}ms");
        }
    }
}
