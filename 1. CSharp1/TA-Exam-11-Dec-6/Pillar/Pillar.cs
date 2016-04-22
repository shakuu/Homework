using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pillar
{
    class Pillar
    {
        static void Main()
        {
            int numOfRows = 8;

            // input 8x Byte
            int[] inputNum = new int[numOfRows];
            int[] ColToRow = new int[numOfRows];

            //read input
            for (int row = 0; row < inputNum.Length; row++)
            {
                inputNum[row] = int.Parse(Console.ReadLine());
            }

            // columns to rows -- working
            int tempMask = 1;
            tempMask = tempMask << 7; // start reading at row 7, col 7 R->L

            for (int i = 0; i < numOfRows; i++)
            {
                for (int row = numOfRows - 1; row >= 0; row--)
                {
                    if ((inputNum[row] & tempMask) == tempMask)
                    {
                        ColToRow[i] = (ColToRow[i]) << 1;
                        ColToRow[i] = (ColToRow[i]) | 1;
                    }
                    else
                    {
                        ColToRow[i] = (ColToRow[i]) << 1;
                    }
                }
                // decrement col
                tempMask = tempMask >> 1;
            }
            

        }
    }
}
