
namespace PointAndMatrix.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using GenericMatrix;

    class MatrixTesting
    {
        public static void MainTest()
        {
            var matrix1 = new Matrix<int>(3, 2);
            var matrix2 = new Matrix<int>(2, 2);

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

            //for (int row = 0; row < matrix1.Rows; row++)
            //{
            //    for (int col = 0; col < matrix1.Cols; col++)
            //    {
            //        matrix1[row, col] = row + col;
            //        matrix2[col, row] = row * col + 5;
            //    }
            //}

            var resultProduct = matrix1 * matrix2;
        }
    }
}
