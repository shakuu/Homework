using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace ConsoleApp2
{
    class ConsoleApp2
    {
        static void Main()
        {
            Queue<string> INPUT = new Queue<string>();
            while (!INPUT.Contains("END"))
            {
                INPUT.Enqueue(Console.ReadLine().ToUpper());
            }
            
            BigInteger resultFirstTen  = 1;
            BigInteger resultOthers = 1;

            int counter = 0; //first 10 elements or less
            while(INPUT.Count > 1)
            {
                if (counter % 2 == 0)
                {
                    foreach (char digit in INPUT.Dequeue().ToString())
                    {
                        resultFirstTen *= (digit - '0');
                    }
                }
                else
                {
                    INPUT.Dequeue();
                }

                counter++;
                if (counter==10) { break; }
            }

            while(INPUT.Count>1)
            {
                if (counter % 2 == 0)
                {
                    foreach (char digit in INPUT.Dequeue().ToString())
                    {
                        resultOthers *= (digit - '0');
                    }
                }
                else
                {
                    INPUT.Dequeue();
                }

                counter++;
            }

            if ( counter <=10)
            {
                Console.WriteLine(resultFirstTen.ToString());
            }
            else
            {
                Console.WriteLine(resultFirstTen.ToString());
                Console.WriteLine(resultOthers.ToString());
            }
        }
    }
}
