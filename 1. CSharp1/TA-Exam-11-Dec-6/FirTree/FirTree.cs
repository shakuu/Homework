using System;

namespace FirTree
{
    class FirTree
    {
        static void Main()
        {
            // characters to print
            string Tree = "*";
            string Else = ".";

            //input
            int inputSizeN = int.Parse(Console.ReadLine());

            //format the input
            int height = inputSizeN;
            int width = ((inputSizeN - 1) * 2) - 1;
            int midPointW = (inputSizeN - 1) -1; // extra -1 to count from 0

            //Print
            for (int row = 0; row < height; row++)
            {
                for (int col = 0; col < width; col++)
                {
                    // Step 1: Print the tree
                    if (midPointW - row <= col && col <= midPointW + row
                        && row != height -1)
                    {
                        Console.Write(Tree);
                    }
                    // Step 2: Print the bottom
                    else if (row == height-1 && col == midPointW)
                    {
                        Console.Write(Tree);
                    }
                    else
                    {
                        Console.Write(Else);
                    }
                }
                //new line
                Console.WriteLine();
            }
        }
    }
}
