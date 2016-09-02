using System;
using System.Linq;

using _03_Porcupines.Animals;
using _03_Porcupines.Engine;
using _03_Porcupines.Engine.Contracts;
using _03_Porcupines.Forests;

namespace _03_Porcupines
{
    public class AnimalPlanet
    {
        public static void Main()
        {
            var engine = CreateEngine();

            var isRunning = true;
            while (isRunning)
            {
                var nextCommand = Console.ReadLine();
                isRunning = engine.EvaluateNextCommand(nextCommand);
            }

            var commandsResult = engine.GetResult();
            Console.WriteLine(commandsResult);
        }

        private static IEngine CreateEngine()
        {
            var baseColsCount = int.Parse(Console.ReadLine());
            var numberOfRows = int.Parse(Console.ReadLine());

            var porcupineInputPosition = Console.ReadLine()
                .Trim()
                .Split(new[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var porcupineRow = porcupineInputPosition[0];
            var porcupineCol = porcupineInputPosition[1];

            var rabbitInputPosition = Console.ReadLine()
                 .Trim()
                 .Split(new[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
                 .Select(int.Parse)
                 .ToArray();

            var rabbitRow = rabbitInputPosition[0];
            var rabbitColumn = rabbitInputPosition[1];

            var rabbitPosition = new Position(rabbitRow, rabbitColumn);
            var rabbit = new Rabbit(rabbitPosition);

            var porcupinePosition = new Position(porcupineRow, porcupineCol);
            var porcupine = new Porcupine(porcupinePosition);

            var cellFactory = new ForestCellFactory(typeof(ForestCell));
            var forest = new JaggedForest(numberOfRows, baseColsCount, cellFactory);

            AnimalMovement.PositionGenerator = Position.CreatePosition;
            var engine = new AnimalPlanetEngine(rabbit, porcupine, forest, AnimalMovement.CreateMovement);

            return engine;
        }
    }
}
