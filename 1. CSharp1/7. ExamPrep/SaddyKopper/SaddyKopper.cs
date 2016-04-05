using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
using System.IO;

namespace SaddyKopper
{
    class SaddyKopper
    {
        static void Main()
        {
            Console.SetIn(new StreamReader(Console.OpenStandardInput(8192)));

            string input = Console.ReadLine();
            int evenSum = 0;
            BigInteger product = 1;
            for ( int transform = 0; transform < 10; transform ++) //max 10 parses
            {
                evenSum = 0;
                product = 1;
                int index = 0;

                for (int check = 1; check < input.Length; check++)
                {
                    index = 0;
                    evenSum = 0;
                    foreach (var digit in input)
                    {
                        if (index % 2 == 0 && index < input.Length- check)
                        {
                            evenSum += (digit - 48);
                        }
                        index++;
                    }
                    product *= evenSum;
                }
                input = product.ToString();

                if ( input.Length==1)
                {
                    Console.WriteLine(transform + 1);
                    Console.WriteLine(input);
                    return;
                }
                else if ( transform== 9 )
                {
                    Console.WriteLine(input);
                    return;
                }
            }
        }
    }
}
