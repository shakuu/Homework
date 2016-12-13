using System;
using System.Collections.Generic;
using System.Linq;

using Wintellect.PowerCollections;

namespace Diameter
{
    public class Program
    {
        private static OrderedDictionary<int, int>[] nodes;
        private static double longestRoute;

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

            //        set all nodes DIST = INFINITY;
            //        set current node the source and distance = 0;
            //        Q->all nodes from graph, ordered by distance;
            //        while (Q is not empty)
            //          a = dequeue the smallest element(first in PriorityQueue);
            //          if (distance of a == INFINITY) break

            //          foreach neighbour v of a
            //              potDistance = distance of a +distance of(a - v)
            //              if (potDistance < distance of v)
            //                  distance of v = potDistance;
            //                  reorder Q;

            for (var nodeIndex = 0; nodeIndex < nodesCount; nodeIndex++)
            {
                var node = nodes[nodeIndex];

                var distances = new Dictionary<OrderedDictionary<int, int>, double>();
                distances[node] = 0;

                var visited = new Dictionary<OrderedDictionary<int, int>, bool>();
                visited[node] = true;

                var queue = new Queue<OrderedDictionary<int, int>>();
                queue.Enqueue(node);

                while (queue.Count > 0)
                {
                    var currentNode = queue.Dequeue();

                    if (double.IsNegativeInfinity(distances[currentNode]))
                    {
                        break;
                    }

                    foreach (var connection in currentNode)
                    {
                        if (!visited.ContainsKey(nodes[connection.Value]))
                        {
                            visited[nodes[connection.Value]] = false;
                        }

                        if (visited[nodes[connection.Value]])
                        {
                            continue;
                        }

                        var potentialDistance = distances[currentNode] + connection.Key;
                        if (!distances.ContainsKey(nodes[connection.Value]))
                        {
                            distances[nodes[connection.Value]] = 0;
                        }

                        if (potentialDistance > distances[nodes[connection.Value]])
                        {
                            distances[nodes[connection.Value]] = potentialDistance;
                        }

                        queue.Enqueue(nodes[connection.Value]);

                        visited[nodes[connection.Value]] = true;
                    }
                }

                var maxDistance = distances.Max(d => d.Value);
                if (longestRoute < maxDistance)
                {
                    longestRoute = maxDistance;
                }
            }

            Console.WriteLine(longestRoute);
        }
    }
}
