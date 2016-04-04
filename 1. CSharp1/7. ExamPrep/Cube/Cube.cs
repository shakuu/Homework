using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cube
{
    class Cube
    {
        static void Main()
        {

            Console.WindowWidth = 50;
            Console.WindowHeight = 30;
            int cube = int.Parse(Console.ReadLine());

            Console.BufferHeight =  cube * cube;
            Console.BufferWidth =  cube * cube;
            

            //PRINT FACE
            for (int row = cube - 1; row < 2 * cube - 1; row++)
            {
                //TOP-BOT ROW
                if (row == cube - 1 || row == 2 * cube - 2)
                {
                    Console.SetCursorPosition(0, row);
                    for (int col = 0; col < cube; col++)
                    {
                        Console.Write(":");
                    }
                }//END TOP-BOT ROW
                else//FILLER
                {
                    Console.SetCursorPosition(0, row);
                    Console.Write(":");
                    for (int col = 1; col < cube - 1; col++)
                    {
                        Console.Write(" ");
                    }
                    Console.Write(":");
                }
            }//END FACE

            //PRINT TOP
            for (int row = 0; row < cube - 1; row++)
            {
                //TOP
                if (row == 0)
                {
                    for (int col = 2 * cube - 2; col > cube - 2; col--)
                    {
                        Console.SetCursorPosition(col, row);
                        Console.Write(":");
                    }
                }//END TOP
                else //FILLER
                {
                    Console.SetCursorPosition((2 * cube - 2) - row, row);
                    Console.Write(":");
                    for (int col = (2 * cube - 1) - row - 2; col > cube - row - 1; col--)
                    {
                        Console.SetCursorPosition(col, row);
                        Console.Write("/");
                    }
                    Console.SetCursorPosition((2 * cube - 1) - row - cube, row);
                    Console.Write(":");
                }
            }//END TOP

            //PRINT SIDE - TOP
            for (int row = 1; row < cube; row++)
            {
                if (row == 1)
                {
                    Console.SetCursorPosition(2 * cube - 2, row);
                    Console.Write(":");
                }
                else
                {
                    Console.SetCursorPosition(2 * cube - 2, row);
                    Console.Write(":");

                    for (int col = 1; col < row; col++)
                    {
                        Console.SetCursorPosition(2 * cube - 2 - col, row);
                        Console.Write("X");
                    }
                }
            }//END SIDE TOP

            //PRINT SIDE BOT
            int modifier = 2;
            for (int row = cube; row < 2 * cube - 2; row++)
            {
                if ( row != 2*cube-3)
                {
                    Console.SetCursorPosition(cube, row);
                    for( int col = cube; col < 2*cube-1-modifier; col++)
                    {
                        Console.Write("X");
                    }
                    Console.Write(":");
                }
                else
                {
                    Console.SetCursorPosition(cube, row);
                    Console.Write(":");
                }
                modifier++;
            }
        }
    }
}
