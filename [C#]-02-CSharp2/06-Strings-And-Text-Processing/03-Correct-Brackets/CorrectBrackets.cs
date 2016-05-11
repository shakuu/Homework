using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_Correct_Brackets
{
    class Program
    {
        static void Main()
        {
            var toCheck = Console.ReadLine();

            // Count opening and closing brackets.
            var openBrackets = 0;
            var closeBrackets = 0;

            foreach (var element in toCheck)
            {
                if (element == '(')
                {
                    openBrackets++;

                    continue;
                }

                if (element == ')')
                {
                    closeBrackets++;

                    continue;
                }
            }

            // Check if each Opening Bracket has a matching 
            // closing bracket - regardless of whether the 
            // expression is correct.
            Console.WriteLine(openBrackets == closeBrackets);
        }
    }
}
