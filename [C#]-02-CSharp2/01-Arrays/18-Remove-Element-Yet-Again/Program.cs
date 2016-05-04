using System;

namespace _18_Remove_Element_Yet_Again
{
    class Program
    {
        static void Main()
        {
            //http://www.algorithmist.com/index.php/Longest_Increasing_Subsequence

            // input 
            int arraySize = int.Parse(Console.ReadLine());

            var toSearch = new int[arraySize];

            for (int i = 0; i < arraySize; i++)
            {
                toSearch[i] = (int.Parse(Console.ReadLine()));
            }

            // helper array
            var helperArray = new int[arraySize];

            // variables
            int Max = 0;

            // for each end point
            for (int EndPoint = 0; EndPoint < toSearch.Length; EndPoint++)
            {
                Max = 0;

                // for each start point
                for (int StartPoint = 0; StartPoint < EndPoint; StartPoint++)
                {
                    if (toSearch[EndPoint] >= toSearch[StartPoint])
                    {
                        if (helperArray[StartPoint] > Max)
                        {
                            Max = helperArray[StartPoint];
                        }
                    }
                }

                helperArray[EndPoint] = Max + 1;
            }

            // part 2:      
            Max = 0;

            for (int i = 0; i < arraySize; i++)
            {
                if (helperArray[i]> Max)
                {
                    Max = helperArray[i];
                }
            }

            Console.WriteLine(arraySize-Max);
        }
    }
}
