using System;

namespace Task3
{
    class WalkInMatrica
    {
        static void ChangeDirection(ref int dx, ref int dy)
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

        static bool CheckIfNextMatrixCellIsEmpty(int[,] matrix, int row, int col)
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

        static void FindAnEmptyCellToJumpTo(int[,] arr, out int x, out int y)
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

        static void Main(string[] args)
        {
            //Console.WriteLine( "Enter a positive number " );
            //string input = Console.ReadLine(  );
            //int n = 0;
            //while ( !int.TryParse( input, out n ) || n < 0 || n > 100 )
            //{
            //    Console.WriteLine( "You haven't entered a correct positive number" );
            //    input = Console.ReadLine(  );
            //}
            int matrixSize = 6;
            int[,] theMatrix = new int[matrixSize, matrixSize];
            var nextCellValue = 1;
            var rowCoordinate = 0;
            var colCoordinate = 0;
            var deltaX = 1;
            var deltaY = 1;

            //malko e kofti tova uslovie, no break-a raboti 100% : )
            while (true)
            {
                theMatrix[rowCoordinate, colCoordinate] = nextCellValue;

                // prekusvame ako sme se zadunili
                if (!CheckIfNextMatrixCellIsEmpty(theMatrix, rowCoordinate, colCoordinate))
                {
                    break;
                }

                if (rowCoordinate + deltaX >= matrixSize || rowCoordinate + deltaX < 0 || colCoordinate + deltaY >= matrixSize || colCoordinate + deltaY < 0 || theMatrix[rowCoordinate + deltaX, colCoordinate + deltaY] != 0)
                {
                    while ((rowCoordinate + deltaX >= matrixSize || rowCoordinate + deltaX < 0 || colCoordinate + deltaY >= matrixSize || colCoordinate + deltaY < 0 || theMatrix[rowCoordinate + deltaX, colCoordinate + deltaY] != 0))
                    {
                        ChangeDirection(ref deltaX, ref deltaY);
                    }
                }

                rowCoordinate += deltaX;
                colCoordinate += deltaY;
                nextCellValue++;
            }

            for (int p = 0; p < matrixSize; p++)
            {
                for (int q = 0; q < matrixSize; q++)
                {
                    Console.Write("{0,3}", theMatrix[p, q]);
                }

                Console.WriteLine();
            }

            FindAnEmptyCellToJumpTo(theMatrix, out rowCoordinate, out colCoordinate);

            if (rowCoordinate != 0 && colCoordinate != 0)
            { // taka go napravih, zashtoto funkciqta ne mi davashe da ne si definiram out parametrite
                deltaX = 1;
                deltaY = 1;

                while (true)
                { //malko e kofti tova uslovie, no break-a raboti 100% : )
                    theMatrix[rowCoordinate, colCoordinate] = nextCellValue;
                    if (!CheckIfNextMatrixCellIsEmpty(theMatrix, rowCoordinate, colCoordinate))
                    {
                        break;
                    }// prekusvame ako sme se zadunili

                    var nextRowCoordinateCandidate = rowCoordinate + deltaX;
                    var nextColCoordinateCandidate = colCoordinate + deltaY;

                    var isOutOfBounds = CheckIfCoordinateCandidateIsOutOfBounds(matrixSize, nextRowCoordinateCandidate, nextColCoordinateCandidate);
                    if (isOutOfBounds || theMatrix[nextRowCoordinateCandidate, nextColCoordinateCandidate] != 0)
                    {
                        while ((rowCoordinate + deltaX >= matrixSize || rowCoordinate + deltaX < 0 || colCoordinate + deltaY >= matrixSize || colCoordinate + deltaY < 0 || theMatrix[rowCoordinate + deltaX, colCoordinate + deltaY] != 0))
                        {
                            ChangeDirection(ref deltaX, ref deltaY);
                        }
                    }

                    rowCoordinate += deltaX;
                    colCoordinate += deltaY;
                    nextCellValue++;
                }
            }

            for (int pp = 0; pp < matrixSize; pp++)
            {
                for (int qq = 0; qq < matrixSize; qq++)
                {
                    Console.Write("{0,3}", theMatrix[pp, qq]);
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
