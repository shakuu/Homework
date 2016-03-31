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
            string tempString = "";

            for (int i = 0; i < abcd.Length; i++)
            {
                sumFour += abcd.ElementAt(i) - 48;
                tempString += abcd.ElementAt(abcd.Length - 1 - i);
            }
            Console.WriteLine(sumFour); // a+b+c+d
            PrintString(tempString); // dcba

            tempString = abcd.Insert(0, abcd.ElementAt(abcd.Length - 1).ToString());
            tempString = tempString.Remove(tempString.Length - 1);
            PrintString(tempString); // dabc

            tempString = abcd.Insert(1, abcd.ElementAt(abcd.Length - 2).ToString());
            tempString = tempString.Remove(tempString.Length - 2, 1);
            PrintString(tempString);  // acbd    
        }

        static void PrintString(string toPrint)
        {
            if (toPrint.ElementAt(0).ToString() == "0") {
                toPrint = toPrint.Remove(0, 1);}
            Console.WriteLine(toPrint);
        }
    }
}
