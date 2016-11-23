using System;

namespace _08SinglePath
{
    public class SinglePath
    {
        private const int MatrixSize = 100;

        private static bool[,] matrix = new bool[SinglePath.MatrixSize, SinglePath.MatrixSize];

        private static bool isPossible;

        private static int goalRowCoordinate = 80;
        private static int goalColCoordinate = 90;

        public static void Main()
        {
            SinglePath.FindPath(0, 0);

            Console.WriteLine(SinglePath.isPossible);
        }

        private static void FindPath(int row, int col)
        {
            if (SinglePath.isPossible)
            {
                return;
            }

            if (row == SinglePath.goalRowCoordinate && col == SinglePath.goalColCoordinate)
            {
                SinglePath.isPossible = true;
                return;
            }

            if (row + 1 < SinglePath.MatrixSize && !SinglePath.matrix[row + 1, col])
            {

                SinglePath.matrix[row + 1, col] = true;
                SinglePath.FindPath(row + 1, col);
                SinglePath.matrix[row + 1, col] = false;
            }

            if (col + 1 < SinglePath.MatrixSize && !SinglePath.matrix[row, col + 1])
            {
                SinglePath.matrix[row, col + 1] = true;
                SinglePath.FindPath(row, col + 1);
                SinglePath.matrix[row, col + 1] = false;
            }

            if (row - 1 >= 0 && !SinglePath.matrix[row - 1, col])
            {
                SinglePath.matrix[row - 1, col] = true;
                SinglePath.FindPath(row - 1, col);
                SinglePath.matrix[row - 1, col] = false;
            }

            if (col - 1 >= 0 && !SinglePath.matrix[row, col - 1])
            {
                SinglePath.matrix[row, col - 1] = true;
                SinglePath.FindPath(row, col - 1);
                SinglePath.matrix[row, col - 1] = false;
            }
        }
    }
}
