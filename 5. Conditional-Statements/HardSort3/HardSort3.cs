using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HardSort3
{
    class HardSort3
    {
        static void Main()
        {
            int numA = int.Parse(Console.ReadLine());
            int numB = int.Parse(Console.ReadLine());
            int numC = int.Parse(Console.ReadLine());
            int temp;
        

            while ( !(numA >= numB && numB >= numC) )
            {
                if ( numA < numB)
                {
                    temp = numB;
                    numB = numA;
                    numA = temp;
                }

                if (numB < numC)
                {
                    temp = numC;
                    numC = numB;
                    numB = temp;
                }
            }

            Console.WriteLine("{0} {1} {2}", numA, numB, numC);
        }
    }
}
