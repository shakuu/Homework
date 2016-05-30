
namespace _02_Greedy_Dwarf
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Numerics;

    class GreedyDwarf
    {
        static List<int> valley;
        static List<List<int>> patterns =
            new List<List<int>>();

        static BigInteger? maxGoldCollected = null;

        static void Input()
        {
            valley = Console.ReadLine()
                .Trim()
                .Split(
                    new[] { ' ', ',' },
                    StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            var numberOfPatters =
                int.Parse(Console.ReadLine());

            for (int index = 0; index < numberOfPatters; index++)
            {
                patterns.Add(
                    Console.ReadLine()
                    .Trim()
                    .Split(
                        new[] { ' ', ',' },
                        StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToList());
            }
        }

        static void GreedieDwarf()
        {
            foreach (var pattern in patterns)
            {
                // Helpers.
                var dwarf = 0;
                var gold = (BigInteger)0;
                var nextPatternStep = 0;
                var moves = 0;
                var flags = new bool[valley.Count];

                while (true)
                {
                    // If not visitied, collect the gold 
                    // or stop.
                    if (!flags[dwarf])
                    {
                        gold += valley[dwarf];
                        flags[dwarf] = true;
                    }
                    else break;

                    // Next index from pattern.
                    nextPatternStep = moves % pattern.Count;
                    moves++;

                    // Next Dwarf position.
                    dwarf += pattern[nextPatternStep];

                    // If outside of the valley break.
                    if (dwarf < 0 || valley.Count <= dwarf) break;
                }

                maxGoldCollected = maxGoldCollected == null ?
                                   gold : gold > maxGoldCollected ?
                                          gold : maxGoldCollected;
            }
        }

        static void Main()
        {
            Input();
            GreedieDwarf();
            Console.WriteLine(maxGoldCollected);
        }
    }
}
