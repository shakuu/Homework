using System;

namespace _07_Largest_Area_In_Matrix
{
    class LargestAreaInMatrix
    {
        
        public class MatrixElement          // a helper class 
        {                                   // storing both
            public string Value = "0";      // the value of the
                                            // element
            public bool isChecked = false;  // and whether it's 
        }                                   // already been checked

        static void Main()                  // Depth First Search
        {
            // TODO: Better Way to Read input

            // input size Col and Row on a single input line
            string[] Sizes = Console.ReadLine().Split(' ');

            int inputRows = int.Parse(Sizes[0]);
            int inputCols = int.Parse(Sizes[1]);

            // N Sizes[0] Lines with M Sizes[1] Strings 
            // Break each row into separate elements
            MatrixElement[,] toSearch =                    // Array of Matrix Elements 
                new MatrixElement[inputRows, inputCols];   // 

            for (int row = 0; row < inputRows; row++)                   // For each row
            {                                                           // Break the input string
                string[] inputString = Console.ReadLine().Split(' ');   // into a helper array
                                                                        //
                for (int col = 0; col < inputCols; col++)               //
                {                                                       //
                    toSearch[row, col] = new MatrixElement();           // create a new Matrix() element
                                                                        //
                    toSearch[row, col].Value = inputString[col];        // assign it's value
                }
            }
            
            // Helper Variables
            int curLength = 0;
            int MaxLength = int.MinValue;

            // Check Each unchecked element
            for (int row = 0; row < inputRows; row++)
            {
                for (int col = 0; col < inputCols; col++)
                {
                    // reset current sequence length before checking different numbers
                    curLength = 1;

                    if (toSearch[row, col].isChecked == false)          // if the current element has 
                    {                                                   // not been checked already
                        curLength = Search(toSearch,                    // check the elements around
                            int.Parse(toSearch[row, col].Value),        // and go deeper in to the    
                            row, col, curLength);                       // into the sequence
                    }                                                   // before switching side
                                                                        //
                    if (curLength > MaxLength)                          // Check whether
                    {                                                   // current sequence is larger
                        MaxLength = curLength;                          // than the highest previous one
                    }
                }
            }

            // print Output
            Console.WriteLine(MaxLength);

        }

        public static int Search(MatrixElement[,] toSearch,     // Start with a unique element in the array
                      int curElelment,                          // Recursively go deeper into tree
                      int Row,                                  // Explore different branches on the way up
                      int Col,                                  // South -> East -> North -> West
                      int curLength)                            // Tag elements part of the current sequence
        {                                                       // Keep track of sequence length
            // Check Down
            if (Row + 1 < toSearch.GetLength(0))    // if in range of array
            {
                if (toSearch[Row + 1, Col].Value == curElelment.ToString()              // If current Element 
                    && toSearch[Row + 1, Col].isChecked == false)                       // is equal to the one before
                {                                                                       // AND has not been checked before        
                    curLength++;                                                        // increment length 
                    toSearch[Row + 1, Col].isChecked = true;                            // tag as checked
                    curLength = Search(toSearch, curElelment, Row + 1, Col, curLength); // recursively check 
                }                                                                       // the area around 
            }

            // Check Right
            if (Col + 1 < toSearch.GetLength(1))    // if in range of array
            {
                if (toSearch[Row, Col + 1].Value == curElelment.ToString()               // If current Element 
                    && toSearch[Row, Col + 1].isChecked == false)                        // is equal to the one before
                {                                                                        // AND has not been checked before 
                    curLength++;                                                         // increment length 
                    toSearch[Row, Col + 1].isChecked = true;                             // tag as checked
                    curLength = Search(toSearch, curElelment, Row, Col + 1, curLength);  // recursively check 
                }                                                                        // the area around 
            }

            // Check Up
            if (Row - 1 >= 0)                       // if in range of array
            {                                                                            // If current Element 
                if (toSearch[Row - 1, Col].Value == curElelment.ToString()               // is equal to the one before
                    && toSearch[Row - 1, Col].isChecked == false)                        // AND has not been checked before 
                {
                    curLength++;                                                         // increment length 
                    toSearch[Row - 1, Col].isChecked = true;                             // tag as checked
                    curLength = Search(toSearch, curElelment, Row - 1, Col, curLength);  // recursively check 
                }                                                                        // the area around 
            }

            // Check Left
            if (Col - 1 > 0)                        // if in range of array
            {                                                                            // If current Element 
                if (toSearch[Row, Col - 1].Value == curElelment.ToString()               // is equal to the one before
                    && toSearch[Row, Col - 1].isChecked == false)                        // AND has not been checked before 
                {
                    curLength++;                                                         // increment length 
                    toSearch[Row, Col - 1].isChecked = true;                             // tag as checked
                    curLength = Search(toSearch, curElelment, Row, Col - 1, curLength);  // recursively check 
                }                                                                        // the area around 
            }

            // Return the accumulated sequence length
            // 
            return curLength;
        }
    }
}
