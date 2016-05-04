using System;

namespace _18_Remove_Element_Yet_Again
{
    class _18_Remove_Elements_Correct
    {
        static void Main()
        {
            //http://www.algorithmist.com/index.php/Longest_Increasing_Subsequence
            // correct alogrithm

            // input 
            int arraySize = int.Parse(Console.ReadLine());

            var toSearch = new int[arraySize];

            for (int i = 0; i < arraySize; i++)
            {
                toSearch[i] = (int.Parse(Console.ReadLine()));
            }

            // helper array storing 
            // sequence length for each element
            var helperArray = new int[arraySize];

            // variables
            int MaxSeqLength = 0;

            // for each end point                                                
            for (int EndPoint = 0;                 // Access each sub sequence 
                     EndPoint < toSearch.Length;   // in the array
                     EndPoint++)                   // Set an End point 0 to Length
            {                                      //                     
                MaxSeqLength = 0;                  //                     
                                                   //                     
                // for each start point            //                     
                for (int StartPoint = 0;           // then set a Start Point 0
                         StartPoint < EndPoint;    // to End Point 
                         StartPoint++)             // Read StartPoint to EndPoint
                {                                                    // If current Start Point element
                    if (toSearch[EndPoint] >=                        // is smaller than the at End Point
                        toSearch[StartPoint])                        // they are members of the same sequence
                    {                                                
                        if (helperArray[StartPoint] > MaxSeqLength)  // if the length for the element before is 
                        {                                            // larger than the current MaxSequenceLength
                            MaxSeqLength = helperArray[StartPoint];  // Max equals the length for the current 
                        }                                            // element
                    }                                                // The Element at End Point Belogs to that
                }                                                    // sequence

                // Longest existing sequence
                // the current EndPoint element belogs to
                // plus the current element
                // sequence of at least 1 elements
                helperArray[EndPoint] = MaxSeqLength + 1;
            }

            // part 2:      
            MaxSeqLength = 0;

            for (int i = 0; i < arraySize; i++)       // Find the Max
            {                                         // Length stored
                if (helperArray[i]> MaxSeqLength)     // in the helper
                {                                     // array
                    MaxSeqLength = helperArray[i];    //
                }                                     //
            }                                         //

            Console.WriteLine(arraySize-MaxSeqLength);
        }
    }
}
