using System;

namespace Task3
{
    public class Path
    {
        public static void ChangeDirection(ref int dx, ref int dy)
        {
            int[] deltaX = { 1, 1, 1, 0, -1, -1, -1, 0 };
            int[] deltaY = { 1, 0, -1, -1, -1, 0, 1, 1 };

            int currentDirectionIndex = 0;
            for (int directionIndex = 0; directionIndex < 8; directionIndex++)
            {
                if (deltaX[directionIndex] == dx && deltaY[directionIndex] == dy)
                {
                    currentDirectionIndex = directionIndex;
                    break;
                }
            }

            if (currentDirectionIndex == 7)
            {
                dx = deltaX[0];
                dy = deltaY[0];
                return;
            }

            dx = deltaX[currentDirectionIndex + 1];
            dy = deltaY[currentDirectionIndex + 1];
        }

        public static bool CheckIfNextMatrixCellIsEmpty(int[,] matrix, int row, int col)
        {
            int[] deltaX = { 1, 1, 1, 0, -1, -1, -1, 0 };
            int[] deltaY = { 1, 0, -1, -1, -1, 0, 1, 1 };

            var matrixSize = matrix.GetLength(0);
            for (int directionIndex = 0; directionIndex < 8; directionIndex++)
            {
                if (row + deltaX[directionIndex] >= matrixSize || row + deltaX[directionIndex] < 0)
                {
                    deltaX[directionIndex] = 0;
                }

                if (col + deltaY[directionIndex] >= matrixSize || col + deltaY[directionIndex] < 0)
                {
                    deltaY[directionIndex] = 0;
                }
            }

            for (int directionIndex = 0; directionIndex < 8; directionIndex++)
            {
                if (matrix[row + deltaX[directionIndex], col + deltaY[directionIndex]] == 0)
                {
                    return true;
                }
            }

            return false;
        }

        public static void FindAnEmptyCellToJumpTo(int[,] theMatrix, out int positionRow, out int positionCol)
        {
            positionRow = 0;
            positionCol = 0;

            var matrixSize = theMatrix.GetLength(0);
            for (int row = 0; row < matrixSize; row++)
            {
                for (int col = 0; col < matrixSize; col++)
                {
                    if (theMatrix[row, col] == 0)
                    {
                        positionRow = row;
                        positionCol = col;
                        return;
                    }
                }
            }
        }

        public static void Main()
        {
            int matrixSize = 6;
            int[,] theMatrix = new int[matrixSize, matrixSize];
            var nextCellValue = 1;
            var rowCoordinate = 0;
            var colCoordinate = 0;

            FillTheMatrixUntilADeadEnd(theMatrix, ref rowCoordinate, ref colCoordinate, ref nextCellValue);
            FindAnEmptyCellToJumpTo(theMatrix, out rowCoordinate, out colCoordinate);
            while (rowCoordinate != 0 && colCoordinate != 0)
            {
                nextCellValue++;
                FillTheMatrixUntilADeadEnd(theMatrix, ref rowCoordinate, ref colCoordinate, ref nextCellValue);
                FindAnEmptyCellToJumpTo(theMatrix, out rowCoordinate, out colCoordinate);
            }

            PrintTheMatrix(theMatrix);
        }

        private static void FillTheMatrixUntilADeadEnd(int[,] theMatrix, ref int rowCoordinate, ref int colCoordinate, ref int nextCellValue)
        {
            var deltaX = 1;
            var deltaY = 1;
            var matrixSize = theMatrix.GetLength(0);

            while (true)
            {
                theMatrix[rowCoordinate, colCoordinate] = nextCellValue;
                if (!CheckIfNextMatrixCellIsEmpty(theMatrix, rowCoordinate, colCoordinate))
                {
                    break;
                }

                var nextRowCoordinateCandidate = rowCoordinate + deltaX;
                var nextColCoordinateCandidate = colCoordinate + deltaY;
                var isOutOfBounds = CheckIfCoordinateCandidateIsOutOfBounds(matrixSize, nextRowCoordinateCandidate, nextColCoordinateCandidate);
                while (isOutOfBounds || theMatrix[nextRowCoordinateCandidate, nextColCoordinateCandidate] != 0)
                {
                    ChangeDirection(ref deltaX, ref deltaY);

                    nextRowCoordinateCandidate = rowCoordinate + deltaX;
                    nextColCoordinateCandidate = colCoordinate + deltaY;
                    isOutOfBounds = CheckIfCoordinateCandidateIsOutOfBounds(matrixSize, nextRowCoordinateCandidate, nextColCoordinateCandidate);
                }

                rowCoordinate += deltaX;
                colCoordinate += deltaY;
                nextCellValue++;
            }
        }

        private static void PrintTheMatrix(int[,] matrix)
        {
            var matrixSize = matrix.GetLength(0);
            for (int row = 0; row < matrixSize; row++)
            {
                for (int col = 0; col < matrixSize; col++)
                {
                    Console.Write("{0,3}", matrix[row, col]);
                }

                Console.WriteLine();
            }
        }

        private static bool CheckIfCoordinateCandidateIsOutOfBounds(int matrixSize, int rowCandidate, int colCandidate)
        {
            var isRowOutOfBounds = rowCandidate < 0 || matrixSize <= rowCandidate;
            var isColOutOfBounds = colCandidate < 0 || matrixSize <= colCandidate;
            var isOutOfBounds = isRowOutOfBounds || isColOutOfBounds;

            return isOutOfBounds;
        }
    }
}
