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
            int TopBotSize = (inputSize - 1) / 2;
            int MidSize = (inputSize - 1) / 2 - 1;
            
            int vSize = 2 * TopBotSize + MidSize;
            int midPoint = (hSize - 1) / 2;
            string EmptyStr = " ";

            int EyeOffset = inputSize / 7;

            //for (int index = 17; index > 0; index++)
            //{
            //    if (inputSize / index == 3)
            //    {
            //        MidSize = index;
            //        break;
            //    }
            //}
            
            
           
            //FIX THIS 

            if (inputSize == 9 || inputSize == 11)
            {
                MidSize = 3;
            }

            if (inputSize == 13)
            {
                MidSize = 4;
            }

            if (inputSize == 17 || inputSize == 15)
            {
                MidSize = 5;
            }
            if (inputSize == 19)
            {
                MidSize = 6;
            }

            if (inputSize == 21 || inputSize == 23 )
            { 
                MidSize = 7;
            }

            if (inputSize == 25)
            {
                MidSize = 8;
            }

            if (inputSize == 27)
            {
                MidSize = 9;
            }
            if (inputSize == 29)
            {
                MidSize = 9;
            }
            if (inputSize == 31)
            {
                MidSize = 10;
            }

            if (inputSize == 33)
            { 
                MidSize = 11;
            }

            if (inputSize == 35)
            {
                MidSize = 11;
            }

            if (inputSize == 37)
            {
                MidSize = 12;
            }
            if (inputSize == 39)
            {
                MidSize = 13;
            }
            if (inputSize == 41)
            {
                MidSize = 13;
            }
            if (inputSize == 43)
            {
                MidSize = 14;
            }

            if (inputSize == 45)
            {
                MidSize = 15;
            }
            if (inputSize == 47)
            {
                MidSize = 15;
            }

            if (inputSize == 49)
            {
                MidSize = 16;
            }
            if (inputSize == 51)
            {
                MidSize = 17;
            }






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
                        && col <= hSize - ((inputSize+1) / 2))              // MID FAt
                    {
                        Console.Write(charToPrint);
                    }
                    else if (row >= TopBotSize + MidSize &&
                        col > inputSize + (row - ( TopBotSize + MidSize)) && 
                        col < hSize -1 - inputSize - (row - (TopBotSize + MidSize)))        // Bot Triangle
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
