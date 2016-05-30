
namespace _03_Slides
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

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

            // Ball position W D (row col)
            dims = Console.ReadLine()
               .Trim()
               .Split(' ')
               .Select(int.Parse)
               .ToArray();

            ballRow = dims[0];
            ballCol = dims[1];
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
                        break;
                    case Empty:
                        break;
                    case Basket:
                        break;
                    default:
                        throw new ArgumentException
                            ("invalid input");
                }
            }
        }

        static void SlideTheBall()
        {
            var direction = cuboid[ballRow, ballCol, ballLvl]
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)[1];

            switch (direction)
            {
                case "F":
                    break;
                case "B":
                    break;
                case "L":
                    break;
                case "R":
                    break;
                case "FL":
                    break;
                case "FR":
                    break;
                case "BL":
                    break;
                case "BR":
                    break;
                default:
                    break;
            }
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
        }
    }
}
