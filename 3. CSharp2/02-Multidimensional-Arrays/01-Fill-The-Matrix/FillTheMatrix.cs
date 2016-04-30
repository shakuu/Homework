using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_Fill_The_Matrix
{
    class FillTheMatrix
    {
        private static int i;

        static void Main()
        {
            // input Size
            int arraySize = int.Parse(Console.ReadLine());

            // Type = a b c d 
            string arrayType = Console.ReadLine().ToLower();

            // Creat The Array
            int[,] toFill = new int[arraySize, arraySize];

            if (arrayType == "a")
            {
                toFill = OutputTypeA(toFill);
                PrintTheMatrix(toFill);
            }

            if (arrayType == "b")
            {
                toFill = OutputTypeB(toFill);
                PrintTheMatrix(toFill);
            }

            if (arrayType == "c")
            {
                toFill = OutputTypeC(toFill);
                PrintTheMatrix(toFill);
            }

        }

        // TYPE A
        public static int[,] OutputTypeA(int[,] toFill)
        {
            // Type A                   1 4 7
            // Columns Left to Right    2 5 8
            // Rows Top to Bottom       3 6 9

            // Start Filling with 1
            int toPrint = 1;

            // Columns First
            for (int col = 0; col < toFill.GetLength(0); col++)
            {
                // Then Rows
                for (int row = 0; row < toFill.GetLength(1); row++)
                {
                    toFill[col, row] = toPrint;
                    toPrint++;
                }
            }

            return toFill;
        }

        // TYPE B
        public static int[,] OutputTypeB(int[,] toFill)
        {
            // Type B                   1 6 7
            // Even Cols - Top to Bot   2 5 8
            // Odd Cols -  Bot to Top   3 4 9

            // Start Filling with 1
            int toPrint = 1;


            for (int col = 0; col < toFill.GetLength(0); col++)
            {
                // Even Columns -> top to bot
                if ((col & 1) == 0)
                {
                    for (int row = 0; row < toFill.GetLength(1); row++)
                    {
                        toFill[col, row] = toPrint;
                        toPrint++;
                    }
                }
                // odd col bot to top
                else
                {
                    for (int row = toFill.GetLength(1) - 1; row >= 0; row--)
                    {
                        toFill[col, row] = toPrint;
                        toPrint++;
                    }
                }

            }
            return toFill;
        }

        // TYPE C
        public static int[,] OutputTypeC(int[,] toFill)
        {
            // Type C                   4 7 9
            // Print                    2 5 8
            // Diagonals                1 3 6

            // Start Filling with 1
            int toPrint = 1;

            int Target = toFill.GetLength(1) - 1;

            // Print Like BATMAN ! 
            while (Target>=-(toFill.GetLength(1) - 1))
            {
                for (int row = 0; row < toFill.GetLength(1); row++)
                {
                    for (int col = 0; col < toFill.GetLength(0); col++)
                    {
                        if (row-col == Target)
                        {
                            toFill[col, row] = toPrint;
                            toPrint++;
                        }
                    }
                }

                Target--;
            }
            return toFill;
        }

        // PRINT 
        public static void PrintTheMatrix(int[,] toPrint)
        {
            string PrintString = "";

            for (int row = 0; row < toPrint.GetLength(1); row++)
            {
                for (int col = 0; col < toPrint.GetLength(0); col++)
                {
                    PrintString += toPrint[col, row] + " ";             // Build the string 
                }
                PrintString = PrintString.TrimEnd(' ');                 // Trim the extra white space
                PrintString += "\n";                                    // Add New Line
            }

            Console.Write(PrintString);                                 // Print the string

            return;
        }
    }
}
