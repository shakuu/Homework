
namespace _03_Patterns
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Numerics;

    // A B C
    //     D
    //     E F G 
    // A = B - 1 etc

    class Patterns
    {
        // Variables.
        static int matrixSize;
        static int[][] matrix;

        static bool hasValidPattern = false;
        static BigInteger maxSum;
            

        static void Input()
        {
            matrixSize = int.Parse(Console.ReadLine());

            matrix = new int[matrixSize][];

            // input 
            for (int jag = 0; jag < matrix.Length; jag++)
            {
                matrix[jag] = Console.ReadLine()
                    .Trim()
                    .Split(' ')
                    .Select(int.Parse)
                    .ToArray();
            }
        }

        static void Output()
        {
            if (hasValidPattern)
            {
                Console.WriteLine("YES {0}", maxSum);
            }
            else
            {
                Console.WriteLine("NO {0}", FindMaxDiagonalSum());
            }
        }

        static string FindMaxDiagonalSum()
        {
            BigInteger sum = 0;

            for (int index = 0; index < matrixSize; index++)
            {
                sum += matrix[index][index];
            }

            return sum.ToString();
        }

        static void Logic()
        {
            for (int row = 0; row < matrixSize; row++)
            {
                for (int col = 0; col < matrixSize; col++)
                {
                    CheckPattern(row, col);
                }
            }
        }

        static void CheckPattern(int row, int col)
        {
            BigInteger sum = 0;

            try
            {
                var value = matrix[row][col];
                sum += value;

                for (int delta = 1; delta < 3; delta++)
                {
                    // If match
                    if (matrix[row][col + delta] - 1 == value)
                    {
                        value = matrix[row][col + delta];
                        sum += matrix[row][col + delta];
                    }
                    else
                    {
                        return;
                    }
                }

                if (matrix[row + 1][col + 2] - 1 == value)
                {
                    value = matrix[row + 1][col + 2];
                    sum += matrix[row + 1][col + 2];
                }
                else
                {
                    return;
                }

                for (int delta = 0; delta < 3; delta++)
                {
                    // If match
                    if (matrix[row + 2][col + 2 + delta] - 1 == value)
                    {
                        value = matrix[row + 2][col + 2 + delta];
                        sum += matrix[row + 2][col + 2 + delta];
                    }
                    else
                    {
                        return;
                    }
                }

                // This is the first valid pattern found
                if (!hasValidPattern) maxSum = sum;

                hasValidPattern = true;

                maxSum = sum > maxSum ?
                         sum : maxSum;
            }
            catch (IndexOutOfRangeException)
            {
                return;
            }
        }

        static void Main()
        {
            Input();
            Logic();
            Output();
        }
    }
}
