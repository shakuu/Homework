using System;

namespace PersianRugs
{
    class PersianRugs
    {
        static void Main()
        {
            //symbols
            const string Filler = "#";
            const string Dot = ".";
            const string EmptySpace = " ";
            const string TriangeLeft = "\\";
            const string TriangleRight = "/";
            const string eX = "X";

            //input
            var numN = int.Parse(Console.ReadLine());     // Size input    
            var Dist = int.Parse(Console.ReadLine());        // Distance

            //variables
            int RugSize = 2 * numN + 1;                         // Widt = Height 
            int MidPoint = numN;                                    // make it easy 

            //print skeleton
            for (int row = 0; row < RugSize; row++)
            {
                for (int col = 0; col < RugSize; col++)
                {
                    //Print Center X 
                    if (row - col == 0 && row != MidPoint)                                   // Print Diagonal Right
                    {
                        Console.Write(TriangeLeft);
                    }
                    else if (row + col == RugSize - 1 && row != MidPoint)            // Print Diagonal Left 
                    {
                        Console.Write(TriangleRight);
                    }
                    else if (row == MidPoint &&                                                  // Print Mid X            
                        col == MidPoint)
                    {
                        Console.Write(eX);
                    }
                    else if (row == MidPoint && col != MidPoint)
                    {
                        Console.Write(Filler);
                    }
                    else if (row < MidPoint && row - col > 0)       //filler top left 
                    {
                        Console.Write(Filler);
                    }
                    else if (row > MidPoint && row - col < 0)       // filler bot right
                    {
                        Console.Write(Filler);
                    }
                    else if (row < MidPoint && row + col > RugSize - 1)     // filler top right
                    {
                        Console.Write(Filler);
                    }
                    else if (row > MidPoint && row + col < RugSize - 1)     // filler bot left 
                    {
                        Console.Write(Filler);
                    }
                    else if (col - row == Dist + 1 && row < MidPoint - Dist - 1)
                    {
                        Console.Write(TriangeLeft);
                    }
                    else if (row - col == Dist + 1 && row > MidPoint + Dist + 1)
                    {
                        Console.Write(TriangeLeft);
                    }
                    else if (row + col == RugSize - 2 - Dist && row < MidPoint - Dist - 1)
                    {
                        Console.Write(TriangleRight);
                    }
                    else if (row + col == RugSize + Dist && row > MidPoint + Dist + 1)
                    {
                        Console.Write(TriangleRight);
                    }
                    else if (col - row > Dist + 1 &&
                        row + col < RugSize - 2 - Dist
                        && row < MidPoint - Dist - 1)
                    {
                        Console.Write(Dot);
                    }
                    else if (row - col > Dist + 1 && row + col > RugSize + Dist && row > MidPoint + Dist + 1)
                    {
                        Console.Write(Dot);
                    }
                    else
                    {
                        Console.Write(EmptySpace);
                    }

                }

                Console.WriteLine();                                                               // New Line
            }

        }
    }
}
