using System;

namespace _07_Largest_Area_In_Matrix
{
    class LargestAreaInMatrix
    {
        public class MatrixElement
        {
            public string Value = "0";

            public bool isChecked = false;
        }

        static void Main()
        {
            // TODO: FIND A WAY TO TRACK CHECKS

            // input size Col and Row on a single input line
            var sizeInput = Console.ReadLine();

            string[] Sizes = sizeInput.Split(' ');

            int inputRows = int.Parse(Sizes[0]);
            int inputCols = int.Parse(Sizes[1]);

            // N Sizes[0] Lines with M Sizes[1] Strings 
            // Break each row into separate elements
            MatrixElement[,] toSearch =
                new MatrixElement[inputRows, inputCols];

            for (int row = 0; row < inputRows; row++)
            {
                string[] inputString = Console.ReadLine().Split(' ');

                for (int col = 0; col < inputCols; col++)
                {
                    toSearch[row, col] = new MatrixElement();

                    toSearch[row, col].Value = inputString[col];
                }
            }

            int curLength = 0;
            int MaxLength = int.MinValue;

            // Check Each unchecked element
            for (int row = 0; row < inputRows; row++)
            {
                for (int col = 0; col < inputCols; col++)
                {
                    // reset 
                    curLength = 1;

                    if (toSearch[row, col].isChecked == false)           //if the current element has 
                    {                                                    // not been checked already
                        curLength = Search(toSearch,
                            int.Parse(toSearch[row, col].Value), 
                            row, col, curLength);// Check the element
                    }

                    if (curLength > MaxLength)
                    {
                        MaxLength = curLength;
                    }
                }
            }
        }

        public static int Search(MatrixElement[,] toSearch,
                      int curElelment,
                      int Row, 
                      int Col, 
                      int curLength)
        {
            // Check Down
            if (Row + 1 < toSearch.GetLength(0))    // if in range of array
            {
                if (toSearch[Row + 1, Col].Value == curElelment.ToString()              // If current Element 
                    && toSearch[Row + 1, Col].isChecked == false)                       // is equal to the one before
                {                                                                       // has not been checked before        
                    curLength++;
                    toSearch[Row + 1, Col].isChecked = true;
                    curLength = Search(toSearch, curElelment, Row + 1, Col, curLength);
                }
            }
            
            // Check Right
            if (Col + 1 < toSearch.GetLength(1))    // if in range of array
            {
                if (toSearch[Row, Col + 1].Value == curElelment.ToString()
                    && toSearch[Row, Col + 1].isChecked == false)
                {
                    curLength++;
                    toSearch[Row, Col + 1].isChecked = true;
                    curLength = Search(toSearch, curElelment, Row, Col + 1, curLength);
                }
            }

            // Check Up
            if (Row - 1 >= 0)    // if in range of array
            {
                if (toSearch[Row - 1, Col].Value == curElelment.ToString()
                    && toSearch[Row - 1, Col].isChecked == false)
                {
                    curLength++;
                    toSearch[Row - 1, Col].isChecked = true;
                    curLength = Search(toSearch, curElelment, Row - 1, Col, curLength);
                }
            }

            // Check Left
            if (Col - 1 > 0)    // if in range of array
            {
                if (toSearch[Row, Col - 1].Value == curElelment.ToString()
                    && toSearch[Row, Col - 1].isChecked == false)
                {
                    curLength++;
                    toSearch[Row, Col - 1].isChecked = true;
                    curLength = Search(toSearch, curElelment, Row, Col - 1, curLength);
                }
            }

            return curLength;
        }
    }
}
