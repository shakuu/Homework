using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Numerics;

namespace SaddyKopper
{
    class SaddyKopper
    {
        static void Main()
        {
            Console.SetIn(new StreamReader(Console.OpenStandardInput(8192)));
            string INPUT = Console.ReadLine();
            char[] number = INPUT.ToCharArray();


            int evenSum;
            BigInteger product = 1;


            for (int i = 0; i < 10; i++)
            {
                evenSum = new int();
                product = 1;
                int index = 0;
                //Get EVEN sum, multiply each sum.
                foreach(var digit in INPUT)
                {
                    
                        if (index % 2 == 0)
                        {
                            if (index == 0)
                            {
                                evenSum = (digit- 48);
                            }
                            else
                            {
                                evenSum +=  (digit - 48);
                            }
                        }

                    index++;
                        product *= evenSum;
                }
                //

                product /= evenSum;

                if (i != 9)
                {
                    number = product.ToString().ToCharArray();
                    if (number.Length == 1 && i < 9)
                    {
                        Console.WriteLine(i + 1);
                        Console.WriteLine(Convert.ToInt32(number[0] - 48));
                        return;
                    }
                }
                else if (i == 9)
                {
                    Console.WriteLine(product);
                    return;
                }
            }

        }
    }
}
