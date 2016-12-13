using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wintellect.PowerCollections;

namespace Diamater2
{
    public class Diameter2
    {
        private static OrderedDictionary<int, int>[] nodes;

        private static long currentSum;
        private static long currentMaxSum;
        private static Dictionary<OrderedDictionary<int, int>, bool> visited;

        public static void Main()
        {
            var nodesCount = int.Parse(Console.ReadLine());

            nodes = new OrderedDictionary<int, int>[nodesCount];
            for (var i = 0; i < nodesCount; i++)
            {
                nodes[i] = new OrderedDictionary<int, int>();
            }

            for (var i = 0; i < nodesCount - 1; i++)
            {
                var nextConnection = Console.ReadLine()
                    .Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                nodes[nextConnection[0]].Add(nextConnection[2], nextConnection[1]);
                nodes[nextConnection[1]].Add(nextConnection[2], nextConnection[0]);
            }

            visited = new Dictionary<OrderedDictionary<int, int>, bool>();

            var sums = new OrderedBag<long>();
            foreach (var connection in nodes[0])
            {
                currentSum = connection.Key;
                var node = nodes[connection.Value];

                if (!visited.ContainsKey(nodes[connection.Value]))
                {
                    visited[nodes[connection.Value]] = false;
                }

                if (visited[node])
                {
                    continue;
                }

                visited = new Dictionary<OrderedDictionary<int, int>, bool>();
                DFS(node);

                sums.Add(currentMaxSum);
                currentMaxSum = 0;
            }

            if (sums.Count > 1)
            {
                Console.WriteLine(sums[sums.Count - 1] + sums[sums.Count - 2]);
            }
            else
            {
                Console.WriteLine(sums[0]);
            }
        }

        private static void DFS(OrderedDictionary<int, int> node)
        {
            visited[node] = true;

            if (currentMaxSum < currentSum)
            {
                currentMaxSum = currentSum;
            }

            foreach (var connection in node)
            {
                var nextNode = nodes[connection.Value];

                if (!visited.ContainsKey(nodes[connection.Value]))
                {
                    visited[nodes[connection.Value]] = false;
                }

                if (visited[nodes[connection.Value]])
                {
                    continue;
                }

                currentSum += connection.Key;
                DFS(nextNode);
                currentSum -= connection.Key;
            }
        }
    }
}
