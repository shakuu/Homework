using System;
using System.Numerics;

namespace _02_Maximal_Sum
{
    class MaximalSum
    {
        static void Main()
        {
            // IMPORTANT : POSSIBLY ROWS then COLUMNS ( TODO: Switch The Input Around )
            // input size Col and Row on a single input line 
            var sizeInput = Console.ReadLine();

            string[] Sizes = sizeInput.Split(' ');

            int[,] toSearch = new int
                [int.Parse(Sizes[0]),
                 int.Parse(Sizes[1])];

            // Read Array input
            for (int row = 0; row < toSearch.GetLength(1); row++)
            {
                for (int col = 0; col < toSearch.GetLength(0); col++)
                {
                    toSearch[col, row] = int.Parse(Console.ReadLine());
                }
            }

            // Container Grid
            int SearchSize = 3;
            
            BigInteger curMaxSum = int.MinValue;   // This will store the result  
            BigInteger curSum = 0;                 // store current grid sum                     

            // Read each possible Grid 
            for (int row = 0;                                           // Each Row
                     row < toSearch.GetLength(1) - (SearchSize - 1);    // Up to Size -2
                     row++)                                             // to accomodate GridSize
            {
                for (int col = 0;                                         // Each Col
                         col < toSearch.GetLength(0) - (SearchSize - 1);  // Up to Size -2
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
                            curSum += toSearch[curCol, curRow];
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
