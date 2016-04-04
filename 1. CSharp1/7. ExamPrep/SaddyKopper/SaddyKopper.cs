using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaddyKopper
{
    class Program
    {
        static void Main()
        {
            string INPUT = Console.ReadLine();
            char[] number = INPUT.ToCharArray();

            
            int evenSum = 0;
            long product = 1;
           

            for ( int i = 0; i < 10; i++)
            {
                product = 1;
                //Get EVEN sum, multiply each sum.
                for (int k = 0; k < number.Length-1; k++)
                {
                    evenSum = 0;
                    for (int p = 0; p < number.Length - k-1; p += 2)
                    {
                        evenSum +=(number[p] - 48);
                    }
                    product *= evenSum;
                }
                //

                number = product.ToString().ToCharArray();

                if (number.Length == 1)
                {
                    Console.Write("{0}\n{1}", i + 1, number[0].ToString());
                    return;
                }
                
            }
            Console.WriteLine(product);
        }
    }
}
