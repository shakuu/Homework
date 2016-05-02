using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FireInTheMatrix
{
    class FireMatrix
    {
        static void Main()
        {
            //input -> horizontal size
            int sizeW = int.Parse(Console.ReadLine());
            int sizeH = sizeW + sizeW / 4 + 1;
            //create the matrix
            char[,] theFireMatrix = new char[sizeH, sizeW];
            //Fill theFireMatrix with dots
            for (int row = 0; row < sizeH; row++)
            {
                for (int col = 0; col < sizeW; col++)
                {
                   theFireMatrix[row, col] = '.';
                }
            }

            //the Torch
            for ( int row = 0; row < sizeW/2;row++)
            {
                for (int col = 0; col< 1+row;col++)
                {
                    theFireMatrix[sizeH - 1 - row, sizeW / 2 -1 - col] = '\\';
                    theFireMatrix[sizeH - 1 - row, sizeW / 2  + col] = '/';
                }
            }
            //Top of the Torch
            for (int col = 0; col<sizeW; col++)
            {
                theFireMatrix[sizeH - sizeW / 2 - 1, col] = '-';
            }
            //Top part of the Flame
            for (int row = 0; row< sizeW/2; row++)
            {
                theFireMatrix[row, sizeW / 2 - 1 - row] = '#';
                theFireMatrix[row, sizeW / 2 + row] = '#';
            }
            //Bottom part of the Flame
            for (int row = 0; row< sizeW/4; row++)
            {
                theFireMatrix[sizeW / 2 + row, 0 + row] = '#';
                theFireMatrix[sizeW / 2 + row, sizeW - 1 - row] = '#';
            }
            //PRINT
            for ( int row = 0; row< sizeH;row++)
            {
                for (int col =0; col<sizeW;col++)
                {
                    Console.Write(theFireMatrix[row, col]);
                }
                Console.WriteLine();
            }
        }
    }
}
