
namespace _03_Bit_Shift_Matrix
{
    using System;
    using System.Linq;
    using System.Numerics;

    class Program
    {
        static int sizeRows;
        static int sizeCols;

        static void Main()
        {
            // Input -> 
            // Size Row
            // Size Col
            // Number of Moves
            BigInteger outputSum = 0;

            sizeRows = int.Parse(Console.ReadLine());
            sizeCols = int.Parse(Console.ReadLine());

            var theMatrix = new BigInteger[sizeRows, sizeCols];

            // Fill the Matrix
            FillTheMatrix(theMatrix);

            // Coefficient
            var COEF = sizeRows >= sizeCols ?
                       sizeRows : sizeCols;

            // Number of moves - not used
            var Moves = int.Parse(Console.ReadLine());

            var CODES = Console.ReadLine()
                .Trim()
                .Split()
                .Select(int.Parse)
                .ToArray();

            var curRow = sizeRows - 1;
            var curCol = 0;

            foreach (var code in CODES)
            {
                var targetRow = code / COEF;
                var targetCol = code % COEF;

                // Move Columns first.
                for (int move = Math.Min(curCol, targetCol); 
                         move <= Math.Max(curCol, targetCol); 
                         move++)
                {
                    outputSum += theMatrix[curRow, move];
                    theMatrix[curRow, move] = 0;
                }

                curCol = targetCol;

                // Move Rows second.
                for (int move = Math.Min(curRow, targetRow);
                         move <= Math.Max(curRow, targetRow);
                         move++)
                {
                    outputSum += theMatrix[move, curCol];
                    theMatrix[move, curCol] = 0;
                }

                curRow = targetRow;
            }

            Console.WriteLine(outputSum);
        }

        static void FillTheMatrix(BigInteger[,] toFill)
        {
            var curFill = (BigInteger)1;

            // Fill Last Row
            for (int curCol = 0;
                     curCol < toFill.GetLength(1);
                     curCol++)
            {
                toFill[sizeRows - 1, curCol] = curFill;
                curFill <<= 1;
            }

            for (int curCol = 0;
                     curCol < sizeCols;
                     curCol++)
            {
                curFill = toFill[sizeRows - 1, curCol];
                curFill <<= 1;

                for (int curRow = sizeRows - 2;
                         curRow >= 0;
                         curRow--)
                {
                    toFill[curRow, curCol] = curFill;
                    curFill <<= 1;
                }
            }
        }
    }
}
