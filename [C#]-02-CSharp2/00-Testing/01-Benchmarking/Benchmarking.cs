namespace MethodExecutionProfiler
{
    using System;
    using System.Diagnostics;
    using System.Text;
    using System.Threading;

    public class Startup
    {
        static void Main(string[] args)
        {
            // Testing with NaiveBenchmark method
            var cycles = 10000000;
            var totalExecutionTimeNaive = NaiveBenchmark(cycles, DecimalToHexadecimal);
            var averageExecutionTimePerCycleNaive =
                (decimal)(totalExecutionTimeNaive.TotalMilliseconds) / cycles;
            Console.WriteLine(
                $"(Naive)Total execution time for {cycles} cycles: {totalExecutionTimeNaive.TotalMilliseconds} ms.");
            Console.WriteLine(
                $"(Naive)Average execution time per cycle: {averageExecutionTimePerCycleNaive} ms.");

            // Testing with ComplexBenchmark method
            var emptyForCycleExecutionTime = ProfileEmptyForCycle(cycles);
            var totalExecutionTimeComplex = ComplexBenchmark(cycles, DecimalToHexadecimal);
            var averageExecutionTimePerCycleComplex =
                (decimal)(totalExecutionTimeComplex.TotalMilliseconds - emptyForCycleExecutionTime.TotalMilliseconds) / cycles;
            Console.WriteLine(
                $"(Complex)Total execution time for {cycles} cycles: {totalExecutionTimeComplex.TotalMilliseconds} ms.");
            Console.WriteLine(
                $"(Complex)Average execution time per cycle: {averageExecutionTimePerCycleComplex} ms.");
        }

        static TimeSpan ComplexBenchmark(int iterations, Func<int, string> action)
        {
            // Initialize a stopwatch that will measure the speed
            var stopwatch = new Stopwatch();

            // Set the current process to run with highest priority
            // In order to minimize possible fluctuations caused by other processes
            Process.GetCurrentProcess().PriorityClass = ProcessPriorityClass.High;
            Thread.CurrentThread.Priority = ThreadPriority.Highest;

            // Warm up the processor
            action.Invoke(int.MaxValue);

            // Cleanup unused memory
            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();

            // Begin measurements
            stopwatch.Start();
            for (int i = iterations; i >= 0; i--)
            {
                action.Invoke(i);
            }
            stopwatch.Stop();

            return stopwatch.Elapsed;
        }

        static TimeSpan NaiveBenchmark(int iterations, Func<int, string> action)
        {
            var stopwatch = new Stopwatch();

            stopwatch.Start();
            for (int i = iterations; i >= 0; i--)
            {
                action.Invoke(i);
            }
            stopwatch.Stop();

            return stopwatch.Elapsed;
        }

        static TimeSpan ProfileEmptyForCycle(int iterations)
        {
            // Initialize a stopwatch that will measure the speed
            var stopwatch = new Stopwatch();

            // Set the current process to run with highest priority
            // In order to minimize possible fluctuations caused by other processes
            Process.GetCurrentProcess().PriorityClass = ProcessPriorityClass.High;
            Thread.CurrentThread.Priority = ThreadPriority.Highest;

            // Cleanup unused memory
            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();

            // Begin measurements
            stopwatch.Start();
            for (int i = iterations; i >= 0; i--)
            {

            }
            stopwatch.Stop();

            return stopwatch.Elapsed;
        }

        public static string DecimalToHexadecimal(int number)
        {
            var hexadecimalSymbols = "0123456789ABCDEF";
            var hexadecimalIdentifier = "0x";
            var remainder = -1;
            var toBase = 16;

            var builder = new StringBuilder();

            while (number != 0)
            {
                remainder = number % toBase;
                number = number / toBase;
                builder.Insert(0, hexadecimalSymbols[remainder]);
            }

            builder.Insert(0, hexadecimalIdentifier);

            return builder.ToString();
        }

        public static string DecimalToHexadecimalDOTNET(int number)
        {
            return "0x" + Convert.ToString(number, 16);
        }
    }
}