
namespace _03_Porcupines
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Numerics;
    using Animals;
    using Engine;
    using Forests;

    // 88 / 100

    class PorkVRabbit
    {
        // Unit Direction Steps

        // constatns
        const string Rabbit = "R";
        const string Porcupine = "P";
        // directions 
        const string Top = "T";
        const string Left = "L";
        const string Right = "R";
        const string Bottom = "B";

        const string End = "END";


        private static BigInteger[][] forest;

        // Variables.
        private static int porcupineRow;
        private static int porcupineCol;
        private static BigInteger porcupineScore;
        private static int rabbitRow;
        private static int rabbitCol;
        private static BigInteger rabbitScore;

        private static string[] curInsruction;

        private static int numberOfRows;
        private static int baseColsCount;

        // Not needed
        // static List<BigInteger> rowWidth = new List<BigInteger>();

        static void Input()
        {
            baseColsCount = int.Parse(Console.ReadLine());
            numberOfRows = int.Parse(Console.ReadLine());

            BuildTheForest(numberOfRows, baseColsCount);

            var position = Console.ReadLine()
                .Trim()
                .Split(new[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            porcupineRow = position[0];
            porcupineCol = position[1];

            position = Console.ReadLine()
                .Trim()
                .Split(new[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            rabbitRow = position[0];
            rabbitCol = position[1];
        }
        // Working
        static void BuildTheForest(int rows, int cols)
        {
            var colsMultiplier = 1;

            forest = new BigInteger[rows][];

            // Build The forest
            for (int row = 0; row < rows / 2; row++)
            {
                var colsToAdd = colsMultiplier * cols;

                forest[row] = new BigInteger[colsToAdd];
                forest[rows - 1 - row] = new BigInteger[colsToAdd];

                colsMultiplier++;
            }

            // Fil lthe forest

            for (int row = 0; row < rows; row++)
            {
                var fill = row + 1;
                var step = fill;

                for (int col = 0; col < forest[row].Length; col++)
                {
                    forest[row][col] = fill;

                    fill += step;
                }
            }
        }

        static void Play()
        {
            rabbitScore = forest[rabbitRow][rabbitCol];
            porcupineScore = forest[porcupineRow][porcupineCol];

            forest[rabbitRow][rabbitCol] = 0;
            forest[porcupineRow][porcupineCol] = 0;

            while (true)
            {
                var input = Console.ReadLine();
                // Stop on END 
                if (input == End) break;

                // Unit Direction Steps
                curInsruction = input
                    .Trim()
                    .Split(new[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                if (curInsruction[0] == Rabbit)
                {
                    MoveRabbit();
                }
                else if (curInsruction[0] == Porcupine)
                {
                    MovePorcupine();
                }
            }
        }

        static void MovePorcupine()
        {
            var steps = int.Parse(curInsruction[2]);
            // 1 move at a time
            curInsruction[2] = "1";

            for (int step = 0; step < steps; step++)
            {
                GetNextPosition2();
                StayInForest2();

                if (rabbitRow == porcupineRow && rabbitCol == porcupineCol)
                {
                    curInsruction[2] = "-1";
                    GetNextPosition2();
                    StayInForest2();
                    break;
                }

                porcupineScore += forest[porcupineRow][porcupineCol];
                forest[porcupineRow][porcupineCol] = 0;
            }
        }
        static void StayInForest2()
        {
            // Check within Array
            // Check row
            if (curInsruction[1] == Top || curInsruction[1] == Bottom)
            {
                var colHeight =
                numberOfRows - (((porcupineCol) / baseColsCount) * 2);

                var fisrtRowInCurCol = (numberOfRows - colHeight) / 2;

                // Indexes of currently existing rows on this col
                var curColIndexes = Enumerable
                    .Range(fisrtRowInCurCol, colHeight)
                    .ToArray();

                if (porcupineRow < curColIndexes[0])
                {
                    while (porcupineRow < curColIndexes[0])
                    {
                        porcupineRow = curColIndexes.Length + porcupineRow;
                    }
                }
                else if (porcupineRow > curColIndexes[curColIndexes.Length - 1])
                {
                    while (porcupineRow > curColIndexes[curColIndexes.Length - 1])
                    {
                        porcupineRow = porcupineRow - curColIndexes.Length;
                    }
                }
            }
            else
            {
                if (porcupineCol >= forest[porcupineRow].Length)
                {
                    while (porcupineCol >= forest[porcupineRow].Length)
                    {
                        porcupineCol = porcupineCol - forest[porcupineRow].Length;
                    }

                }
                else if (porcupineCol < 0)
                {
                    while (porcupineCol < 0)
                    {
                        porcupineCol = forest[porcupineRow].Length + porcupineCol;
                    }
                }
            }
        }
        static void GetNextPosition2()
        {
            var steps = int.Parse(curInsruction[2]);
            // Get direction and steps 
            if (curInsruction[1] == Left)
            {
                porcupineCol -= steps;
            }
            else if (curInsruction[1] == Right)
            {
                porcupineCol += steps;
            }
            else if (curInsruction[1] == Top)
            {
                porcupineRow -= steps;
            }
            else if (curInsruction[1] == Bottom)
            {
                porcupineRow += steps;
            }
        }

        static void MoveRabbit()
        {
            // Get next position
            GetNextPosition();
            StayInForest();

            // Check for porcupine
            if (rabbitRow == porcupineRow && rabbitCol == porcupineCol)
            {
                curInsruction[2] = "-1";
                GetNextPosition();
                StayInForest();
            }

            // Increment Score
            rabbitScore += forest[rabbitRow][rabbitCol];
            forest[rabbitRow][rabbitCol] = 0;
        }
        static void StayInForest()
        {
            // Check within Array
            // Check row
            if (curInsruction[1] == Top || curInsruction[1] == Bottom)
            {
                var colHeight =
                numberOfRows - (((rabbitCol) / baseColsCount) * 2);

                var fisrtRowInCurCol = (numberOfRows - colHeight) / 2;

                // Indexes of currently existing rows on this col
                var curColIndexes = Enumerable
                    .Range(fisrtRowInCurCol, colHeight)
                    .ToArray();

                if (rabbitRow < curColIndexes[0])
                {
                    while (rabbitRow < curColIndexes[0])
                    {
                        rabbitRow = curColIndexes.Length + rabbitRow;
                    }
                }
                else if (rabbitRow > curColIndexes[curColIndexes.Length - 1])
                {
                    while (rabbitRow > curColIndexes[curColIndexes.Length - 1])
                    {
                        rabbitRow = rabbitRow - curColIndexes.Length;
                    }
                }
            }
            else
            {
                if (rabbitCol >= forest[rabbitRow].Length)
                {
                    while (rabbitCol >= forest[rabbitRow].Length)
                    {
                        rabbitCol = rabbitCol - forest[rabbitRow].Length;
                    }

                }
                else if (rabbitCol < 0)
                {
                    while (rabbitCol < 0)
                    {
                        rabbitCol = forest[rabbitRow].Length + rabbitCol;
                    }
                }
            }
        }
        static void GetNextPosition()
        {
            var steps = int.Parse(curInsruction[2]);
            // Get direction and steps 
            if (curInsruction[1] == Left)
            {
                rabbitCol -= steps;
            }
            else if (curInsruction[1] == Right)
            {
                rabbitCol += steps;
            }
            else if (curInsruction[1] == Top)
            {
                rabbitRow -= steps;
            }
            else if (curInsruction[1] == Bottom)
            {
                rabbitRow += steps;
            }
        }

        static void Output()
        {
            if (rabbitScore > porcupineScore)
            {
                Console.WriteLine("The rabbit WON with {0} points. The porcupine scored {1} points only.",
                    rabbitScore, porcupineScore);
            }
            else if (porcupineScore > rabbitScore)
            {
                Console.WriteLine("The porcupine destroyed the rabbit with {0} points. The rabbit must work harder. He scored {1} points only.",
                    porcupineScore, rabbitScore);
            }
            else
            {
                Console.WriteLine("Both units scored {0} points. Maybe we should play again?", rabbitScore);
            }
        }

        static void Main()
        {
            //Input();
            //Play();
            //Output();

            var baseColsCount = int.Parse(Console.ReadLine());
            var numberOfRows = int.Parse(Console.ReadLine());

            var position = Console.ReadLine()
                .Trim()
                .Split(new[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            porcupineRow = position[0];
            porcupineCol = position[1];

            position = Console.ReadLine()
                .Trim()
                .Split(new[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            rabbitRow = position[0];
            rabbitCol = position[1];

            var rabbitPosition = new Position(rabbitRow, rabbitCol);
            var rabbit = new Rabbit(rabbitPosition);

            var porcPosition = new Position(porcupineRow, porcupineCol);
            var porc = new Porcupine(porcPosition);

            var cellFactory = new ForestCellFactory(typeof(ForestCell));
            var forest = new JaggedForest(numberOfRows, baseColsCount, cellFactory);

            AnimalMovement.PositionGenerator = Position.CreatePosition;
            var engine = new AnimalPlanetEngine(rabbit, porc, forest, AnimalMovement.CreateMovement);

            engine.EvaluateNextCommand("P T 3");
        }
    }
}
