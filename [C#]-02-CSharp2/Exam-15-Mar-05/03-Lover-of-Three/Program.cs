
namespace _03_Lover_of_Three
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Numerics;

    class Program
    {
        static void Main()
        {
            var directions = new Dictionary<string, string>()
            {
                { "RU", "-1 1" },
                { "UR", "-1 1" },
                { "LU", "-1 -1" },
                { "UL", "-1 -1" },
                { "DL", "1 -1" },
                { "LD", "1 -1" },
                { "DR", "1 1" },
                { "RD", "1 1" },
            };

            // Input Matrix Size 0 row 1 col
            var matrixSizes = Console.ReadLine()
                .Trim()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();

            var matrix = FillTheMatrix(matrixSizes);

            var inputLines = int.Parse(Console.ReadLine());

            // Start at botom left corner
            var posRow = matrixSizes[0] - 1;
            var posCol = 0;

            BigInteger outputSum = 0;
            var lastCell = 0;

            for (int line = 0; line < inputLines; line++)
            {
                var inputLine = Console.ReadLine()
                    .Trim()
                    .Split(' ')
                    .ToArray();

                var speed = directions[inputLine[0]]
                    .Split(' ')
                    .Select(int.Parse)
                    .ToArray();

                var moves = int.Parse(inputLine[1]);

                // Move the pawn
                // Step 1: Add current Position again
                //outputSum += lastCell;

                for (int move = 0; move < moves; move++)
                {
                    try
                    {
                        lastCell = matrix[posRow, posCol];
                        matrix[posRow, posCol] = 0;

                        outputSum += lastCell;

                        if (move != moves-1)
                        {
                            posRow += speed[0];
                            posCol += speed[1];
                        }
                    }
                    catch (IndexOutOfRangeException)
                    {
                        posRow -= speed[0];
                        posCol -= speed[1];
                        break;
                    }
                }
            }

            Console.WriteLine(outputSum);
        }

        // Get the matrix in the correct format
        static int[,] FillTheMatrix(int[] size)

        {
            var matrix = new int[size[0], size[1]];

            var step = 3;
            var fill = 0;

            // Row 1
            for (int col = 0; col < size[1]; col++)
            {
                matrix[size[0] - 1, col] = fill;
                fill += step;
            }

            // The rest
            for (int col = 0; col < size[1]; col++)
            {
                fill = matrix[size[0] - 1, col] + step;

                for (int row = size[0] - 2; row >= 0; row--)
                {
                    matrix[row, col] = fill;
                    fill += step;
                }
            }

            return matrix;
        }
    }
}
