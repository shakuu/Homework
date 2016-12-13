﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace Diameter
{
    public class Program
    {
        private static SortedDictionary<int, int>[] nodes;
        private static double longestRoute;

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

                var distances = new int[nodesCount];
                var visited = new bool[nodesCount];

                distances[nodeIndex] = 0;
                visited[nodeIndex] = true;

                var queue = new Queue<SortedDictionary<int, int>>();
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

                var maxDistance = distances.Max();
                if (longestRoute < maxDistance)
                {
                    longestRoute = maxDistance;
                }
            }

            Console.WriteLine(longestRoute);
        }
    }
}
