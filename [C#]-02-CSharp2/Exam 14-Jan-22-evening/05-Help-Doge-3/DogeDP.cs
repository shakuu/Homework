
namespace _05_Help_Doge_3
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Numerics;

    class DogeDP
    {
        // Variables.
        static BigInteger[,] dpMatrix;
        static bool[,] matrix;

        // Tracking vars.
        static int foodCol;
        static int foodRow;

        static void Input()
        {
            // Matrix Size 
            var matrixSize = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();

            // Food coordinates.
            var posFood = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();

            foodRow = posFood[0] + 1;
            foodCol = posFood[1] + 1;

            // Dynamic Programming
            dpMatrix = new BigInteger[foodRow, foodCol];
            matrix = new bool[foodRow, foodCol];

            // Enemies
            var numEnemies = int.Parse(Console.ReadLine());

            for (int enemies = 0; enemies < numEnemies; enemies++)
            {
                var posEnemy = Console.ReadLine()
                    .Split(' ')
                    .Select(int.Parse)
                    .ToArray();

                if (posEnemy[0] < foodRow && posEnemy[1] < foodCol)
                {
                    matrix[posEnemy[0], posEnemy[1]] = true;
                }
            }
        }
        static void DynamicDoge()
        {
            // Row 0 1s
            // Col 0 1s
            // Cell with an enemy 0
            // ( not allowed to go there )
            dpMatrix[0, 0] = 1;

            for (int col = 1; col < foodCol; col++)
                dpMatrix[0, col] = matrix[0, col] ? 0 : dpMatrix[0, col - 1];

            for (int row = 1; row < foodRow; row++)
                dpMatrix[row, 0] = matrix[row, 0] ? 0 : dpMatrix[row - 1, 0];

            for (int row = 1; row < foodRow; row++)
            {
                for (int col = 1; col < foodCol; col++)
                {
                    if (!matrix[row, col])
                    {
                        dpMatrix[row, col] =
                            dpMatrix[row - 1, col] + dpMatrix[row, col - 1];
                    }
                    else
                    {
                        dpMatrix[row, col] = 0;
                    }
                }
            }
        }
        static void Main()
        {
            Input();
            DynamicDoge();

            Console.WriteLine(dpMatrix[foodRow - 1, foodCol - 1]);
        }
    }
}
