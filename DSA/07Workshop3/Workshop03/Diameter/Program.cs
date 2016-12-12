using System;
using System.Linq;

using Wintellect.PowerCollections;

namespace Diameter
{
    public class Program
    {
        private static int[,] table;
        private static bool[,] visited;
        private static new OrderedDictionary<int, int>[] nodes;

        private static long currentRoute;
        private static long longestRoute;

        public static void Main()
        {
            var nodesCount = int.Parse(Console.ReadLine());

            nodes = new OrderedDictionary<int, int>[nodesCount];
            for (var i = 0; i < nodesCount - 1; i++)
            {
                var nextConnection = Console.ReadLine()
                    .Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                if (nodes[nextConnection[0]] == null)
                {
                    nodes[nextConnection[0]] = new OrderedDictionary<int, int>();
                }

                if (nodes[nextConnection[1]] == null)
                {
                    nodes[nextConnection[1]] = new OrderedDictionary<int, int>();
                }

                nodes[nextConnection[0]].Add(nextConnection[2], nextConnection[1]);
                nodes[nextConnection[1]].Add(nextConnection[2], nextConnection[0]);
            }
        }
    }
}
