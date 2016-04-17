using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carpets
{
    class Carpets
    {
        static void Main()
        {
            int carpetSize = int.Parse(Console.ReadLine());

            char[,] theCarpet = new char[carpetSize, carpetSize];
            //fill with dots
            for (int row = 0; row < carpetSize; row++)
            {
                for (int col = 0; col < carpetSize; col++)
                {
                    theCarpet[row, col] = '.';
                }
            }

            //print OutSide
            for (int startRow = 0; startRow < carpetSize / 2; startRow += 2)
            {
                for (int row = startRow; row < carpetSize / 2; row++)
                {
                    theCarpet[row, carpetSize / 2 - 1 - row +startRow] = '/';
                    theCarpet[row, carpetSize / 2 + row-startRow] = '\\';
                    theCarpet[carpetSize - 1 - row, carpetSize / 2 - 1 - row+startRow] = '\\';
                    theCarpet[carpetSize - 1 - row, carpetSize / 2 + row-startRow] = '/';
                }
            }
            for (int row = 0; row < carpetSize; row++)
            {
                for (int col = 0; col < carpetSize; col++)
                {

                    Console.Write(theCarpet[row, col]);
                }
                Console.WriteLine();
            }
        }
    }
}
