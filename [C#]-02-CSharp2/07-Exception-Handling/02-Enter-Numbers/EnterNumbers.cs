using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_Enter_Numbers
{
    class EnterNumbers
    {
        static string exceptionMessage = "Exception";

        static void Main()
        {
            var start = 0;
            var end = 100;

            ReadNumber(start, end);
        }

        static void ReadNumber(int start, int end)
        {
            var elementsToAdd = 10;

            var join = " < ";

            var output = new StringBuilder();

            var prevNumber = start;

            // Add first element.
            output.Append(start);
            output.Append(join);

            // Add Input.
            for (int element = 0; 
                     element < elementsToAdd; 
                     element++)
            {
                try
                {
                    var numberToAdd = int.Parse(Console.ReadLine());

                    if (prevNumber < numberToAdd)
                    {
                        output.Append(numberToAdd);
                        output.Append(join);
                    }
                    else
                    {
                        throw new Exception(exceptionMessage);
                    }

                    prevNumber = numberToAdd;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    return;
                }
            }

            // Add last element.
            output.Append(end);

            Console.WriteLine(output);
        }
    }
}
