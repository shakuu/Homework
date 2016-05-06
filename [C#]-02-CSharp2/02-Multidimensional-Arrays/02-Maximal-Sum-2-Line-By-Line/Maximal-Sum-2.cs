using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_Maximal_Sum_2_Line_By_Line
{
    class Program
    {
        static void Main()
        {
            // TODO: 80/ 100 TIME LIMIT

            // input - Line 1: Rows, Empty, Cols
            string[] Sizes = Console.ReadLine()
                                   .Trim(' ')
                                   .Split(' ');

            // Variables
            byte areaSize = 3;

            short MaxSum;
            short curSum;

            short[][] curSums = new short[areaSize][];

            // Read First 3 Lines
            for (int curRow = 0;
                     curRow < areaSize;
                     curRow++)
            {
                curSums[curRow] = ReadInputLine(areaSize);
            }

            // Find the First Max Sum
            MaxSum = FindMaxSum(curSums);

            // End if just 3 rows if input
            if (int.Parse(Sizes[0]) == 3)
            {
                Console.WriteLine(MaxSum);
                return;
            }

            // if not keep reading rows 

            int RowToWrite = 0;

            for (int Row = 3;
                     Row < int.Parse(Sizes[0]);
                     Row++)
            {
                // Read a new row
                curSums[RowToWrite % areaSize] =
                            ReadInputLine(areaSize);

                // find Max Sum
                MaxSum = (curSum = FindMaxSum(curSums)) > MaxSum ? //FindMaxSum
                          curSum : MaxSum;

                RowToWrite++;
            }

            // output
            Console.WriteLine(MaxSum);
        }

        // Read A line - Working
        // Store each input line
        // as an area of the sum
        // of each 3 elements
        public static short[] ReadInputLine(short areaSize)
        {
            string[] Input = Console.ReadLine()
                                    .Trim(' ')
                                    .Split(' ');

            short[] ArrayOfSums = new short[Input.Length - (areaSize - 1)];

            ArrayOfSums[0] = (short)(short.Parse(Input[0]) +   // manually add
                                     short.Parse(Input[1]) +   // first element
                                     short.Parse(Input[2]));   // to read faster

            for (int curElement = 1;
                     curElement < Input.Length - (areaSize - 1);
                     curElement++)
            {
                ArrayOfSums[curElement] =                                  // 1. Current sum
                        ArrayOfSums[curElement - 1];                       // = precvious sum
                                                                           //  
                ArrayOfSums[curElement] -=                                 // 2. Subtract the
                        short.Parse(Input[curElement - 1]);                // previous input 
                                                                           // element
                ArrayOfSums[curElement] +=                                 // 3. Add the next
                        short.Parse(Input[curElement + (areaSize - 1)]);   // input element

            }


            return ArrayOfSums;
        }

        public static short FindMaxSum(short[][] curRows)
        {
            short MaxSum = short.MinValue;
            short curSum = 0;

            for (int curElement = 0;
                curElement < curRows[0].Length;
                curElement++)
            {
                //curSum = 0;

                //for (int Row = 0;
                //         Row < curRows.Length;
                //         Row++)
                //{
                //    curSum += curRows[Row][curElement];
                //}

                curSum = (short)(curRows[0][curElement] +
                                 curRows[1][curElement] +
                                 curRows[2][curElement]);

                MaxSum = curSum > MaxSum ?
                         curSum : MaxSum;
            }
            
            return MaxSum;
        }

        //public static short MaxSumGuess(short[][] curRows)
        //{
        //    short MaxSum = short.MinValue;
        //    short curSum = 0;

        //    for (int curElement = 0; curElement < curRows.Length; curElement++)
        //    {
        //        curSum = 0;

        //        for (int curRow = 0; curRow < curRows.Length; curRow++)
        //        {
        //            curSum += (curRows[curRow][Array.IndexOf(curRows[curElement], curRows[curElement].Max())]);
        //        }

        //        if (curSum > MaxSum)
        //        {
        //            MaxSum = curSum;
        //        }
        //    }

        //    return MaxSum;
        //}
    }
}
