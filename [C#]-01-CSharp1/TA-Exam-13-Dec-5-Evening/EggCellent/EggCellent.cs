using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EggCellent
{
    class EggCellent
    {
        static void Main()
        {
            //characters
            string Outline = "*";
            string Crack = "@";
            string Filler = ".";

            //input
            int inputSize = int.Parse(Console.ReadLine());

            // sizes derived from input by definition
            int height = inputSize * 2;
            int width = 3 * inputSize - 1;
            int areaWidth = 3 * inputSize + 1;
            int top = inputSize - 1;

            //Print
            for (int row = 0; row < height; row++)
            {
                for (int col = 0; col < areaWidth; col++)
                {
                    //write
                    //Step 1: Outline
                    // a. diagonals
                    if (row + col == inputSize + 1 - row   // Top Left
                        && col != 0)
                    {
                        Console.Write(Outline);
                    }
                    else if (row + col == areaWidth - 5 + areaWidth - row
                        && col != width - 1) // Bottom Right // why on earth 5 ?!?
                    {
                        Console.Write(Outline);
                    }
                    else if (row - col == areaWidth-4 - row)     // Bot Left // why on earth 4 ?!?
                    {
                        Console.Write(Outline);
                    }
                    else if (col - row == (2 * inputSize) - 1 + row)    //top Right
                    {
                        Console.Write(Outline);
                    }
                    // b. Horizontal Lines Top and Bottom
                    else if (row == 0           // Top 
                        && col > inputSize + 1
                        && col < 2 * inputSize - 1)
                    {
                        Console.Write(Outline);
                    }
                    else if (row == height - 1  // Bottom
                        && col > inputSize + 1
                        && col < 2 * inputSize - 1)
                    {
                        Console.Write(Outline);
                    }
                    // c. Vertical Lines Left and Right
                    else if (col == 1                       // Left
                        && row > inputSize / 2 - 1
                        && row < height - inputSize / 2)
                    {
                        Console.Write(Outline);
                    }
                    else if (col == width               // Right
                        && row > inputSize / 2 - 1
                        && row < height - inputSize / 2)
                    {
                        Console.Write(Outline);
                    }
                    // Step 2: Cracks
                    // a. Starting with @
                    else if (row == inputSize - 1
                        && col > 1
                        && col < width
                        && col % 2 == 0)
                    {
                        Console.Write(Crack);
                    }
                    // b. Starting with .
                    else if (row == inputSize
                        && col > 1
                        && col < width
                        && col % 2 != 0)
                    {
                        Console.Write(Crack);
                    }
                    else
                    {
                        Console.Write(Filler);
                    }

                }
                //new line
                Console.WriteLine();
            }
        }
    }
}
