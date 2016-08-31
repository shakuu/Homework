using System;

using _02_Kitty.Engine;
using _02_Kitty.Results;

namespace _02_Kitty
{
    public class Kitty
    {
        static void Main()
        {
            var path = Console.ReadLine();
            var jumps = Console.ReadLine();

            var pathCells = KittyPathCell.GenerateSequenceOfPathCells(path);
            var sequenceGenerator = new JumpSequenceGenerator();
            var kittyPath = new KittyPath(pathCells, sequenceGenerator);

            var resultTracker = new ResultTracker();
            var result = kittyPath.EvaluteSequenceOfJumps(jumps, resultTracker);

            Console.WriteLine(result.GetResultLog());
        }
    }
}
