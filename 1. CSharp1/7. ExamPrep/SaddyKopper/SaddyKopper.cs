using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaddyKopper
{
    class SaddyKopper
    {
        static void Main()
        {
            string INPUT = Console.ReadLine();
            char[] number = INPUT.ToCharArray();


            long evenSum;
            long product;


            for (int i = 0; i < 10; i++)
            {
                product = new long();
                //Get EVEN sum, multiply each sum.
                for (int k = 0; k < number.Length - 1; k++)
                {
                    evenSum = new int();
                    for (int p = 0; p < number.Length - k - 1; p++)
                    {
                        if (p % 2 == 0)
                        {
                            if (p == 0)
                            {
                                evenSum = (number[p] - 48);
                            }
                            else
                            {
                                evenSum += (number[p] - 48);
                            }
                        }
                    }

                    if (k == 0)
                    {
                        product = evenSum;
                    }
                    else
                    {
                        product *= evenSum;
                    }
                }
                //

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
