
namespace PointAndMatrix.Tests
{
    using System;
    using GenericMatrix;

    class MatrixTesting
    {
        public static void MainTest()
        {
            Console.WriteLine(Environment.NewLine
                + "Matrix Testing: "
                + Environment.NewLine);
            
            var matrix1 = new Matrix<int>(3, 2);
            var matrix2 = new Matrix<int>(2, 2);
            #region Filling Matrices
            matrix1[0, 0] = 4;
            matrix1[0, 1] = 8;
            matrix1[1, 0] = 0;
            matrix1[1, 1] = 2;
            matrix1[2, 0] = 1;
            matrix1[2, 1] = 6;

            matrix2[0, 0] = 5;
            matrix2[0, 1] = 2;
            matrix2[1, 0] = 9;
            matrix2[1, 1] = 4;
            #endregion

            var resultProduct = matrix1 * matrix2;

            if (matrix2)
            {
                Console.WriteLine("no zeroes");
            }
            else
            {
                Console.WriteLine("yes zeroes");
            }
        }
    }
}
