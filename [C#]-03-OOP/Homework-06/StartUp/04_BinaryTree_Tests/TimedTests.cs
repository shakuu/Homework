namespace StartUp._04_BinaryTree_Tests
{
    using OrderedBinarySearchTreeAssembly.Models;
    using System;
    using System.Diagnostics;
    using System.Collections.Generic;

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

        public static void TimedSearchListVTree()
        {
            // Generate input
            List<int> list;
            OrderedBinarySearchTree<int> tree;
            GenerateListAndTree(out list, out tree);


            var find = random.Next(MinValue, MaxValue);

            var timeList = NaiveBenchmarkList(list, NumberOfRuns, find);
            var timeTree = NaiveBenchmarkTree(tree, NumberOfRuns, find);

            Console.WriteLine("List<int>.Contains() -> Total time: {0, 12}ms, Average Time: {1, 12}ms",
                timeList.TotalMilliseconds, timeList.TotalMilliseconds / NumberOfRuns);

            Console.WriteLine("Tree<int>.Contains() -> Total time: {0, 12}ms, Average Time: {1, 12}ms",
                timeTree.TotalMilliseconds, timeTree.TotalMilliseconds / NumberOfRuns);
        }

        private static TimeSpan NaiveBenchmarkTree
            (OrderedBinarySearchTree<int> tree, int runs, int find)
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

        private static void GenerateListAndTree
            (out List<int> list, out OrderedBinarySearchTree<int> tree)
        {
            list = new List<int>();
            tree = new OrderedBinarySearchTree<int>();

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
