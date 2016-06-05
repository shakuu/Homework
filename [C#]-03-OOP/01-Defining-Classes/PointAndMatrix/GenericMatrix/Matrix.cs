
namespace PointAndMatrix.GenericMatrix
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    class Matrix<T>
    {
        private T[,] container;

        public Matrix(int x, int y)
        {
            this.container = new T[x, y];
        }

        #region Properties

        public int Rows
        {
            get
            {
                return this.container.GetLength(0);
            }
        }
        public int Cols
        {
            get
            {
                return this.container.GetLength(1);
            }
        }

        #endregion

        #region Indexer and Operators
        public T this[int row, int col]
        {
            get
            {
                return this.container[row, col];
            }
            set
            {
                this.container[row, col] = value;
            }
        }

        public static Matrix<T> operator +(Matrix<T> a, Matrix<T> b)
        {
            if (!(a.Rows == b.Rows && a.Cols == b.Cols))
            {
                throw new ArgumentException("Matrices are of different size, unable to perform operation");
            }

            var result = new Matrix<T>(a.Rows, b.Cols);

            for (int row = 0; row < a.Rows; row++)
            {
                for (int col = 0; col < b.Cols; col++)
                {
                    try
                    {
                        dynamic numA = a[row, col];
                        dynamic numB = b[row, col];

                        result[row, col] = numA + numB;
                    }
                    catch (Exception)
                    {

                        throw;
                    }
                }
            }
            return result;
        }
        public static Matrix<T> operator -(Matrix<T> a, Matrix<T> b)
        {
            if (!(a.Rows == b.Rows && a.Cols == b.Cols))
            {
                throw new ArgumentException("Matrices are of different size, unable to perform operation");
            }

            var result = new Matrix<T>(a.Rows, b.Cols);

            for (int row = 0; row < a.Rows; row++)
            {
                for (int col = 0; col < b.Cols; col++)
                {
                    try
                    {
                        dynamic numA = a[row, col];
                        dynamic numB = b[row, col];

                        result[row, col] = numA - numB;
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("exception");
                        throw;
                    }
                }
            }
            return result;
        }
        public static Matrix<T> operator *(Matrix<T> a, Matrix<T> b)
        {
            if (a.Cols != b.Rows)
            {
                throw new ArgumentException("Matrices are of different size, unable to perform operation");
            }

            var result = new Matrix<T>(a.Rows, b.Cols);

            for (int row = 0; row < a.Rows; row++)
            {
                for (int col = 0; col < b.Cols; col++)
                {
                    dynamic sum = 0;

                    try
                    {
                        for (int element = 0; element < a.Cols; element++)
                        {
                            dynamic numA = a[row, element];
                            dynamic numB = b[element, col];

                            sum += numA * numB;
                        }
                    }
                    catch (ArgumentException)
                    {
                        Console.WriteLine("Invalid Data Type");
                        throw;
                    }
                    
                    result[row, col] = sum;
                }
            }

            return result;
        }

        #endregion
    }
}
