using System;

namespace ForulaBit_Bitwise
{
    class BitwiseFormulaBit
    {
        static void Main()
        {
            // given
            int bitRow = 0;      // First input Number
            int bitCol = 0;       //Bit 0 Right to Left ( col 7 in a string ) TODO: Adjust if easier 

            int GoalRow = 7;    // last input number
            int GoalCol = 7;    // last bit right to left 

            // counters
            int Steps = 1;
            int Turns = 0;
            int Direction = 0; // 0- south, 1- west, 2-north

            // check
            bool isRunning = true;
            bool isTrack = false;
            bool isDirectionChange = false;

            int toCheckRow = 0;
            int toCheckCol = 0;

            // input -> 8 integers
            int[] Track = new int[8];

            // read Track ints
            for (int row = 0; row < Track.Length; row++)
            {
                Track[row] = int.Parse(Console.ReadLine());
            }

            //just in case
            if (Track[0]%2 != 0)
            {
                Console.WriteLine("No " + 0);
            }

            // while the bit can move
            while (isRunning)
            {
                // Step 1: Which Bit to check next ? 
                if (Direction == 0)
                {
                    toCheckRow = bitRow + 1;
                    toCheckCol = bitCol;
                }
                else if (Direction == 1)
                {
                    toCheckRow = bitRow;
                    toCheckCol = bitCol + 1;
                }
                else if (Direction == 2)
                {
                    toCheckRow = bitRow - 1;
                    toCheckCol = bitCol;
                }

                //Step 2: Get the value of the BIT to check
                // 1 pushed left , AND number on the row, pushed right to bit pos 0
                // OutOfBounds Check -> catch exception -> bitvalue = 1
                int BitValue;

                try
                {
                    // integers have too many bits, throw exception if out of given range
                    if (toCheckCol>7)
                    {
                        throw new IndexOutOfRangeException();
                    }
                    // exception if index out track array rows 
                    BitValue = (Track[toCheckRow] & (1 << toCheckCol)) >> toCheckCol;
                }
                catch (System.IndexOutOfRangeException)
                {
                    // out of bounds -> BitValue 1 
                    BitValue = 1;
                }

                // Step 3: Check the Value of the Bit
                // 0 -> Move, 1-> Change direction, 2x direction change = game over.
                if (BitValue == 0)
                {
                    // adjust position
                    bitRow = toCheckRow;
                    bitCol = toCheckCol;

                    // increment the counter
                    Steps++;

                    // adjust bool
                    isDirectionChange = false;
                }

                if (BitValue == 1)
                {
                    // Step 0: Chekc Game Over : 2x Direction changes in a row = game over
                    if (isDirectionChange)
                    {
                        break;
                    }

                    // Step 1: Change Direction
                    if ((Turns / 2) % 2 == 0)
                    {
                        Direction++;
                    }
                    else
                    {
                        Direction--;
                    }

                    // Step 2: Increment the Counter
                    Turns++;

                    // Step 3: flip bool
                    isDirectionChange = true;
                }

                // check if goal has been reached
                if (bitRow == GoalRow && bitCol == GoalCol)
                {
                    // exit reached
                    isTrack = true;
                    break;
                }
            }

            //output
            if (isTrack)
            {
                //length of track, count of turns
                Console.WriteLine(Steps + " " + Turns);
            }
            else
            {
                Console.WriteLine("No {0}", Steps);
            }
        }
    }
}
