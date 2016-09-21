using System;

namespace Task3
{
    class WalkInMatrica
    {
        static void change(ref int dx, ref int dy)
        {
            int[] dirX = { 1, 1, 1, 0, -1, -1, -1, 0 };
            int[] dirY = { 1, 0, -1, -1, -1, 0, 1, 1 };

            int cd = 0;
            for (int count = 0; count < 8; count++)
            {
                if (dirX[count] == dx && dirY[count] == dy)
                {
                    cd = count; break;
                }
            }

            if (cd == 7)
            {
                dx = dirX[0];
                dy = dirY[0];
                return;
            }

            dx = dirX[cd + 1];
            dy = dirY[cd + 1];
        }

        static bool proverka(int[,] arr, int x, int y)
        {
            int[] dirX = { 1, 1, 1, 0, -1, -1, -1, 0 };
            int[] dirY = { 1, 0, -1, -1, -1, 0, 1, 1 };

            for (int i = 0; i < 8; i++)
            {
                if (x + dirX[i] >= arr.GetLength(0) || x + dirX[i] < 0)
                {
                    dirX[i] = 0;
                }


                if (y + dirY[i] >= arr.GetLength(0) || y + dirY[i] < 0)
                {
                    dirY[i] = 0;
                }
            }

            for (int i = 0; i < 8; i++)
            {
                if (arr[x + dirX[i], y + dirY[i]] == 0)
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
                if (!proverka(theMatrix, rowCoordinate, colCoordinate))
                {
                    break;
                } 

                if (rowCoordinate + deltaX >= matrixSize || rowCoordinate + deltaX < 0 || colCoordinate + deltaY >= matrixSize || colCoordinate + deltaY < 0 || theMatrix[rowCoordinate + deltaX, colCoordinate + deltaY] != 0)
                {
                    while ((rowCoordinate + deltaX >= matrixSize || rowCoordinate + deltaX < 0 || colCoordinate + deltaY >= matrixSize || colCoordinate + deltaY < 0 || theMatrix[rowCoordinate + deltaX, colCoordinate + deltaY] != 0))
                    {
                        change(ref deltaX, ref deltaY);
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
                    if (!proverka(theMatrix, rowCoordinate, colCoordinate))
                    {
                        break;
                    }// prekusvame ako sme se zadunili

                    if (rowCoordinate + deltaX >= matrixSize || rowCoordinate + deltaX < 0 || colCoordinate + deltaY >= matrixSize || colCoordinate + deltaY < 0 || theMatrix[rowCoordinate + deltaX, colCoordinate + deltaY] != 0)
                    {
                        while ((rowCoordinate + deltaX >= matrixSize || rowCoordinate + deltaX < 0 || colCoordinate + deltaY >= matrixSize || colCoordinate + deltaY < 0 || theMatrix[rowCoordinate + deltaX, colCoordinate + deltaY] != 0))
                        {
                            change(ref deltaX, ref deltaY);
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
    }
}
