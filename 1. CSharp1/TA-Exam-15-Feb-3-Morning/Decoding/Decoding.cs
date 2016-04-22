using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decoding
{
    class Decoding
    {
        static void Main()
        {
            //input SALT -> Modifier, TEXT -> inputString
            var SALT = int.Parse(Console.ReadLine());
            var Text = Console.ReadLine();

            List<double> EncodeValues = new List<double>(); // not really needed 

            double currValue = 0;

            for (int chr = 0; chr < Text.Length; chr++)
            {
                //reset Value
                currValue = 0;

                //Check 1: letter/ digit/ else
                //stop on @
                if (Text[chr] == '@')
                {
                    break;
                }
                // if LETTER
                else if (char.IsLetter(Text[chr]))
                {
                    currValue = Text[chr] * SALT + 1000;
                }
                else if (char.IsDigit(Text[chr]))
                {
                    currValue = Text[chr] + SALT + 500;
                }
                else
                {
                    currValue = Text[chr] - SALT;
                }

                //Check 2: odd / even position 
                if (chr % 2 == 0)
                {
                    currValue /= 100;
                    Console.WriteLine(currValue.ToString("0.00"));
                }
                else
                {
                    currValue *= 100;
                    Console.WriteLine(currValue); // no additional 00s
                }
            }
        }
    }
}
