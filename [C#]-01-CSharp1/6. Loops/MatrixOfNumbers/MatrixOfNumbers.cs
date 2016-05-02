using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixOfNumbers
{
    class MatrixOfNumbers
    {
        static void Main()
        {
            int arrSize = int.Parse(Console.ReadLine());

            int toPrint = 1;

            for ( int i = 1; i<  Math.Pow(arrSize,2)+1 ;i++ )
            {
                Console.Write(toPrint);
                toPrint++;

                if ( i %arrSize==0 )
                {
                    toPrint = toPrint - (arrSize - 1);
                    Console.Write("\n");
                }
                else
                {
                    Console.Write(" ");
                }

            }
        }
    }
}
