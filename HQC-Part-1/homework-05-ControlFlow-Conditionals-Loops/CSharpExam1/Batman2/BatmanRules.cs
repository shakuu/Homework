using System;
using System.Text;

namespace Batman
{
    class Batman // TO DO 
    {
        static void Main()
        {
            //input
            int inputSize = int.Parse(Console.ReadLine());
            string charToPrint = Console.ReadLine();

            //variables 
            int hSize = 3 * inputSize;
            int TopBotSize = inputSize / 3; // correct and fast
            int MidSize = (inputSize - 1) / 2 - 1;

            int vSize = 2 * TopBotSize + MidSize;
            int midPoint = (hSize - 1) / 2;
            string EmptyStr = " ";

            int EyeOffset = inputSize / 7;

            // Print
            for (int row = 0; row < vSize; row++)
            {
                for (int col = 0; col < hSize; col++)
                {
                    //write
                    //TOP part
                    if (row < TopBotSize &&       //top third
                        col < inputSize &&      // not more than input
                        col >= row)              // offset one left
                    {
                        Console.Write(charToPrint);
                    }
                    else if (row < TopBotSize       //TOP RIGHT 
                        && col > (hSize - 1 - inputSize)
                        && col <= hSize - 1 - row)
                    {
                        Console.Write(charToPrint);
                    }
                    else if (row == TopBotSize - 1 &&
                        (col == midPoint - 1 || col == midPoint + 1))              // BAT EYES
                    {
                        Console.Write(charToPrint);
                    }
                    else if (row >= TopBotSize && row < TopBotSize + MidSize
                        && col >= (inputSize - 1) / 2
                        && col <= hSize - ((inputSize + 1) / 2))              // MID FAt
                    {
                        Console.Write(charToPrint);
                    }
                    else if (row >= TopBotSize + MidSize &&
                        col > inputSize + (row - (TopBotSize + MidSize)) &&
                        col < hSize - 1 - inputSize - (row - (TopBotSize + MidSize)))        // Bot Triangle
                    {
                        Console.Write(charToPrint);

                    }
                    else
                    {
                        Console.Write(EmptyStr);
                    }
                }

                //new line
                Console.WriteLine();
            }
        }
    }
}
