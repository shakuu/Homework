using System;

namespace _03_Sequence_In_Matrix
{
    class SequenceInMatrix
    {
        static void Main()
        {
            // input size Col and Row on a single input line
            var sizeInput = Console.ReadLine();

            string[] Sizes = sizeInput.Split(' ');

            int inputRows = int.Parse(Sizes[0]);
            int inputCols = int.Parse(Sizes[1]);

            // N Sizes[0] Lines with M Sizes[1] Strings 
            // Break each row into separate elements
            string[][] toSearch = new string[inputRows][];

            for (int i = 0; i < inputRows; i++)
            {
                toSearch[i] = Console.ReadLine().Split(' ');
            }

            // vars
            int MaxSequence = 0;
            int CurSequence = 0;

            // Step 1: Check By Rows
            for (int row = 0; row < inputRows; row++)
            {
                // reset for each row
                CurSequence = 1;

                for (int col = 1; col < inputCols; col++)
                {
                    if (toSearch[row][col] ==
                        toSearch[row][col - 1])
                    {
                        CurSequence++;
                    }
                    else
                    {
                        // check if cursequence is longest
                        if (CurSequence > MaxSequence)
                        {
                            MaxSequence = CurSequence;
                        }
                        //reset curseq
                        CurSequence = 1;
                    }
                }

                // double check for last element on row
                if (CurSequence > MaxSequence)
                {
                    MaxSequence = CurSequence;
                }
            }

            // Step 2: Check By Cols
            for (int col = 0; col < inputRows; col++)
            {
                // reset for each col
                CurSequence = 1;

                for (int row = 1; row < inputCols; row++)
                {
                    if (toSearch[row][col] ==
                        toSearch[row - 1][col])
                    {
                        CurSequence++;
                    }
                    else
                    {
                        // check if cursequence is longest
                        if (CurSequence > MaxSequence)
                        {
                            MaxSequence = CurSequence;
                        }
                        //reset curseq
                        CurSequence = 1;
                    }
                }

                // double check cursequence for last element
                if (CurSequence > MaxSequence)
                {
                    MaxSequence = CurSequence;
                }
            }

            // print output
            Console.WriteLine(MaxSequence);
        }
    }
}
