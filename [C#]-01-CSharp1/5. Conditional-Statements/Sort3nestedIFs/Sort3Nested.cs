using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sort3nestedIFs
{
    class Sort3Nested
    {
        static void Main()
        {
            int numA = int.Parse(Console.ReadLine());
            int numB = int.Parse(Console.ReadLine());
            int numC = int.Parse(Console.ReadLine());

            if (numA < numB)
            {
                if (numA < numC)
                {
                    Console.Write(numA + " ");
                    if (numB < numC)
                    {
                        Console.Write(numB + " " + numC);
                    }
                    else
                    {
                        Console.Write(numC + " " + numB);
                    }
                }
            }
            else // b < A 
            {
                if (numB < numC)
                {
                    Console.Write(numB + " ");
                    if (numA < numC)
                    {
                        Console.Write(numA + " " + numC);
                    }
                    else
                    {
                        Console.Write(numC + " " + numA);
                    }
                }
                else //c < b
                {
                    Console.Write(numC + " ");
                    if (numA < numB)
                    {
                        Console.Write(numA + " " + numB);
                    }
                    else
                    {
                        Console.Write(numB + " " + numA);
                    }
                }
            }
        }
    }
}
