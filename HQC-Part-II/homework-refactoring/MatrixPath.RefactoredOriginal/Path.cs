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

        public static void FindAnEmptyCellToJumpTo(int[,] arr, out int x, out int y)
        {
            x = 0;
            y = 0;
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(0); j++)
                {
                    if (arr[i, j] == 0)
                    {
                        x = i;
                        y = j;
                        return;
                    }
                }
            }
        }

        public static void Main(string[] args)
        {
            int matrixSize = 6;
            int[,] theMatrix = new int[matrixSize, matrixSize];
            var nextCellValue = 1;
            var rowCoordinate = 0;
            var colCoordinate = 0;
            var deltaX = 1;
            var deltaY = 1;

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
                while (isOutOfBounds || theMatrix[rowCoordinate + deltaX, colCoordinate + deltaY] != 0)
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

            FindAnEmptyCellToJumpTo(theMatrix, out rowCoordinate, out colCoordinate);

            if (rowCoordinate != 0 && colCoordinate != 0)
            {
                nextCellValue++;
                deltaX = 1;
                deltaY = 1;

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
                    while (isOutOfBounds || theMatrix[rowCoordinate + deltaX, colCoordinate + deltaY] != 0)
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

            PrintTheMatrix(theMatrix);
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
