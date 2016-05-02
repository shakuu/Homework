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
            int[] inputNum = new int[numOfRows]; // input
            int[] ColToRow = new int[numOfRows]; // cols to rows 
            int[] onesCount = new int[numOfRows]; // count the 1s on each row index 0 -> col 7


            //read input
            for (int row = 0; row < inputNum.Length; row++)
            {
                inputNum[row] = int.Parse(Console.ReadLine());
            }

            // columns to rows -- working
            int tempMask = 1;
            tempMask = tempMask << 7; // start reading at row 7, col 7 R->L

            for (int col = 0; col < numOfRows; col++)
            {
                for (int row = numOfRows - 1; row >= 0; row--)
                {
                    if ((inputNum[row] & tempMask) == tempMask)
                    {
                        ColToRow[col] = (ColToRow[col]) << 1;
                        ColToRow[col] = (ColToRow[col]) | 1;
                        onesCount[col]++;
                    }
                    else
                    {
                        ColToRow[col] = (ColToRow[col]) << 1;
                    }
                }
                // decrement col
                tempMask = tempMask >> 1;
            }

            //check rows
            //get sum of ones up to bound and after bound
            int onesBefore = 0;
            int onesAfter = 0;

            bool isEqual = false;

            for (int bound = 0; bound < numOfRows; bound++)
            {
                //reset the counters
                onesBefore = 0;
                onesAfter = 0;

                //sum number of ones before bound 
                for (int row = 0; row < bound; row++)
                {
                    onesBefore += onesCount[row];
                }

                //sum after
                for (int row = bound+1; row < numOfRows; row++)
                {
                    onesAfter += onesCount[row];
                }
                
                if (onesBefore==onesAfter && !isEqual)
                {
                    Console.WriteLine(numOfRows-1-bound);
                    Console.WriteLine(onesBefore);

                    isEqual = true;
                }
            }

            if (!isEqual)
            {
                Console.WriteLine("No");
            }
        }
    }
}
