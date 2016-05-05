using System;

namespace _11_Binary_Search
{
    class BinarySearch
    {
        static void Main()
        {
            //  80/ 100 TIME LIMIT TESTS: 2, 7
            // 100/ 100 See Bottom 

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

            // Step 1.5: Sort array ascending ( not needed )
            // Array.Sort(arrayA);

            // Step 2:
            while (true)
            {
                if (arrayA[currCheck] < toFind)
                {
                    // value toFind is to the RIGHT of MID
                    // Move the search position RIGHT
                    // Right = currCheck - 1; // -> per Wikipedia, but SLOW

                    currCheck++;
                    continue;
                }

                if (toFind < arrayA[currCheck])
                {
                    // value toFind is to the LEFT of MID
                    // Move the search position LEFT
                    // Left = currCheck + 1; // -> per Wikipedia, but SLOW

                    currCheck--;
                    continue;
                }
                
                try
                {
                    //Step 3: Check Numer at current Position
                    if (arrayA[currCheck] == toFind)
                    {
                        //successful match
                        // print the current position
                        Console.WriteLine(currCheck);
                        return;
                    }
                }
                catch (System.IndexOutOfRangeException)   // Trying to check outside 
                {                                         // of the array
                    Console.WriteLine("-1");              // element is not found
                    return;                               // print -1
                }

                // currCheck = (Left + Right) / 2; // -> per Wikipedia, but SLOW
            }


            // 100 POINTS -> built in binary search
            //int result = Array.BinarySearch(arrayA, toFind);

            //if (result<0)
            //{
            //    Console.WriteLine("-1");
            //}
            //else
            //{
            //    Console.WriteLine(result);
            //}
        }
    }
}
