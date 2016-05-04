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

            // Step 1.5: Sort array ascending ( possibly not needed )
            //Array.Sort(arrayA);

            // Step 2:
            while (true)
            {
                
                //// Stop on end of array
                //if ((currCheck == Left || currCheck == Right) && arrayA[currCheck] != toFind)
                //{
                //    //Print not found
                //    Console.WriteLine("-1");
                //    return;
                //}

                if (arrayA[currCheck] < toFind)
                {
                    //value toFind is to the RIGHT of MID
                    // Move the search position RIGHT
                     //Right = currCheck - 1;

                    currCheck++;
                    continue;
                }

                if (toFind < arrayA[currCheck])
                {
                    //value toFind is to the LEFT of MID
                    // Move the search position LEFT
                    //Left = currCheck + 1;

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
                catch (System.IndexOutOfRangeException)
                {
                    Console.WriteLine("-1");
                    return;
                }
                //currCheck = (Left + Right) / 2;
            }


            // 100 POINTS
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
