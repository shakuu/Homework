using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Cube
{
    class Cube
    {
        static void Main()
        {

            long cube1 = long.Parse(Console.ReadLine());
            int cube = Convert.ToInt32(cube1);
            int cubeSize = cube * 2 - 1;

            string[,] cubeArray = new string[cube * 2 - 1, cube * 2 - 1];

     
            //PRINT FACE
            for (int row = cube - 1; row < 2 * cube - 1; row++)
            {
                //TOP-BOT ROW
                if (row == cube - 1 || row == 2 * cube - 2)
                {
                    Console.SetCursorPosition(0, row);
                    for (int col = 0; col < cube; col++)
                    {
                        cubeArray[col, row] = ":";
                    }
                }//END TOP-BOT ROW
                else//FILLER
                {
                    cubeArray[0, row] = ":";
                    for (int col = 1; col < cube - 1; col++)
                    {
                        cubeArray[col, row] = " ";
                    }
                    cubeArray[cube - 1, row] = ":";
                }
            }//END FACE

            ////PRINT TOP
            for (int row = 0; row < cube - 1; row++)
            {
                //TOP
                if (row == 0)
                {
                    for (int col = cube-1; col < cube*2 - 1; col++)
                    {
                        cubeArray[ col, row] = ":";
                    }
                }//END TOP
                else //FILLER
                {
                    cubeArray[(2 * cube - 2) - row, row ] = ":"; 
                    for (int col = (2 * cube - 1) - row - 2; col > cube - row - 1; col--)
                    {
                        cubeArray[col, row] = "/";
                    }
                    cubeArray[ (2 * cube - 1) - row - cube , row] = ":";
                }
            }//END TOP

            ////PRINT SIDE - TOP
            for (int row = 1; row < cube; row++)
            {
                if (row == 1)
                {
                    cubeArray[2 * cube - 2, row] = ":";
                }
                else
                {
                    cubeArray[2 * cube - 2, row] = ":";
    
                    for (int col = 1; col < row; col++)
                    {
                        cubeArray[2 * cube - 2 - col, row] = "X";
                    }
                }
            }//END SIDE TOP

            ////PRINT SIDE BOT
            int modifier = 2;
            for (int row = cube; row < 2 * cube - 2; row++)
            {
                if (row != 2 * cube - 3)
                {

                    
                    for (int col = cube; col < 2 * cube - 1 - modifier; col++)
                    {
                        cubeArray[col, row] = "X";
                    }
                    cubeArray[2 * cube - 1 - modifier, row] = ":";
                }
                else
                {
                    cubeArray[cube, row] = ":";
                }
                modifier++;
            }


            for ( int x = 0; x< cube*2-1; x++)
            {
                for(int y = 0; y < cube*2-1; y++)
                {
                    if (cubeArray[y, x] == null)
                    {
                        cubeArray[y, x] = " ";
                    }
                    Console.Write(cubeArray[y, x]);
                }
                Console.WriteLine();
            }
        }
    }
}
