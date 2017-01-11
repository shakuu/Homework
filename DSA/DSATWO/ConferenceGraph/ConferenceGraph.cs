using System;
using System.Collections.Generic;
using System.Linq;

namespace ConferenceGraph
{
    public class ConferenceGraph
    {
        public static void Main()
        {
            var inputNM = Console.ReadLine().Split(' ').ToArray();
            var devsCount = int.Parse(inputNM[0]);

            // Memory limit 92/ 100.
            var devs = Enumerable.Range(0, devsCount).Select(x => new HashSet<int>()).ToArray();
            var linksCount = int.Parse(inputNM[1]);
            for (int i = 0; i < linksCount; i++)
            {
                var nextLink = Console.ReadLine().Split(' ').ToArray();
                var devA = int.Parse(nextLink[0]);
                var devB = int.Parse(nextLink[1]);

                devs[devA].Add(devB);
                devs[devB].Add(devA);
            }

            var companies = new List<int>();
            var visited = new bool[devsCount];
            for (int i = 0; i < visited.Length; i++)
            {
                if (visited[i])
                {
                    continue;
                }

                var nextCompany = 0;
                var bfsQueue = new Queue<int>();

                bfsQueue.Enqueue(i);
                while (bfsQueue.Count > 0)
                {
                    var nextDevIndex = bfsQueue.Dequeue();
                    if (visited[nextDevIndex])
                    {
                        continue;
                    }

                    var nextDev = devs[nextDevIndex];
                    visited[nextDevIndex] = true;
                    nextCompany++;

                    foreach (var devIndex in nextDev)
                    {
                        bfsQueue.Enqueue(devIndex);
                    }
                }

                companies.Add(nextCompany);
            }

            //var result = 0;
            //for (int firstIndex = 0; firstIndex < companies.Count; firstIndex++)
            //{
            //    for (int secondIndex = firstIndex + 1; secondIndex < companies.Count; secondIndex++)
            //    {
            //        var nextValue = companies[firstIndex] * companies[secondIndex];
            //        result += nextValue;
            //    }
            //}

            var result = 0;
            var multiplier = devsCount;
            for (int nextCompanyIndex = 0; nextCompanyIndex < companies.Count - 1; nextCompanyIndex++)
            {
                multiplier -= companies[nextCompanyIndex];
                result += companies[nextCompanyIndex] * multiplier;
            }

            Console.WriteLine(result);
        }
    }
}
