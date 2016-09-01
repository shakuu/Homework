using System;

using _02_Kitty.Engine;
using _02_Kitty.Engine.Contracts;
using _02_Kitty.Results;

namespace _02_Kitty
{
    public class Kitty
    {
        public static void Main()
        {
            var inputPath = Console.ReadLine();
            var inputJumpsLengths = Console.ReadLine();

            var kittyEngine = CreateKittyEngine();
            var report = kittyEngine.EvaluteSequenceOfJumps(inputPath, inputJumpsLengths);

            Console.WriteLine(report);
        }

        private static IEngine CreateKittyEngine()
        {
            var pathGenerator = new KittyPathGenerator(typeof(KittyPathCell));
            var sequenceGenerator = new JumpSequenceGenerator();
            var resultTracker = new ResultTracker();
            var kittyEngine = new KittyEngine(pathGenerator, resultTracker, sequenceGenerator);

            return kittyEngine;
        }
    }
}
