using System;

namespace _09LargestConnectedArea
{
    public class LargestConnectedArea
    {
        private const int MatrixSize = 6;

        private static bool[,] matrix =
        {
            { true, false, false, false, true, true },
            { true, true, true, false, false, false },
            { false, false, false, true, true, true },
            { true, true, true, false, false, true },
            { true, true, true, false, false, true },
            { true, true, true, true, true, true },
        };

        private static int maxSteps = 0;

        public static void Main()
        {
            LargestConnectedArea.FindPath(0, 0, 0);

            Console.WriteLine(LargestConnectedArea.maxSteps);
        }

        private static void FindPath(int row, int col, int steps)
        {
            if (row + 1 < LargestConnectedArea.MatrixSize && LargestConnectedArea.matrix[row + 1, col])
            {
                LargestConnectedArea.matrix[row + 1, col] = false;
                LargestConnectedArea.FindPath(row + 1, col, steps + 1);
                LargestConnectedArea.matrix[row + 1, col] = true;
            }

            if (col + 1 < LargestConnectedArea.MatrixSize && LargestConnectedArea.matrix[row, col + 1])
            {
                LargestConnectedArea.matrix[row, col + 1] = false;
                LargestConnectedArea.FindPath(row, col + 1, steps + 1);
                LargestConnectedArea.matrix[row, col + 1] = true;
            }

            if (row - 1 >= 0 && LargestConnectedArea.matrix[row - 1, col])
            {
                LargestConnectedArea.matrix[row - 1, col] = false;
                LargestConnectedArea.FindPath(row - 1, col, steps + 1);
                LargestConnectedArea.matrix[row - 1, col] = true;
            }

            if (col - 1 >= 0 && LargestConnectedArea.matrix[row, col - 1])
            {
                LargestConnectedArea.matrix[row, col - 1] = false;
                LargestConnectedArea.FindPath(row, col - 1, steps + 1);
                LargestConnectedArea.matrix[row, col - 1] = true;
            }

            if (LargestConnectedArea.maxSteps < steps)
            {
                LargestConnectedArea.maxSteps = steps;
            }
        }
    }
}
