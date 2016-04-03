using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DigitAsWord
{
    class DigitAsWord
    {
        static void Main()
        {
            int digit;
            try
            {
                digit = int.Parse(Console.ReadLine());
            }
            catch (System.FormatException)
            {
                Console.WriteLine("not a digit");
                return;
            }
            //System.FormatException
            string digitsNames = "zero one two three four five six seven eight nine";
            string[] digits = digitsNames.Split(' ');

            if ( digit < 0 || digit > 9)
            {
                Console.WriteLine("not a digit");
            }
            else
            {
                Console.WriteLine(digits[digit]);
            }
        }
    }
}
