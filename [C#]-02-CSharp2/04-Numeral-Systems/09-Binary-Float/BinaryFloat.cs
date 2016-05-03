using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09_Binary_Float
{
    class BinaryFloat
    {
        static void Main()
        {
            // input
            float toDisplayInput = float.Parse(Console.ReadLine());

            float toDisplay = toDisplayInput;
            // string 
            string toPrint = "";

            string[] BinKey = "0 1".Split(' ');

            string BinNumber = "";


            // get nuumber in format 1+ 0.xxxxxxx
            int powCounter = 0;

            while (!(toDisplay >= 1 && toDisplay < 2))
            {
                toDisplay /= 2;
                powCounter++;
            }



            // number part
            // TODO: to binary fraction
            // bits 0 -23
            float Number = toDisplay - 1;

            string NumString = "";

            // end when num = 0 
            // nothing to multiply
            while (Number != 0 &&
                   NumString.Length <= 23)
            {
                // Step 1: Multiply by 2
                Number *= 2;

                if (Number >= 1)          // if result larger than 1
                {                        //
                    NumString += "1";    // add 1
                    Number -= 1;          // remove the int part (1 )
                }                        //
                else                     // if not
                {                        //
                    NumString += "0";    // add 0
                }                        // keep result
            }

            // TODO: to binary
            // bits 30 - 24
            int Power = 127 + powCounter;

            // bit 31 -> 0 positive, 1 negative



            Console.WriteLine(toPrint);
        }
    }
}
