using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCD
{
    class CommonDivisor
    {
        static void Main()
        {
            string input = Console.ReadLine();
            string[] inputArr = input.Split(' ');

            int numA = Convert.ToInt32(inputArr[0]);
            int numB = Convert.ToInt32(inputArr[1]);

            int temp = Math.Max(numA, numB);
            numB = Math.Min(numA, numB);
            numA = temp;

            numA = Math.Abs(numA);
            numB = Math.Abs(numB);

            while (Math.Max(numA, numB) - Math.Min(numA, numB) > 0)
            {
                if (numA > numB)
                {
                    do
                    {
                        numA -= numB;
                    } while (numA - numB > numB);
                }

                if (numA < numB)
                {
                    do
                    {
                        numB -= numA;
                    } while (numB - numA > numA);
                }
            }

            if (numA == numB)
            {
                Console.WriteLine(numA);
            }
        }
    }
}
