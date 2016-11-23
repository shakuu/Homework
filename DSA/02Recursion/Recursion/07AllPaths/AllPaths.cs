using System;

namespace _07AllPaths
{
    public class AllPaths
    {
        private const int MatrixSize = 6;

        private static int validPathsCount;

        private static bool[,] matrix =
        {
            { true, false, false, false, true, true },
            { true, true, true, false, false, false },
            { false, false, true, true, true, true },
            { true, true, true, false, false, true },
            { true, true, true, false, false, true },
            { true, true, true, true, true, true },
        };

        private static int goalRowCoordinate = 5;
        private static int goalColCoordinate = 5;

        public static void Main()
        {
            AllPaths.FindPath(0, 0);

            Console.WriteLine(AllPaths.validPathsCount);
        }

        private static void FindPath(int row, int col)
        {
            if (row == AllPaths.goalRowCoordinate && col == AllPaths.goalColCoordinate)
            {
                AllPaths.validPathsCount++;
                return;
            }

            if (row + 1 < AllPaths.MatrixSize && AllPaths.matrix[row + 1, col])
            {

                AllPaths.matrix[row + 1, col] = false;
                AllPaths.FindPath(row + 1, col);
                AllPaths.matrix[row + 1, col] = true;
            }

            if (col + 1 < AllPaths.MatrixSize && AllPaths.matrix[row, col + 1])
            {
                AllPaths.matrix[row, col + 1] = false;
                AllPaths.FindPath(row, col + 1);
                AllPaths.matrix[row, col + 1] = true;
            }

            if (row - 1 >= 0 && AllPaths.matrix[row - 1, col])
            {
                AllPaths.matrix[row - 1, col] = false;
                AllPaths.FindPath(row - 1, col);
                AllPaths.matrix[row - 1, col] = true;
            }

            if (col - 1 >= 0 && AllPaths.matrix[row, col - 1])
            {
                AllPaths.matrix[row, col - 1] = false;
                AllPaths.FindPath(row, col - 1);
                AllPaths.matrix[row, col - 1] = true;
            }
        }
    }
}
