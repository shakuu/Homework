using System;

namespace _03_Sequence_In_Matrix
{
    class SequenceInMatrix
    {
        static void Main()
        {
            // 100 / 100, TODO: MISSING CHECK FOR Diagonals - Left-  BOTTOM RIGTH section

            // input size Col and Row on a single input line
            string sizeInput = Console.ReadLine();

            string[] Sizes = sizeInput
                            .Trim(' ')
                            .Split(' ');

            int inputRows = int.Parse(Sizes[0]);
            int inputCols = int.Parse(Sizes[1]);

            // N Sizes[0] Lines with M Sizes[1] Strings 
            // Break each row into separate elements
            string[][] toSearch = new string[inputRows][];

            for (int i = 0; i < inputRows; i++)
            {
                toSearch[i] = Console.ReadLine()
                                     .Trim(' ')
                                     .Split(' ');
            }

            // vars
            int MaxSequence = 0;
            int CurSequence = 1;

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
            for (int col = 0; col < inputCols; col++)
            {
                // reset for each col
                CurSequence = 1;

                for (int row = 1; row < inputRows; row++)
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

            // Check Diagonals
            // Diagonal Left 
            // TODO: Optimizie only check diagonals with enough
            // elements to get a new Max Length
            for (int Col = 1; Col < inputCols; Col++)
            {
                CurSequence = 1;

                for (int curMod = 1;
                         curMod <= Math.Min(Col, inputRows - 1);
                         curMod++)
                {
                    if (toSearch[0 + curMod][Col - curMod] ==
                        toSearch[0 + (curMod - 1)][Col - (curMod - 1)])
                    {
                        CurSequence++;
                    }
                }

                if (CurSequence > MaxSequence)
                {
                    MaxSequence = CurSequence;
                }
            }

            for (int Row = 1; Row < inputRows; Row++)
            {
                CurSequence = 1;

                for (int curMod = 1;
                         curMod <= Math.Min(inputRows - 1 - Row - 1, inputCols - 1);
                         curMod++)
                {
                    if (toSearch[Row + curMod][(inputCols - 1) - curMod] ==
                        toSearch[Row + (curMod + 1)][(inputCols - 1) - (curMod + 1)])
                    {
                        CurSequence++;
                    }
                }

                if (CurSequence > MaxSequence)
                {
                    MaxSequence = CurSequence;
                }
            }

            // Diagonal Right
            for (int Row = inputRows - 2;
                     Row >= 0;
                     Row--)
            {
                CurSequence = 1;

                for (int curMod = 1;
                    curMod <= Math.Min(inputRows - Row - 1, inputCols - 1);
                    curMod++)
                {
                    if (toSearch[Row + curMod][0 + curMod] ==
                        toSearch[Row + (curMod - 1)][0 + (curMod - 1)])
                    {
                        CurSequence++;
                    }
                }

                if (CurSequence > MaxSequence)
                {
                    MaxSequence = CurSequence;
                }
            }

            // Top Right
            for (int Row = 1;
                     Row < inputRows - 1;
                     Row++)
            {
                CurSequence = 1;

                for (int curMod = 1;
                    curMod <= Math.Min(Row - 1, inputCols - 1);
                    curMod++)
                {
                    if (toSearch[Row - curMod][(inputCols - 1) - curMod] ==
                        toSearch[Row - (curMod - 1)][(inputCols - 1) - (curMod - 1)])
                    {
                        CurSequence++;
                    }
                }

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
