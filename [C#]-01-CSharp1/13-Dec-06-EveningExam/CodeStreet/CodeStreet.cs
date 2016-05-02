using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeStreet
{
    class CodeStreet
    {
        static void Main()
        {
            string inputText = Console.ReadLine();
            long index = 0;
            long counter = 0;
            long sum = 0;
            foreach(char digit in inputText)
            {
                if (index%2 !=0)
                {
                    if (digit >= '0' && digit <= '9')
                    {
                        counter++;
                        sum += digit - '0';
                    }
                }
                index++;
            }

            Console.WriteLine("{0} {1}", counter, sum);
        }
    }
}
