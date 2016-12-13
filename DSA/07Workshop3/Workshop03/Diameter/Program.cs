using System;
using System.Collections.Generic;
using System.Linq;

namespace Diameter
{
    public class Program
    {
        private static SortedDictionary<int, int>[] nodes;
        private static double intestRoute;

        public static void Main()
        {
            var nodesCount = int.Parse(Console.ReadLine());

            nodes = new SortedDictionary<int, int>[nodesCount];
            for (var i = 0; i < nodesCount; i++)
            {
                nodes[i] = new SortedDictionary<int, int>();
            }

            for (var i = 0; i < nodesCount - 1; i++)
            {
                var nextConnection = Console.ReadLine()
                    .Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                if (nodes[nextConnection[0]].ContainsKey(nextConnection[2]) == false)
                {
                    nodes[nextConnection[0]].Add(nextConnection[2], nextConnection[1]);
                }

                if (nodes[nextConnection[1]].ContainsKey(nextConnection[2]) == false)
                {
                    nodes[nextConnection[1]].Add(nextConnection[2], nextConnection[0]);
                }
            }

            var indexList = new List<int>();
            for (var i = 0; i < nodesCount; i++)
            {
                if (nodes[i].Count == 1)
                {
                    indexList.Add(i);
                }
            }

            foreach (var nodeIndex in indexList)
            {
                var node = nodes[nodeIndex];

                var distances = new Dictionary<SortedDictionary<int, int>, double>();
                var visited = new Dictionary<SortedDictionary<int, int>, bool>();
                foreach (var nodeToAdd in nodes)
                {
                    distances[nodeToAdd] = 0;
                    visited[nodeToAdd] = false;
                }

                distances[node] = 0;
                visited[node] = true;

                var queue = new Queue<SortedDictionary<int, int>>();
                queue.Enqueue(node);

                while (queue.Count != 0)
                {
                    var currentNode = queue.Dequeue();

                    if (double.IsNegativeInfinity(distances[currentNode]))
                    {
                        break;
                    }

                    foreach (var connection in currentNode)
                    {
                        var connectingNode = nodes[connection.Value];
                        if (visited[connectingNode])
                        {
                            continue;
                        }

                        var potentialDistance = distances[currentNode] + connection.Key;
                        if (potentialDistance > distances[connectingNode])
                        {
                            distances[nodes[connection.Value]] = potentialDistance;
                        }

                        queue.Enqueue(connectingNode);

                        visited[connectingNode] = true;
                    }
                }

                var maxDistance = distances.Max(d => d.Value);
                if (intestRoute < maxDistance)
                {
                    intestRoute = maxDistance;
                }
            }

            Console.WriteLine(intestRoute);
        }
    }
}
