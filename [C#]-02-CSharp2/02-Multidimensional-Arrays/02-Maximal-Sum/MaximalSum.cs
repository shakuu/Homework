using System;
using System.Linq;

namespace _02_Maximal_Sum
{
    class MaximalSum
    {
        static void Main()
        {
            // RUNTIME ERROR

            // IMPORTANT : POSSIBLY ROWS then COLUMNS ( TODO: Switch The Input Around )
            // input size Col and Row on a single input line 
            string sizeInput = Console.ReadLine().TrimEnd(' ');

            string[] Sizes = sizeInput.Split(' ');

            short[][] toSearch = new short
                [int.Parse(Sizes[0])][];

            // Read Array input
            // read sums of each 3 elements out of each row 
            for (int row = 0; row < toSearch.GetLength(0); row++)
            {
                toSearch[row] = Console.ReadLine()
                                         .Trim(' ')
                                         .Split(' ')
                                         .Select(num => short.Parse(num))
                                         .ToArray(); 
            }

            // Container Grid
            int SearchSize = 3;
            
            short curMaxSum = short.MinValue;   // This will store the result  
            short curSum = 0;                 // store current grid sum                     

            // Read each possible Grid 
            for (int row = 0;                                           // Each Row
                     row < toSearch.GetLength(0) 
                           - (SearchSize - 1);                          // Up to Size -2
                     row++)                                             // to accomodate GridSize
            {
                for (int col = 0;                                    // Each Col
                         col < toSearch[0].GetLength(0)              // Up to Size -2
                               - (SearchSize - 1);                     
                         col++)
                {
                    curSum = 0;                                      // reset the sum  
                                                                     // Read a 3x3 Grid 
                    for (int curRow = row;                           // Start at current Position
                             curRow < row + SearchSize;              // Up to Grid Size
                             curRow++)
                    {
                        for (int curCol = col;                      
                                 curCol < col + SearchSize;       
                                 curCol++)                           
                        {
                            // get the Sum
                            curSum += toSearch[curRow][curCol];
                        }
                    }

                    // Compare its sum to MAX SUM
                    if (curSum > curMaxSum)
                    {
                        curMaxSum = curSum;
                    }
                }
            }

            // Print Result
            Console.WriteLine(curMaxSum);
        }
    }
}
