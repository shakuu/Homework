using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModifyBitBITWISE
{
    class ModifyBitBITWISE
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            
            int position = int.Parse(Console.ReadLine());
            int bitValue = int.Parse(Console.ReadLine());
            int mask;
            int result;

            if (number == 0)
            {
                number++;
                result = number << position; ;
            }
            else if (bitValue == 1 && (number >> position) % 2 == 1)
            {
                mask = 0 << position;
                result = number ^ mask;
            }
            else if (bitValue == 0 && (number >> position) % 2 == 0)
            {
                mask = 0 << position;
                result = number ^ mask;
            }
            else 
            {
                mask = 1 << position;
                result = number ^ mask;
            }

            Console.WriteLine(result);
        }
    }
}
