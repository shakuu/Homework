using System;

using MatrixPath.Logic.Cells;
using MatrixPath.Logic.Directions;
using MatrixPath.Logic.Matrices;
using MatrixPath.Logic.UI;
using MatrixPath.Logic.Utils;
using MatrixPath.Logic.Values;

namespace MatrixPath.ConsoleClient
{
    public class Program
    {
        public static void Main()
        {
            var ui = new BasicUserInterface(Console.WriteLine, Console.ReadLine);
            var inputMatrixSize = ui.AskForInput("Enter matrix size: ");

            int parsedMatrixSize;
            var isSuccessfullyParsed = int.TryParse(inputMatrixSize, out parsedMatrixSize);
            if (isSuccessfullyParsed)
            {
                var theMatrix = new BasicMatrix(parsedMatrixSize, InstantiatingMethods.CreateMatrixCell);

                var directionSequence = new BasicPathDirectionSequence(InstantiatingMethods.CreateDirection);
                var valuesGenerator = new BasicCellValueSequence();
                var startPosition = new Position(0, 0);

                theMatrix.Populate(startPosition, directionSequence, valuesGenerator);
                ui.PostMessage(theMatrix.ToString());
            }
            else
            {
                ui.PostMessage("Invalid matrix size input.");
            }
        }
    }
}
