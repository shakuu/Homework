using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace _05_Maximal_Area_Sum
{
    class Program
    {
        static int[][] tempMatrix;
        static int areaSize;

        static void Main(string[] args)
        {
            // Input: a file containing a matrix
            // Line1: containts matrix size
            var fileMatrix = @"D:\GitHub\Test-Files\05MaxSumIn.txt"; //Console.ReadLine();

            // Output file.
            var fileOutput = @"D:\GitHub\Test-Files\05MaxSumOut.txt";

            areaSize = 2; // possible read from console

            var reader = new StreamReader(fileMatrix);

            // Step 1: Read the size of the matrix
            // Possible different row/ cols numbers
            var matrixSize = reader
                .ReadLine()
                .Trim()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();

            tempMatrix = new int[areaSize][];

            // Read First 2 Lines.
            // Find their Max Sum.
            for (int row = 0;
                     row < areaSize;
                     row++)
            {
                tempMatrix[row] = ReadLine(reader.ReadLine());
            }

            // Get the maxSum of the first areaSize rows.
            var maxSum = FindMaxSum(tempMatrix);

            // Else keep reading rows. 
            // Keep checking max sums
            for (int row = areaSize; 
                     row < matrixSize[0]; 
                     row++)
            {
                // Overwrite an existing row 
                // starting with 0.
                var curRow = row % areaSize;

                // Read a row.
                tempMatrix[curRow] = ReadLine(reader.ReadLine());

                // Find max sum.
                var curSum = FindMaxSum(tempMatrix);

                maxSum = curSum > maxSum ?
                         curSum : maxSum;
            }

            // Close the reader
            reader.Close();

            // Print the Max Sum to a file.
            using (var writer = new StreamWriter(fileOutput, false, Encoding.UTF8))
            {
                writer.WriteLine(maxSum);
            }
        }

        static int[] ReadLine(string curLine)
        {
            // convert to ints
            var numbers = curLine
                .Trim()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();

            var toReturn = new int[numbers.Length - (areaSize - 1)];

            // Get First sum.
            for (int element = 0; element < areaSize; element++)
            {
                toReturn[0] += numbers[element];
            }

            // Get the rest.
            for (int element = 1;
                     element < toReturn.Length;
                     element++)
            {
                // Current sum = previous sum.
                toReturn[element] = toReturn[element - 1];

                // Subtract previous element.
                toReturn[element] -= numbers[element - 1];

                // Add the next element.
                toReturn[element] += numbers[element + (areaSize - 1)];
            }

            return toReturn;
        }

        static int FindMaxSum(int[][] curMatrix)
        {
            var maxSum = int.MinValue;

            for (int sum = 0; sum < curMatrix[0].Length; sum++)
            {
                var curSum = 0;

                for (int row = 0; row < curMatrix.Length; row++)
                {
                    curSum += curMatrix[row][sum];
                }

                maxSum = curSum > maxSum ?
                         curSum : maxSum;
            }


            return maxSum;
        }
    }
}
