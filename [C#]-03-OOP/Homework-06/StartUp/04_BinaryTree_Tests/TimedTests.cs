namespace StartUp._04_BinaryTree_Tests
{
    using OrderedBinarySearchTreeAssembly.Models;
    using System;
    using System.Diagnostics;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// https://github.com/TelerikAcademy/CSharp-Part-2/blob/master/Topics/04.%20Numeral-Systems/demos/Live-Demos-May%2010th%2C%202016%2C%20Kolev/Benchmarking/MethodExecutionProfiler/Startup.cs
    /// https://telerikacademy.com/Forum/Questions/193544/CSharp-Testing-methods-performance-Live-demos-May-10th-2016
    /// INKolev - Live Demo Benchmarking
    /// </summary>
    public static class TimedTests
    {
        #region Settings
        public const int NumberOfElemets = 30000;
        public const int NumberOfRuns = 10000;
        public const int NumberOfRunsTofill = 100; // Can take A LOOOOOONG time.
        public const int MinValue = 0;
        public const int MaxValue = 9999999;
        #endregion

        #region Static Ctor
        static Random random;

        static TimedTests()
        {
            random = new Random();
        }
        #endregion

        public static void TimeToGenerate()
        {
            PrintHeader(" Time to fill: List<int> Vs BinarySearchTree<int>");

            // Generate input
            List<int> list;
            BinarySearchTree<int> tree;
            GenerateListAndTree(out list, out tree);

            var timeList = FillList(list);
            var timeTree = FillTree(list);

            Console.WriteLine("Fill List<int>        -> Total time: {0, 12:F4}ms, Average Time: {1, 16:F10}ms",
                timeList.TotalMilliseconds, timeList.TotalMilliseconds / NumberOfRunsTofill);

            Console.WriteLine("Fill Tree<int>        -> Total time: {0, 12:F4}ms, Average Time: {1, 16:F10}ms",
                timeTree.TotalMilliseconds, timeTree.TotalMilliseconds / NumberOfRunsTofill);

            Console.WriteLine();
        }

        public static void TimeSearchListVTree()
        {
            PrintHeader(" List<int>.Contains Vs BinarySearchTree<int>.Contains Vs Linq");

            // Generate input
            List<int> list;
            BinarySearchTree<int> tree;
            GenerateListAndTree(out list, out tree);

            var find = random.Next(MinValue, MaxValue);

            var timeList = NaiveBenchmarkList(list, NumberOfRuns, find);
            var timeTree = NaiveBenchmarkTree(tree, NumberOfRuns, find);
            var timeLinq = NaiveBenchmarkLinq(list, NumberOfRuns, find);

            Console.WriteLine("List<int>.Contains()  -> Total time: {0, 12:F4}ms, Average Time: {1, 16:F10}ms",
                timeList.TotalMilliseconds, timeList.TotalMilliseconds / NumberOfRuns);

            Console.WriteLine("Tree<int>.Contains()  -> Total time: {0, 12:F4}ms, Average Time: {1, 16:F10}ms",
                timeTree.TotalMilliseconds, timeTree.TotalMilliseconds / NumberOfRuns);

            Console.WriteLine("Linq expression where -> Total time: {0, 12:F4}ms, Average Time: {1, 16:F10}ms",
                timeLinq.TotalMilliseconds, timeLinq.TotalMilliseconds / NumberOfRuns);

            Console.WriteLine();
        }

        #region Generate Benchmarks
        private static TimeSpan FillTree(List<int> numbers)
        {
            var stopwatch = new Stopwatch();

            stopwatch.Start();
            for (int i = 0; i < NumberOfRunsTofill; i++)
            {
                var tree = new BinarySearchTree<int>();
                for (int j = 0; j < NumberOfElemets; j++)
                {
                    tree.Add(numbers[j]);
                }
            }
            stopwatch.Stop();

            return stopwatch.Elapsed;
        }

        private static TimeSpan FillList(List<int> numbers)
        {
            var stopwatch = new Stopwatch();

            stopwatch.Start();
            for (int i = 0; i < NumberOfRunsTofill; i++)
            {
                var list = new List<int>();
                for (int j = 0; j < NumberOfElemets; j++)
                {
                    list.Add(numbers[j]);
                }
            }
            stopwatch.Stop();

            return stopwatch.Elapsed;
        }
        #endregion

        #region Searching Benchmarks
        private static TimeSpan NaiveBenchmarkLinq
            (List<int> list, int runs, int find)
        {
            var stopwatch = new Stopwatch();

            stopwatch.Start();
            for (int i = 0; i < runs; i++)
            {
                var test =
                    (from ints in list
                     where ints == find
                     select ints);
            }
            stopwatch.Stop();

            return stopwatch.Elapsed;
        }

        private static TimeSpan NaiveBenchmarkTree
            (BinarySearchTree<int> tree, int runs, int find)
        {
            var stopwatch = new Stopwatch();

            stopwatch.Start();
            for (int i = 0; i < runs; i++)
            {
                tree.Contains(find);
            }
            stopwatch.Stop();

            return stopwatch.Elapsed;
        }

        private static TimeSpan NaiveBenchmarkList
            (List<int> list, int runs, int find)
        {
            var stopwatch = new Stopwatch();

            stopwatch.Start();
            for (int i = 0; i < runs; i++)
            {
                list.Contains(find);
            }
            stopwatch.Stop();

            return stopwatch.Elapsed;
        }
        #endregion

        private static void PrintHeader(string header)
        {
            Console.WriteLine(new string('-', 85));
            Console.WriteLine(header);
            Console.WriteLine(new string('-', 85));
        }

        private static void GenerateListAndTree
            (out List<int> list, out BinarySearchTree<int> tree)
        {
            list = new List<int>();
            tree = new BinarySearchTree<int>();

            for (int el = 0; el < NumberOfElemets; el++)
            {
                var add = random.Next(MinValue, MaxValue);

                while (tree.Contains(add))
                {
                    add = random.Next(MinValue, MaxValue);
                }

                list.Add(add);
                tree.Add(add);
            }
        }
    }
}
