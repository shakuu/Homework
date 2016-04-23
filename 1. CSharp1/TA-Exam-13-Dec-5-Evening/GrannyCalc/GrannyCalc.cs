using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrannyCalc
{
    class GrannyCalc
    {
        static void Main()
        {
            // by definition
            const int definitionRows = 8;

            // input
            // width to work with Right to Left 
            int Width = int.Parse(Console.ReadLine());

            // 8 32bit numbs to fill it
            int[] Calc = new int[definitionRows];

            //fill the Calculator
            for (int row = 0; row < definitionRows; row++)
            {
                Calc[row] = int.Parse(Console.ReadLine());
            }

            // variables
            bool isRunning = true;

            string GrannySays = "";
            int GrannySaysRow = 0;
            int GrannySaysCol = 0;

            // Commands - reset ( to left ), left, right, stop
            while (isRunning)
            {
                // Step 1: Listen to Granny
                GrannySays = Console.ReadLine();

                // stop = stop reading and print output
                if (GrannySays == "stop")
                {
                    // TODO: Other stuff TBD
                    isRunning = false; // just in case
                    break;
                }

                if (GrannySays == "reset")
                {
                    // All 1s go LEFT
                    for (int row = 0; row < definitionRows; row++)
                    {
                        int Counter = 0;
                        int curBit = 0;

                        // Step 1: Count 1s on this Row and set them to 0s
                        for (int col = 0; col < Width; col++)
                        {
                            // Step 1: get bit value
                            curBit = (Calc[row] & (1 << col)) >> col;

                            // Step 2: Check and Reset
                            if (curBit == 1)
                            {
                                // increment counter
                                Counter++;

                                // reset to 0
                                Calc[row] = Calc[row] ^ (1 << col);
                            }
                        }

                        //Step 2: Insert 1s on the first Count positions
                        // Left to Right
                        for (int left = 0; left < Counter; left++)
                        {
                            // add 1s left to right
                            Calc[row] = Calc[row] | (1 << Width - 1 - left);
                        }
                    }
                }

                if (GrannySays == "left")
                {
                    // Step 1: Read two more numbers : row and col
                    GrannySaysRow = int.Parse(Console.ReadLine());
                    GrannySaysCol = int.Parse(Console.ReadLine());

                    // input range -50 - 50
                    if (GrannySaysCol > Width)
                    {
                        GrannySaysCol = Width;
                    }

                    if (GrannySaysCol < 0)
                    {
                        GrannySaysCol = 0;
                    }

                    // Move 1s left starting at a set position
                    // Same as reset
                    // Read 1 Row Only - Granny Says
                    int Counter = 0;
                    int curBit = 0;

                    // Step 1: Count 1s on this Row and set them to 0s
                    // Count Positions from Width ( LEFT ) to GrannySays ( RIght )
                    for (int col = Width - 1 - GrannySaysCol; col < Width; col++)
                    {
                        // Step 1: get bit value RIGHT to LEFT starting at GrannySaysCol
                        curBit = (Calc[GrannySaysRow] & (1 << col)) >> col;

                        // Step 2: Check and Reset
                        if (curBit == 1)
                        {
                            // increment counter
                            Counter++;

                            // reset to 0
                            Calc[GrannySaysRow] = Calc[GrannySaysRow] ^ (1 << col);
                        }
                    }

                    //Step 2: Insert 1s on the first Count positions
                    // Left to Right
                    for (int left = 0; left < Counter; left++)
                    {
                        // add 1s left to right
                        Calc[GrannySaysRow] = Calc[GrannySaysRow] | (1 << Width - 1 - left);
                    }
                }

                if (GrannySays == "right")
                {
                    //Step 1: Read two more numbers : row and col
                    GrannySaysRow = int.Parse(Console.ReadLine());
                    GrannySaysCol = int.Parse(Console.ReadLine());

                    // input range -50 - 50
                    if (GrannySaysCol > Width)
                    {
                        GrannySaysCol = Width;
                    }

                    if (GrannySaysCol < 0)
                    {
                        GrannySaysCol = 0;
                    }

                    // Move 1s Right Starting at GrannSaysCol Position
                    // Read 1 Row Only - Granny Says
                    int Counter = 0;
                    int curBit = 0;

                    // Step 1: Count 1s on this Row and set them to 0s
                    // Count Positions from Width ( LEFT ) to GrannySays ( RIght )
                    for (int col = 0; col < GrannySaysCol; col++)
                    {
                        // Step 1: get bit value RIGHT to LEFT starting at GrannySaysCol
                        curBit = (Calc[GrannySaysRow] & (1 << col)) >> col;

                        // Step 2: Check and Reset
                        if (curBit == 1)
                        {
                            // increment counter
                            Counter++;

                            // reset to 0
                            Calc[GrannySaysRow] = Calc[GrannySaysRow] ^ (1 << col);
                        }
                    }

                    //Step 2: Insert 1s on the first Count positions
                    // RIGHT to LEFT
                    for (int left = 0; left < Counter; left++)
                    {
                        // add 1s left to right
                        Calc[GrannySaysRow] = Calc[GrannySaysRow] | (1 << left);
                    }
                }
            }

            //Get Result : Sum of Calc multiplied by number of cols WITHOUT 1s
            int ZeroColCount = 0; // columns without 1s
            bool isZeroCol = true;

            for (int col = 0; col < Width; col++)
            {
                //reset bool
                isZeroCol = true;
                
                for (int row = 0; row < definitionRows; row++)
                {
                    // Step 1: Get Bit on Position Col in Row - LEFT to RIGHT
                    int curBit = (Calc[row] & (1 << col)) >> col;

                    // Step 2: Check
                    if (curBit==1)
                    {
                        isZeroCol = false;
                        break;
                    }
                }

                // Step 3: Increment the Counter
                if (isZeroCol)
                {
                    ZeroColCount++;
                }
            }

            //Calculate
            int toPrint = (Calc.Sum() )* ZeroColCount;
            
            //Print
            Console.WriteLine(toPrint);
        }
    }
}
