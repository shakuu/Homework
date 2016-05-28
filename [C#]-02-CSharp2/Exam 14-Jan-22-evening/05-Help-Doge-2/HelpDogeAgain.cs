
// Too slow 

namespace _05_Help_Doge_2
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    class HelpDogeAgain
    {
        // Variables.
        static int[] matrixSize;
        static byte[,] matrix;
        static bool[,] flags;

        // Input fill
        static byte enemy = 1;
        static byte food = 2;

        // Tracking vars.
        static int successfulRuns = 0;
        static int foodCol;
        static int foodRow;

        static void Input()
        {
            // Matrix Size 
            matrixSize = Console.ReadLine()
                .Trim()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();

            matrix = new byte[matrixSize[0], matrixSize[1]];
            flags = new bool[matrixSize[0], matrixSize[1]];

            // Food coordinates.
            var posFood = Console.ReadLine()
                .Trim()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();

            matrix[posFood[0], posFood[1]] = (byte)food;
            foodRow = posFood[0];
            foodCol = posFood[1];

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

        // 20/ 100 TOO SLOW
        // TODO: REDUCE NUMBER OF CHECKS
        // 1. Cannot go further right then FoodCol
        // 2. Cannot go further down then FoodRow
        // 30/ 100
        //
        static bool CheckCell(int row, int col)
        {
            // Def bool state = false;

            // enemy
            if (matrix[row, col] == enemy) return true;

            // Food
            else if (matrix[row, col] == food)
            {
                successfulRuns++;
                return false;
            }

            var obstacleRight = false;
            var obstacleDown = false;

            // Can Move ?
            if (col + 1 < matrixSize[1] && col + 1 <= foodCol && !flags[row, col + 1])
            { obstacleRight = CheckCell(row, col + 1); }

            if (row + 1 < matrixSize[0] && row + 1 <= foodRow && !flags[row + 1, col])
            { obstacleDown = CheckCell(row + 1, col); }

            if (obstacleDown && obstacleRight)
            {
                flags[row, col] = true;
                return true;
            }

            return false;
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
