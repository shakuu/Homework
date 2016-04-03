using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarytoDecimal
{
    class BinarytoDec
    {
        static void Main()
        {
            string binaryNumb = Console.ReadLine();
            double numbToPrint = 0;
            char[] bits = binaryNumb.ToCharArray();

            for ( int i =0; i<binaryNumb.Length; i++)
            {
                numbToPrint = numbToPrint + ((bits[i] - 48) * 
                    ( Math.Pow(2, (binaryNumb.Length-1)-i)));
            }
            Console.WriteLine(numbToPrint);
        }
    }
}
