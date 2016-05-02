using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06_Matrix_Class
{
    public class Matrix
    {
        private int[,] values;

        public Matrix(int Size)
        {
            int sizeRow = (int)Math.Sqrt(Size);
            int sizeCol = Size / sizeRow;

            this.values = new int[sizeRow, sizeCol];
        }

        public Matrix(int sizeRow, int sizeCol)
        {
            this.values = new int[sizeRow, sizeCol];
        }

        // GetLength
        public int GetLength(int Index)
        {
            return this.values.GetLength(Index);
        }

        // standard indexer
        // TODO: 
        // Return by Row
        // Return by Col
        // Access Row, Col
        public int this[int Row, int Col]
        {
            get
            {
                return values[Row, Col];
            }
            set
            {
                values[Row, Col] = value;
            }
        }

        // Overload Add
        public static Matrix operator +(Matrix One, Matrix Two)
        {
            Matrix Result = new Matrix(                 // New Matrix
                Math.Min(                               // Rows 
                     One.GetLength(0),                  // Equal to the 
                     Two.GetLength(0)),                 // Smaller of the two
                Math.Min(                               // Columns 
                     One.GetLength(1),                  // equal to the 
                     Two.GetLength(1)));                // smaller of the two

            for (int row = 0; row < Math.Min(           // for each row
                     One.GetLength(0),                  // up to the row count
                     Two.GetLength(0)); row++)          // of the smaller matrix
            {
                for (int col = 0; col < Math.Min(       // for each col
                     One.GetLength(1),                  // up to the col count
                     Two.GetLength(1)); col++)          // of the smaller matrix
                {
                    Result[row, col] = One[row, col] + Two[row, col];
                }
            }

            return Result;
        }

        // Overload Subtract
        public static Matrix operator -(Matrix One, Matrix Two)
        {
            Matrix Result = new Matrix(                 // New Matrix
                Math.Min(                               // Rows 
                     One.GetLength(0),                  // Equal to the 
                     Two.GetLength(0)),                 // Smaller of the two
                Math.Min(                               // Columns 
                     One.GetLength(1),                  // equal to the 
                     Two.GetLength(1)));                // smaller of the two

            for (int row = 0; row < Math.Min(           // for each row
                     One.GetLength(0),                  // up to the row count
                     Two.GetLength(0)); row++)          // of the smaller matrix
            {
                for (int col = 0; col < Math.Min(       // for each col
                     One.GetLength(1),                  // up to the col count
                     Two.GetLength(1)); col++)          // of the smaller matrix
                {
                    Result[row, col] = One[row, col] - Two[row, col];
                }
            }

            return Result;
        }

        // Overload Multiply
        public static Matrix operator *(Matrix One, Matrix Two)
        {
            Matrix Result = new Matrix(                 // New Matrix
                Math.Min(                               // Rows 
                     One.GetLength(0),                  // Equal to the 
                     Two.GetLength(0)),                 // Smaller of the two
                Math.Min(                               // Columns 
                     One.GetLength(1),                  // equal to the 
                     Two.GetLength(1)));                // smaller of the two

            for (int row = 0; row < Math.Min(           // for each row
                     One.GetLength(0),                  // up to the row count
                     Two.GetLength(0)); row++)          // of the smaller matrix
            {
                for (int col = 0; col < Math.Min(       // for each col
                     One.GetLength(1),                  // up to the col count
                     Two.GetLength(1)); col++)          // of the smaller matrix
                {
                    Result[row, col] = One[row, col] * Two[row, col];
                }
            }

            return Result;
        }

        // Overload Divide
        public static Matrix operator /(Matrix One, Matrix Two)
        {
            Matrix Result = new Matrix(                 // New Matrix
                Math.Min(                               // Rows 
                     One.GetLength(0),                  // Equal to the 
                     Two.GetLength(0)),                 // Smaller of the two
                Math.Min(                               // Columns 
                     One.GetLength(1),                  // equal to the 
                     Two.GetLength(1)));                // smaller of the two

            for (int row = 0; row < Math.Min(           // for each row
                     One.GetLength(0),                  // up to the row count
                     Two.GetLength(0)); row++)          // of the smaller matrix
            {
                for (int col = 0; col < Math.Min(       // for each col
                     One.GetLength(1),                  // up to the col count
                     Two.GetLength(1)); col++)          // of the smaller matrix
                {
                    Result[row, col] = One[row, col] / Two[row, col];
                }
            }

            return Result;
        }

        // Overload Mod
        public static Matrix operator %(Matrix One, Matrix Two)
        {
            Matrix Result = new Matrix(                 // New Matrix
                Math.Min(                               // Rows 
                     One.GetLength(0),                  // Equal to the 
                     Two.GetLength(0)),                 // Smaller of the two
                Math.Min(                               // Columns 
                     One.GetLength(1),                  // equal to the 
                     Two.GetLength(1)));                // smaller of the two

            for (int row = 0; row < Math.Min(           // for each row
                     One.GetLength(0),                  // up to the row count
                     Two.GetLength(0)); row++)          // of the smaller matrix
            {
                for (int col = 0; col < Math.Min(       // for each col
                     One.GetLength(1),                  // up to the col count
                     Two.GetLength(1)); col++)          // of the smaller matrix
                {
                    Result[row, col] = One[row, col] % Two[row, col];
                }
            }

            return Result;
        }

        // Fill with: Random
        public void FillWithRandom(int Min, int Max)
        {
            Random randomizer = new Random();

            for (int row = 0; row < this.GetLength(0); row++)
            {
                for (int col = 0; col < this.GetLength(1); col++)
                {
                    this[row, col] = randomizer.Next(Min, Max);
                }
            }
        }

        // Fill with: Sequence
        public void FillWithSequence(int Start)
        {
            int toFillWith = Start;

            for (int row = 0; row < this.GetLength(0); row++)
            {
                for (int col = 0; col < this.GetLength(1); col++)
                {
                    this[row, col] = toFillWith;
                    toFillWith += Start;
                }
            }
        }

        // Fill with: Int
        public void FillWith(int toFillWith)
        {
            for (int row = 0; row < this.GetLength(0); row++)
            {
                for (int col = 0; col < this.GetLength(1); col++)
                {
                    this[col, row] = toFillWith;
                }
            }
        }
    }
}
