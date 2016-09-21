using System;

using MatrixPath.Logic.Cells;
using MatrixPath.Logic.Directions;
using MatrixPath.Logic.Matrices;
using MatrixPath.Logic.Utils;
using MatrixPath.Logic.Values;

namespace MatrixPath.ConsoleClient
{
    public class Program
    {
        public static void Main()
        {
            var theMatrix = new BasicMatrix(6, InstantiatingMethods.CreateMatrixCell);

            var directionSequence = new BasicPathDirectionSequence(InstantiatingMethods.CreateDirection);
            var valuesGenerator = new BasicCellValueSequence();
            var startPosition = new Position(0, 0);

            theMatrix.Populate(startPosition, directionSequence, valuesGenerator);
            Console.WriteLine(theMatrix.ToString());
        }
    }
}
