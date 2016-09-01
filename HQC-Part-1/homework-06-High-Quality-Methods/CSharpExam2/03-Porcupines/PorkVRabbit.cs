using System;
using System.Linq;

using _03_Porcupines.Animals;
using _03_Porcupines.Engine;
using _03_Porcupines.Engine.Contracts;
using _03_Porcupines.Forests;

namespace _03_Porcupines
{


    // 88 / 100

    class PorkVRabbit
    {
        //// Unit Direction Steps

        //// constatns
        //const string Rabbit = "R";
        //const string Porcupine = "P";
        //// directions 
        //const string Top = "T";
        //const string Left = "L";
        //const string Right = "R";
        //const string Bottom = "B";

        //const string End = "END";


        //private static BigInteger[][] forest;

        //// Variables.
        //private static int porcupineRow;
        //private static int porcupineCol;
        //private static BigInteger porcupineScore;
        //private static int rabbitRow;
        //private static int rabbitColumn;
        //private static BigInteger rabbitScore;

        //private static string[] curInsruction;

        //private static int numberOfRows;
        //private static int baseColsCount;

        //// Not needed
        //// static List<BigInteger> rowWidth = new List<BigInteger>();

        //static void Input()
        //{
        //    baseColsCount = int.Parse(Console.ReadLine());
        //    numberOfRows = int.Parse(Console.ReadLine());

        //    BuildTheForest(numberOfRows, baseColsCount);

        //    var position = Console.ReadLine()
        //        .Trim()
        //        .Split(new[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
        //        .Select(int.Parse)
        //        .ToArray();

        //    porcupineRow = position[0];
        //    porcupineCol = position[1];

        //    position = Console.ReadLine()
        //        .Trim()
        //        .Split(new[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
        //        .Select(int.Parse)
        //        .ToArray();

        //    rabbitRow = position[0];
        //    rabbitColumn = position[1];
        //}
        //// Working
        //static void BuildTheForest(int rows, int cols)
        //{
        //    var colsMultiplier = 1;

        //    forest = new BigInteger[rows][];

        //    // Build The forest
        //    for (int row = 0; row < rows / 2; row++)
        //    {
        //        var colsToAdd = colsMultiplier * cols;

        //        forest[row] = new BigInteger[colsToAdd];
        //        forest[rows - 1 - row] = new BigInteger[colsToAdd];

        //        colsMultiplier++;
        //    }

        //    // Fil lthe forest

        //    for (int row = 0; row < rows; row++)
        //    {
        //        var fill = row + 1;
        //        var step = fill;

        //        for (int col = 0; col < forest[row].Length; col++)
        //        {
        //            forest[row][col] = fill;

        //            fill += step;
        //        }
        //    }
        //}

        //static void Play()
        //{
        //    rabbitScore = forest[rabbitRow][rabbitColumn];
        //    porcupineScore = forest[porcupineRow][porcupineCol];

        //    forest[rabbitRow][rabbitColumn] = 0;
        //    forest[porcupineRow][porcupineCol] = 0;

        //    while (true)
        //    {
        //        var input = Console.ReadLine();
        //        // Stop on END 
        //        if (input == End) break;

        //        // Unit Direction Steps
        //        curInsruction = input
        //            .Trim()
        //            .Split(new[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
        //            .ToArray();

        //        if (curInsruction[0] == Rabbit)
        //        {
        //            MoveRabbit();
        //        }
        //        else if (curInsruction[0] == Porcupine)
        //        {
        //            MovePorcupine();
        //        }
        //    }
        //}

        //static void MovePorcupine()
        //{
        //    var steps = int.Parse(curInsruction[2]);
        //    // 1 move at a time
        //    curInsruction[2] = "1";

        //    for (int step = 0; step < steps; step++)
        //    {
        //        GetNextPosition2();
        //        StayInForest2();

        //        if (rabbitRow == porcupineRow && rabbitColumn == porcupineCol)
        //        {
        //            curInsruction[2] = "-1";
        //            GetNextPosition2();
        //            StayInForest2();
        //            break;
        //        }

        //        porcupineScore += forest[porcupineRow][porcupineCol];
        //        forest[porcupineRow][porcupineCol] = 0;
        //    }
        //}
        //static void StayInForest2()
        //{
        //    // Check within Array
        //    // Check row
        //    if (curInsruction[1] == Top || curInsruction[1] == Bottom)
        //    {
        //        var colHeight =
        //        numberOfRows - (((porcupineCol) / baseColsCount) * 2);

        //        var fisrtRowInCurCol = (numberOfRows - colHeight) / 2;

        //        // Indexes of currently existing rows on this col
        //        var curColIndexes = Enumerable
        //            .Range(fisrtRowInCurCol, colHeight)
        //            .ToArray();

