using System;

using _02_Kitty.Engine;
using _02_Kitty.Results;

namespace _02_Kitty
{
    public class Kitty
    {
        static void Main()
        {
            var inputPath = Console.ReadLine();
            var inputJumpsLengths = Console.ReadLine();

            var sequenceGenerator = new JumpSequenceGenerator();
            var pathCells = KittyPathCell.GenerateSequenceOfPathCells(inputPath);
            var kittyPath = new KittyPath(pathCells, sequenceGenerator);

            var resultTracker = new ResultTracker();
            var result = kittyPath.EvaluteSequenceOfJumps(inputJumpsLengths, resultTracker);

            Console.WriteLine(result);
        }
    }
}
