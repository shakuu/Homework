
namespace _05_Help_Doge
{
    using System;
    using System.Linq;

    class HelpDogeOriginal
    {
        // Variables.
        static int[] matrixSize;
        static byte[,] matrix;

        // Input fill
        static byte enemy = 1;
        static byte food = 2;

        // Tracking vars.
        static int successfulRuns = 0;

        static void Input()
        {
            // Matrix Size 
            matrixSize = Console.ReadLine()
                .Trim()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();

            matrix = new byte[matrixSize[0], matrixSize[1]];

            // Food coordinates.
            var posFood = Console.ReadLine()
                .Trim()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();

            matrix[posFood[0], posFood[1]] = (byte)food;

            // Enemies
            var numEnemies = int.Parse(Console.ReadLine());

            for (int enemies = 0; enemies < numEnemies; enemies++)
            {
                var posEnemy = Console.ReadLine()
                    .Trim()
                    .Split(' ')
                    .Select(int.Parse)
                    .ToArray();

                matrix[posEnemy[0], posEnemy[1]] = (byte)enemy;
            }
        }

        static void CheckCell(int row, int col)
        {
            // Def bool state = false;

            // enemy
            if (matrix[row, col] == enemy) return;
            
            // Food
            else if (matrix[row, col] == food)
            {
                successfulRuns++;
                return;
            }

            // Can Move ?

            if (col + 1 < matrixSize[1]) { CheckCell(row, col + 1); }
            if (row + 1 < matrixSize[0]) { CheckCell(row + 1, col); }

            return;
        }

        static void Main()
        {
            Input();

            // Send Doge on his journey
            CheckCell(0, 1);
            CheckCell(1, 0);

            Console.WriteLine(successfulRuns);
        }
    }
}
