using System;
using System.Collections.Generic;
using System.Linq;

namespace Diameter
{
    // Longest distance after run 1 is the starting point for the longest distance overall.
    public class Program
    {
        private static Dictionary<int, int>[] nodes;

        public static void Main()
        {
            var nodesCount = int.Parse(Console.ReadLine());

            nodes = new Dictionary<int, int>[nodesCount];
            for (var i = 0; i < nodesCount; i++)
            {
                nodes[i] = new Dictionary<int, int>();
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

            var nodeIndex = indexList[0];
            var node = nodes[nodeIndex];

            var distances = new int[nodesCount];
            var visited = new bool[nodesCount];
            var currentMaxDistance = 0;

            distances[nodeIndex] = 0;
            visited[nodeIndex] = true;

            var queue = new Queue<Dictionary<int, int>>();
            queue.Enqueue(node);

            var indexesQueue = new Queue<int>();
            indexesQueue.Enqueue(nodeIndex);

            while (queue.Count != 0)
            {
                var currentNode = queue.Dequeue();
                var currentIndex = indexesQueue.Dequeue();

                if (double.IsNegativeInfinity(distances[currentIndex]))
                {
                    break;
                }

                foreach (var connection in currentNode)
                {
                    var nextIndex = connection.Value;

                    var connectingNode = nodes[connection.Value];
                    if (visited[nextIndex])
                    {
                        continue;
                    }

                    var potentialDistance = distances[currentIndex] + connection.Key;
                    if (potentialDistance > distances[nextIndex])
                    {
                        distances[nextIndex] = potentialDistance;
                    }

                    queue.Enqueue(connectingNode);
                    indexesQueue.Enqueue(nextIndex);

                    visited[currentIndex] = true;
                }
            }

            var maxDistance = 0;
            var maxDistanceIndex = -1;
            for (int i = 0; i < distances.Length; i++)
            {
                if (maxDistance < distances[i])
                {
                    maxDistance = distances[i];
                    maxDistanceIndex = i;
                }
            }

            nodeIndex = maxDistanceIndex;
            node = nodes[nodeIndex];

            distances = new int[nodesCount];
            visited = new bool[nodesCount];
            currentMaxDistance = 0;

            distances[nodeIndex] = 0;
            visited[nodeIndex] = true;

            queue = new Queue<Dictionary<int, int>>();
            queue.Enqueue(node);

            indexesQueue = new Queue<int>();
            indexesQueue.Enqueue(nodeIndex);

            while (queue.Count != 0)
            {
                var currentNode = queue.Dequeue();
                var currentIndex = indexesQueue.Dequeue();

                if (double.IsNegativeInfinity(distances[currentIndex]))
                {
                    break;
                }

                foreach (var connection in currentNode)
                {
                    var nextIndex = connection.Value;

                    var connectingNode = nodes[connection.Value];
                    if (visited[nextIndex])
                    {
                        continue;
                    }

                    var potentialDistance = distances[currentIndex] + connection.Key;
                    if (potentialDistance > distances[nextIndex])
                    {
                        distances[nextIndex] = potentialDistance;
                    }

                    if (currentMaxDistance < potentialDistance)
                    {
                        currentMaxDistance = potentialDistance;
                    }

                    queue.Enqueue(connectingNode);
                    indexesQueue.Enqueue(nextIndex);

                    visited[currentIndex] = true;
                }
            }

            Console.WriteLine(currentMaxDistance);
        }
    }
}
