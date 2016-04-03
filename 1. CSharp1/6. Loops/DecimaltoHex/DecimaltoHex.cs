using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecimaltoHex
{
    class DecimaltoHex
    {
        static void Main()
        {
            long input = long.Parse(Console.ReadLine());
            string output = "";

            string hexDigits = "0 1 2 3 4 5 6 7 8 9 A B C D E F";
            string[] hexDigit = hexDigits.Split(' ');

            long div = 16;

            while (input > 15)
            {
                while (div*16 < input) //largest power of 16
                {
                    div *= 16;
                } 

                output += hexDigit[(input - (input % div)) / div].ToString();

                input -= div *( (input - (input % div)) / div);
                //reset div
                div = 16;
            }

            output += hexDigit[input].ToString();

            Console.WriteLine(output);
        }
    }
}
