using System;

namespace OnesAndZeroes
{
    class Program
    {
        static void Main()
        {
            //given
            string[] printZero = new string[]
            {
                "###",
                "#.#",
                "#.#",
                "#.#",
                "###"
            };

            string[] printOne = new string[]
            {
                ".#.",
                "##.",
                ".#.",
                ".#.",
                "###"
            };

            string Space = ".";

            int maxBit = 16;
            int stringRows = 5;

            //input non negative int
            uint InputNumber = uint.Parse(Console.ReadLine());
            
            // variables
            string[] printRows = new string[]
            {
                "",
                "",
                "",
                "",
                ""
            };
        
            //Build the strings
            for (int col = 0; col < maxBit; col++)      //For the Rightmost 16 positions
            {
                //Step 1: Get Current Bit Value - Left to Rgiht
                uint currBit = (InputNumber & (uint)(1 << (maxBit - 1 - col))) >> (maxBit - 1 - col);

                // Step 2: Build the String
                for (int row = 0; row < stringRows; row++)
                {
                    //Print 0 or 1
                    if (currBit == 1)
                    {
                        printRows[row] += printOne[row];
                    }
                    else if (currBit == 0)
                    {
                        printRows[row] += printZero[row];
                    }

                    // Add empty
                    printRows[row] += Space;
                }
            }

            for (int row = 0; row < stringRows; row++)
            {
                //remove extra empty spaces in the end
                printRows[row] = printRows[row].Remove(printRows[row].Length - 1, 1);

                //print
                Console.WriteLine(printRows[row]);
            }
        }
    }
}
