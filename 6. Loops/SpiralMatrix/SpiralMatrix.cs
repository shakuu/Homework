using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpiralMatrix
{
    class SpiralMatrix
    {
        static void Main()
        {
            int inputN = int.Parse(Console.ReadLine());

            //check if 1
            if (inputN==1)
            {
                Console.WriteLine("1");
                return;
            }

            int toPrint = 1;
            int[,] spiralMatrixArr = new int[inputN, inputN];
            int minX = 1, maxX = inputN, curX = 0;
            int minY = 0, maxY = inputN, curY = 0;

            //Row1
            for (int i = 0; i < maxY; i++)
            {
                spiralMatrixArr[curX, curY] = toPrint; toPrint++;
                curY++;
            }
            curX++;
            curY--;
            maxY--;

            //FOR ODD INPUT
            if (inputN % 2 == 1)
            {
                for (int i = inputN - 1; i > 1; i--)
                {
                    if (i % 2 == 0) // x+, y-
                    {
                        for (int indexX = curX; indexX < maxX; indexX++)
                        {
                            spiralMatrixArr[curX, curY] = toPrint; toPrint++;
                            curX++;
                        }
                        maxX--;
                        curX--;
                        curY--;
                        for (int indexY = curY; indexY > minY - 1; indexY--)
                        {
                            spiralMatrixArr[curX, curY] = toPrint; toPrint++;
                            curY--;
                        }
                        minY++;
                        curY++;
                        curX--;
                    }
                    else if (i % 2 == 1) // x- y+
                    {
                        for (int indexX = curX; indexX > minX - 1; indexX--)
                        {
                            spiralMatrixArr[curX, curY] = toPrint; toPrint++;
                            curX--;
                        }
                        minX++;
                        curX++;
                        curY++;

                        for (int indexY = curY; indexY < maxY; indexY++)
                        {
                            spiralMatrixArr[curX, curY] = toPrint; toPrint++;
                            curY++;
                        }
                        maxY--;
                        curY--;
                        curX++;
                    }

                }

                spiralMatrixArr[curX, curY] = toPrint; toPrint++; curY++;
                spiralMatrixArr[curX, curY] = toPrint;
            }

            //FOR EVEN INPUT
            if (inputN % 2 == 0)
            {
                for (int i = inputN - 1; i > 1; i--)
                {
                    if (i % 2 == 1) // x+, y-
                    {
                        for (int indexX = curX; indexX < maxX; indexX++)
                        {
                            spiralMatrixArr[curX, curY] = toPrint; toPrint++;
                            curX++;
                        }
                        maxX--;
                        curX--;
                        curY--;
                        for (int indexY = curY; indexY > minY - 1; indexY--)
                        {
                            spiralMatrixArr[curX, curY] = toPrint; toPrint++;
                            curY--;
                        }
                        minY++;
                        curY++;
                        curX--;
                    }
                    else if (i % 2 == 0) // x- y+
                    {
                        for (int indexX = curX; indexX > minX - 1; indexX--)
                        {
                            spiralMatrixArr[curX, curY] = toPrint; toPrint++;
                            curX--;
                        }
                        minX++;
                        curX++;
                        curY++;

                        for (int indexY = curY; indexY < maxY; indexY++)
                        {
                            spiralMatrixArr[curX, curY] = toPrint; toPrint++;
                            curY++;
                        }
                        maxY--;
                        curY--;
                        curX++;
                    }

                }

                spiralMatrixArr[curX, curY] = toPrint; toPrint++; curY--;
                spiralMatrixArr[curX, curY] = toPrint;
            }

            //PRINT
            for(int row = 0; row< inputN;row++)
            {
                for(int col = 0; col < inputN; col++)
                {
                    Console.Write(spiralMatrixArr[row, col]);
                    if(col != inputN-1) { Console.Write(" "); }
                }
                Console.Write("\n");
            }
      
        }
    }
}