        //        if (porcupineRow < curColIndexes[0])
        //        {
        //            while (porcupineRow < curColIndexes[0])
        //            {
        //                porcupineRow = curColIndexes.Length + porcupineRow;
        //            }
        //        }
        //        else if (porcupineRow > curColIndexes[curColIndexes.Length - 1])
        //        {
        //            while (porcupineRow > curColIndexes[curColIndexes.Length - 1])
        //            {
        //                porcupineRow = porcupineRow - curColIndexes.Length;
        //            }
        //        }
        //    }
        //    else
        //    {
        //        if (porcupineCol >= forest[porcupineRow].Length)
        //        {
        //            while (porcupineCol >= forest[porcupineRow].Length)
        //            {
        //                porcupineCol = porcupineCol - forest[porcupineRow].Length;
        //            }

        //        }
        //        else if (porcupineCol < 0)
        //        {
        //            while (porcupineCol < 0)
        //            {
        //                porcupineCol = forest[porcupineRow].Length + porcupineCol;
        //            }
        //        }
        //    }
        //}
        //static void GetNextPosition2()
        //{
        //    var steps = int.Parse(curInsruction[2]);
        //    // Get direction and steps 
        //    if (curInsruction[1] == Left)
        //    {
        //        porcupineCol -= steps;
        //    }
        //    else if (curInsruction[1] == Right)
        //    {
        //        porcupineCol += steps;
        //    }
        //    else if (curInsruction[1] == Top)
        //    {
        //        porcupineRow -= steps;
        //    }
        //    else if (curInsruction[1] == Bottom)
        //    {
        //        porcupineRow += steps;
        //    }
        //}

        //static void MoveRabbit()
        //{
        //    // Get next position
        //    GetNextPosition();
        //    StayInForest();

        //    // Check for porcupine
        //    if (rabbitRow == porcupineRow && rabbitColumn == porcupineCol)
        //    {
        //        curInsruction[2] = "-1";
        //        GetNextPosition();
        //        StayInForest();
        //    }

        //    // Increment Score
        //    rabbitScore += forest[rabbitRow][rabbitColumn];
        //    forest[rabbitRow][rabbitColumn] = 0;
        //}
        //static void StayInForest()
        //{
        //    // Check within Array
        //    // Check row
        //    if (curInsruction[1] == Top || curInsruction[1] == Bottom)
        //    {
        //        var colHeight =
        //        numberOfRows - (((rabbitColumn) / baseColsCount) * 2);

        //        var fisrtRowInCurCol = (numberOfRows - colHeight) / 2;

        //        // Indexes of currently existing rows on this col
        //        var curColIndexes = Enumerable
        //            .Range(fisrtRowInCurCol, colHeight)
        //            .ToArray();

        //        if (rabbitRow < curColIndexes[0])
        //        {
        //            while (rabbitRow < curColIndexes[0])
        //            {
        //                rabbitRow = curColIndexes.Length + rabbitRow;
        //            }
        //        }
        //        else if (rabbitRow > curColIndexes[curColIndexes.Length - 1])
        //        {
        //            while (rabbitRow > curColIndexes[curColIndexes.Length - 1])
        //            {
        //                rabbitRow = rabbitRow - curColIndexes.Length;
        //            }
        //        }
        //    }
        //    else
        //    {
        //        if (rabbitColumn >= forest[rabbitRow].Length)
        //        {
        //            while (rabbitColumn >= forest[rabbitRow].Length)
        //            {
        //                rabbitColumn = rabbitColumn - forest[rabbitRow].Length;
        //            }

        //        }
        //        else if (rabbitColumn < 0)
        //        {
        //            while (rabbitColumn < 0)
        //            {
        //                rabbitColumn = forest[rabbitRow].Length + rabbitColumn;
        //            }
        //        }
        //    }
        //}
        //static void GetNextPosition()
        //{
        //    var steps = int.Parse(curInsruction[2]);
        //    // Get direction and steps 
        //    if (curInsruction[1] == Left)
        //    {
        //        rabbitColumn -= steps;
        //    }
        //    else if (curInsruction[1] == Right)
        //    {
        //        rabbitColumn += steps;
        //    }
        //    else if (curInsruction[1] == Top)
        //    {
        //        rabbitRow -= steps;
        //    }
        //    else if (curInsruction[1] == Bottom)
        //    {
        //        rabbitRow += steps;
        //    }
        //}

        //static void Output()
        //{
        //    if (rabbitScore > porcupineScore)
        //    {
        //        Console.WriteLine("The rabbit WON with {0} points. The porcupine scored {1} points only.",
        //            rabbitScore, porcupineScore);
        //    }
        //    else if (porcupineScore > rabbitScore)
        //    {
        //        Console.WriteLine("The porcupine destroyed the rabbit with {0} points. The rabbit must work harder. He scored {1} points only.",
        //            porcupineScore, rabbitScore);
        //    }
        //    else
        //    {
        //        Console.WriteLine("Both units scored {0} points. Maybe we should play again?", rabbitScore);
        //    }
        //}

        static void Main()
        {
            var engine = CreateEngine();
            var isRunning = true;
            while (isRunning)
            {
                var nextCommand = Console.ReadLine();
                isRunning = engine.EvaluateNextCommand(nextCommand);
            }


            //engine.EvaluateNextCommand("P T 3");
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
