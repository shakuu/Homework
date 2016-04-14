using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

//http://www.permadi.com/tutorial/numDecToHex/

namespace DecimaltoHex
{
    class DecimaltoHex
    {
        static void Main()
        {
            BigInteger input = BigInteger.Parse(Console.ReadLine());
            string output = "";

            string hexDigits = "0 1 2 3 4 5 6 7 8 9 A B C D E F";
            string[] hexDigit = hexDigits.Split(' ');

            BigInteger div = 16;
            BigInteger currIndex;
            while (true)
            {
                currIndex = input % div;
                output = hexDigit[(int)currIndex] + output;
                input /= div;

                if (input == 0) { break; }
            }
            Console.WriteLine(output);
        }
    }
}
