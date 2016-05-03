using System;

namespace _11_Binary_Search
{
    class BinarySearch
    {
        static void Main()
        {
            // TODO: TIME LIMIT, INCORRECT

            //input 
            int arraySize = int.Parse(Console.ReadLine());

            // get array
            int[] arrayA = new int[arraySize];

            for (int i = 0; i < arraySize; i++)
            {
                arrayA[i] = int.Parse(Console.ReadLine());
            }

            // get Number X to find
            int toFind = int.Parse(Console.ReadLine());

            // vars
            int Left = 0;
            int Right = arraySize - 1;
            int Middle = (Left + Right) / 2;

            int currCheck = Middle;

            // Step 1: Validate
            if (Left > Right)
            {
                return;
            }

            // Step 1.5: Sort array ascending ( possibly not needed )

            // Step 2:
            while (true)
            {
                // Step 3: Check Numer at current Position
                if (arrayA[currCheck] == toFind)
                {
                    // successful match
                    // print the current position
                    Console.WriteLine(currCheck);
                    return;
                }
                else if (toFind < arrayA[currCheck])
                {
                    // value toFind is to the LEFT of MID
                    // Move the search position LEFT
                    currCheck--;
                }
                else if (arrayA[currCheck] < toFind)
                {
                    // value toFind is to the RIGHT of MID
                    // Move the search position RIGHT
                    currCheck++;
                }

                // Stop on end of array
                if (currCheck == Left || currCheck == Right)
                {
                    //Print not found
                    Console.WriteLine("-1");
                    return;
                }
            }
        }
    }
}
