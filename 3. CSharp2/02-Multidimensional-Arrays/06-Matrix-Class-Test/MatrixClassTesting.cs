using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _06_Matrix_Class;

namespace _06_Matrix_Class_Test
{
    class MatrixClassTesting
    {
        static void Main(string[] args)
        {

            Matrix newMatrix = new Matrix(16);
            newMatrix.FillWithSequence(1);

            Matrix matrixTwo = new Matrix(8);
            matrixTwo.FillWithSequence(3);

            Matrix matrixThree = newMatrix + matrixTwo;
        }
    }
}
