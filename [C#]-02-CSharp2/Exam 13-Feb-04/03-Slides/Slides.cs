
namespace _03_Slides
{
    using System;
    using System.Linq;

    class Slides
    {
        // Consts
        const char Slide = 'S';
        const char Empty = 'E';
        const char Basket = 'B';
        const char Teleport = 'T';

        // Variables 
        static string[,,] cuboid;
        static int ballRow;
        static int ballCol;
        static int ballLvl;
        static bool isStuck = false;
        static bool isOut = false;

        // Input: Working.
        static void Input()
        {
            // Line W H D
            // W -> Cols
            // H -> Levels
            // D -> Rows
            var dims = Console.ReadLine()
                .Trim()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();

            // Init the cuboid
            // dims[2] -> rows
            // dims[0] -> cols
            // dims[1] -> levels
            cuboid = new string[dims[2], dims[0], dims[1]];

            // Fill the cuboid
            // Next H Lines
            FillTheCuboid();

            // Ball position W D (col row)
            dims = Console.ReadLine()
               .Trim()
               .Split(' ')
               .Select(int.Parse)
               .ToArray();

            ballRow = dims[1];
            ballCol = dims[0];
            ballLvl = 0; // def

            // TEST
            PrintCuboid();
        }
        static void FillTheCuboid()

        {
            // H Levels
            // <row info> | <row info> | <row info>
            // <col><col> | <col><col> | <col><col>
            for (int level = 0; level < cuboid.GetLength(2); level++)
            {
                // Get the input
                // split it for each row
                var input = Console.ReadLine()
                    .Split(
                        new[] { '|' },
                        StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                for (int row = 0; row < cuboid.GetLength(0); row++)
                {
                    var cols = input[row]
                        .Split(new[] { '(', ')' },
                            StringSplitOptions.RemoveEmptyEntries)
                        .Where(x => !(x == " "))
                        .ToArray();

                    // Fill in the read input
                    for (int col = 0; col < cuboid.GetLength(1); col++)
                    {
                        cuboid[row, col, level] = cols[col].Trim();
                    }
                }
            }
        }

        // Logic!
        static void MoveTheBall()
        {
            while (true)
            {
                // Get Ball curent cell contents
                // Move the ball accordingly.
                var nextMove = cuboid[ballRow, ballCol, ballLvl];

                // Slide, Teleport, Empty, Basket
                switch (nextMove[0])
                {
                    case Slide:
                        SlideTheBall();
                        break;
                    case Teleport:
                        TeleportTheBall();
                        break;
                    case Empty:
                        EmptyTheBall();
                        break;
                    case Basket:
                        BasketTheBall();
                        break;
                    default:
                        throw new ArgumentException
                            ("invalid input");
                }

                // End on:
                // 1. Basket
                // 2. Slide into a Wall ( out of bounds )
                // 3. Out of the cube
                if (isOut) break;
                if (isStuck) break;
                if (ballLvl >= cuboid.GetLength(2)) break;
            }
        }
        static void SlideTheBall()
        {
            var direction = cuboid[ballRow, ballCol, ballLvl]
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)[1];

            if (ballLvl == cuboid.GetLength(2) - 1)
            { isOut = true; return; }

            var buRow = ballRow;
            var buCol = ballCol;
            var buLvl = ballLvl;

            // Move On the Level
            switch (direction)
            {
                case "F":
                    ballRow--;
                    break;
                case "B":
                    ballRow++;
                    break;
                case "L":
                    ballCol--;
                    break;
                case "R":
                    ballCol++;
                    break;
                case "FL":
                    ballRow--;
                    ballCol--;
                    break;
                case "FR":
                    ballRow--;
                    ballCol++;
                    break;
                case "BL":
                    ballRow++;
                    ballCol--;
                    break;
                case "BR":
                    ballRow++;
                    ballCol++;
                    break;
                default:
                    break;
            }
            // And move a level down;
            ballLvl++;

            // Check if the Ball is stuck
            if (ballRow >= cuboid.GetLength(0)
                || ballCol >= cuboid.GetLength(1)
                || ballCol < 0
                || ballRow < 0)
            {
                // Revert to previous 
                // position for correct output
                ballRow = buRow;
                ballCol = buCol;
                ballLvl = buLvl;
                isStuck = true;
            }
        }
        static void TeleportTheBall()
        {
            // T W D
            // Col Row
            var newPosition = cuboid[ballRow, ballCol, ballLvl]
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Where(x => char.IsDigit(x[0]))
                .Select(int.Parse)
                .ToArray();

            // Level does NOT change
            ballRow = newPosition[1];
            ballCol = newPosition[0];
        }
        static void EmptyTheBall()
        {
            if (ballLvl == cuboid.GetLength(2) - 1)
            { isOut = true; return; }

            else ballLvl++;
        }
        static void BasketTheBall()
        {
            isStuck = true;
        }

        // Output
        static void Output()
        {
            if (isStuck) Console.WriteLine("No");
            else Console.WriteLine("Yes");
            // w, h, d
            Console.WriteLine("{0} {1} {2}",
                ballCol, ballLvl, ballRow);
        }

        static void PrintCuboid()
        {
            for (int level = 0; level < cuboid.GetLength(2); level++)
            {
                for (int row = 0; row < cuboid.GetLength(0); row++)
                {
                    for (int col = 0; col < cuboid.GetLength(1); col++)
                    {
                        Console.Write(cuboid[row, col, level] + " | ");
                    }
                    Console.WriteLine();
                }
                Console.WriteLine();
            }
        }

        static void Main()
        {
            Input();
            MoveTheBall();
            Output();
        }
    }
}
