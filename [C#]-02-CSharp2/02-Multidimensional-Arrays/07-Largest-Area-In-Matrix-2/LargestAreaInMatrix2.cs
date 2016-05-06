using System;
using System.Linq;
using System.Collections;

namespace _07_Largest_Area_In_Matrix_2
{
    class LargestAreaInMatrix2
    {
        // Declare Flags BitArray to 
        // be accessible in all methods
        static BitArray[] isChecked;

        static void Main()
        {
            // With Diagonals 
            // Wihtout Diagonals - > 100/ 100

            // INPUT N Rows, M Columns
            // Sizes[0] Rows, Sizes[1] Cols
            short[] Sizes = Console.ReadLine()
                                   .Trim(' ')
                                   .Split(' ')
                                   .Select(short.Parse)
                                   .ToArray();

            // Read The Array
            int[][] toSearch = new int[Sizes[0]][];

            //Initialize the bitarray for each row
            isChecked = new BitArray[toSearch.Length];

            for (int Row = 0; Row < toSearch.Length; Row++)
            {
                // Read Input row
                toSearch[Row] = Console.ReadLine()
                                       .Trim(' ')
                                       .Split(' ')
                                       .Select(int.Parse)
                                       .ToArray();

                // Create Flags for each element 
                // of the current input row
                isChecked[Row] = new BitArray(toSearch[Row].Length);
            }

            // Output
            var MaxSequence = int.MinValue;

            // Check for each element 
            // not checked before
            for (int Row = 0;
                     Row < toSearch.Length;
                     Row++)
            {
                for (int Col = 0;
                         Col < toSearch[Row].Length;
                         Col++)
                {
                    int curSequence = 1;

                    if (isChecked[Row][Col] == false)
                    {
                        isChecked[Row][Col] = true; 

                        // find sequence for current element
                        curSequence = CheckElement
                                      (
                                        Row,
                                        Col,
                                        curSequence,
                                        toSearch
                                      );
                    }

                    // Is the current sequence larger ? 
                    MaxSequence = curSequence > MaxSequence ?
                                  curSequence : MaxSequence;
                }
            }

            // Print Output
            Console.WriteLine(MaxSequence);
        }

        // Get Sequence - Up, Down, Left, Right
        public static int CheckElement
                          (
                            int Row,
                            int Col,
                            int curSequence,
                            int[][] toSearch
                          )
        {
            // Check Down
            if (Row + 1 < toSearch.Length)
            {
                if (toSearch[Row + 1][Col] ==
                    toSearch[Row][Col] &&
                    isChecked[Row + 1][Col] == false)
                {
                    curSequence++;

                    isChecked[Row + 1][Col] = true;

                    curSequence = CheckElement
                                  (
                                      Row + 1,
                                      Col,
                                      curSequence,
                                      toSearch
                                  );
                }
            }

            // Check Right
            if (Col + 1 < toSearch[Row].Length)
            {
                if (toSearch[Row][Col + 1] ==
                    toSearch[Row][Col] &&
                    isChecked[Row][Col + 1] == false)
                {
                    curSequence++;

                    isChecked[Row][Col + 1] = true;

                    curSequence = CheckElement
                                  (
                                      Row,
                                      Col + 1,
                                      curSequence,
                                      toSearch
                                  );
                }
            }

            // Check Up
            if (Row - 1 >= 0)
            {
                if (toSearch[Row - 1][Col] ==
                    toSearch[Row][Col] &&
                    isChecked[Row - 1][Col] == false)
                {
                    curSequence++;

                    isChecked[Row - 1][Col] = true;

                    curSequence = CheckElement
                                  (
                                      Row - 1,
                                      Col,
                                      curSequence,
                                      toSearch
                                  );
                }                 
            }

            // Check Left
            if (Col - 1 >= 0)
            {
                if (toSearch[Row][Col - 1] ==
                    toSearch[Row][Col] &&
                    isChecked[Row][Col - 1] == false)
                {
                    curSequence++;

                    isChecked[Row][Col - 1] = true;

                    curSequence = CheckElement
                                  (
                                      Row,
                                      Col - 1,
                                      curSequence,
                                      toSearch
                                  );
                }
            }

            // Return crrent 
            // sequence length
            return curSequence;
        }
    }
}
