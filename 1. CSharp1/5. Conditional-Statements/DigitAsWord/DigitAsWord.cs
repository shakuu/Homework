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
                if (digit < 0 || digit > 9)
                {
                    throw new FormatException();
                }
            }
            catch (System.FormatException)
            {
                Console.WriteLine("not a digit");
                return;
            }
            //System.FormatException
            string digitsNames = "zero one two three four five six seven eight nine";
            string[] digits = digitsNames.Split(' ');

            Console.WriteLine(digits[digit]);

        }
    }
}
