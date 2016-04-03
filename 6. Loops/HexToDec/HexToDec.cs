using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HexToDec
{
    class HexToDec
    {
        static void Main()
        {
            string input = Console.ReadLine();
            long output = 0;

            string hexDig = "0 1 2 3 4 5 6 7 8 9 A B C D E F";
            string[] hexDigits = hexDig.Split(' ');

            char[] inputDigits = input.ToCharArray();
            
        }
    }
}
