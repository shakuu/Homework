using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OddAndEvenProduct
{
    class OddEvenProduct
    {
        static void Main()
        {
            int elementCount = int.Parse(Console.ReadLine());
            string elementsString = Console.ReadLine();
            int oddSum = 1; int evenSum = 1;

            string[] arrElements = elementsString.Split(' ');

            for ( int index = 0; index<arrElements.Length; index++)
            {
                if (index%2!=0)
                {
                    evenSum *= Convert.ToInt32(arrElements[index]);
                }
                else
                {
                    oddSum *= Convert.ToInt32(arrElements[index]);
                }
            }

            if ( oddSum==evenSum)
            {
                Console.WriteLine("yes {0}", oddSum);
            }
            else
            {
                Console.WriteLine("no {0} {1}", oddSum, evenSum);
            }
        }
    }
}
