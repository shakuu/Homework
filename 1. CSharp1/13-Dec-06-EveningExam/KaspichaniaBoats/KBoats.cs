using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KaspichaniaBoats
{
    class KBoats
    {
        static void Main()
        {
            int inputSizeN = int.Parse(Console.ReadLine());

            int boatHeight = 6 + ((inputSizeN - 3) / 2) * 3;
            int boatWidth = 2 * inputSizeN + 1;

            string[,] theBoat = new string[boatHeight, boatWidth];

            //add dots
            for(int row = 0; row< boatHeight; row++)
            {
                for(int col = 0; col< boatWidth; col++)
                {
                    theBoat[row, col] = ".";
                }
            }

            //Construction
            //Center vertical beam
            for(int row = 0; row< boatHeight; row++)
            {
                theBoat[row, inputSizeN] = "*";
            }
            //center horizontal beam -> 2/3 height from top 
            for (int col = 0; col< boatWidth; col++)
            {
                theBoat[(boatHeight / 3) * 2 - 1, col] = "*";
            }
            //bottom horizontal beam -> size N
            for ( int col = (boatWidth-inputSizeN)/2;
                col < (boatWidth - inputSizeN) / 2  + inputSizeN; col++)
            {
                theBoat[boatHeight - 1, col] = "*";
            }
            //build Sails
            for(int row=1;row< (boatHeight / 3) * 2 - 1;row++)
            {
                theBoat[row, inputSizeN - row] = "*";
                theBoat[row, inputSizeN + row] = "*";
            }
            //build bottom frame
            for(int row = boatHeight-2, offset = 1;row > (boatHeight / 3) * 2 - 1;row--, offset ++)
            {
                theBoat[row, inputSizeN - (((inputSizeN - 1) / 2 + offset)) ] = "*";
                theBoat[row, inputSizeN + (((inputSizeN - 1) / 2 + offset)) ] = "*";
            }

            //test
            for (int row = 0; row < boatHeight; row++)
            {
                for (int col = 0; col < boatWidth; col++)
                {
                    Console.Write(theBoat[row, col]);
                }
                Console.WriteLine();
            }
        }
    }
}
