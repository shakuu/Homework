using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FourDigits
{
    class FourDigits
    {
        static void Main(string[] args)
        {
            //INPUT
            string abcd = Console.ReadLine();
            //OUTPUT
            int sumFour = 0; //SUM RESULT a+b+c+d
            short reverseABCD; // Revers dcba
            short lastFirst; // last digit first dabc
            short midReverse; // acbd
            string tempString = "";

            for ( int i =0; i < abcd.Length;i++)
            { sumFour += abcd.ElementAt(i) - 48;
                tempString += abcd.ElementAt(abcd.Length - 1 - i); }
            reverseABCD = short.Parse(tempString); //dcba

            tempString = abcd.Insert(0, abcd.ElementAt(abcd.Length-1).ToString());
            tempString = tempString.Remove(tempString.Length - 1);
            lastFirst = short.Parse(tempString); //dcba

            tempString = abcd.Insert(1, abcd.ElementAt(abcd.Length - 2).ToString());
            tempString = tempString.Remove(tempString.Length - 2, 1);
            midReverse = short.Parse(tempString); //acbd

            Console.WriteLine ("{0}\n{1}\n{2}\n{3}", 
                sumFour, reverseABCD, lastFirst, midReverse);
        }
    }
}
