using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_Substring_In_Text
{
    class Program
    {
        // TODO: 0/ 100

        static void Main()
        {
            // Get Input
            var toFind = Console.ReadLine();

            var inputBuilder = new StringBuilder();

            // Read lines off the console until
            // there is input.
            while (true)
            {
                var input = Console.ReadLine();

                if (input != "")
                {
                    inputBuilder.Append(input);
                }
                else
                {
                    break;
                }
            }

            var toSearch = inputBuilder.ToString();

            var Counter = 0;

            for (int curIndex = 0;
                     curIndex < toSearch.Length;
                     curIndex++)
            {
                // Find the index of the current occurance.
                var indexFound = toSearch
                    .IndexOf(toFind, curIndex);

                if (indexFound < 0)
                {
                    break;
                }
                else
                {
                    Counter++;

                    curIndex = indexFound + 1;
                }
            }

            Console.WriteLine(Counter);
        }
    }
}
