using System;

namespace GoikoTower
{
    class Program
    {
        static void Main()
        {
            int towerH = int.Parse(Console.ReadLine());
            int towerW = towerH * 2;

            char[,] theTower = new char[towerH, towerW];

            //fill with dots
            for (int row = 0; row < towerH; row++)
            {
                for (int col = 0; col < towerW; col++)
                {
                    theTower[row, col] = '.';
                }
            }
            
            //build tower
            for (int row = 0; row < towerH; row++)
            {
                theTower[row, towerW / 2 - 1 - row] = '/';
                theTower[row, towerW / 2 + row] = '\\';
            }
            //build beams
            int currRow = 0;
            for (int rowD = 1; currRow + rowD < towerH; rowD++)
            {
                currRow += rowD;
                for (int col = towerW / 2 - currRow;
                    col < towerW / 2 + currRow; col++)
                {
                    theTower[currRow, col] = '-';
                }
            }

            //print tower
            for (int row = 0; row < towerH; row++)
            {
                for (int col = 0; col < towerW; col++)
                {
                    Console.Write(theTower[row, col]);
                }
                Console.WriteLine();
            }
        }
    }
}
