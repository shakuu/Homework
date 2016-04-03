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
            double tempOutput = 0;

            string hexDig = "0 1 2 3 4 5 6 7 8 9 A B C D E F";
            string[] hexDigits = hexDig.Split(' ');

            char[] inputDigits = input.ToCharArray();
            
            for( int inputI = 0; inputI< inputDigits.Length; inputI++)
            {
                for ( int hexI = 0; hexI < hexDigits.Length; hexI ++ )
                {
                    if ( inputDigits[inputI].ToString() == hexDigits[hexI])
                    {
                        tempOutput += hexI * Math.Pow(16, (inputDigits.Length - 1) - inputI);
                    }
                }
            }
            long output = Convert.ToInt64(tempOutput);
            Console.WriteLine(output);
        }
    }
}
