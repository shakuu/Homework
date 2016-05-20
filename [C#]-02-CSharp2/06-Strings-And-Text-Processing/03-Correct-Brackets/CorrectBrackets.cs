using System;

namespace _03_Correct_Brackets
{
    class CorrectBrackets
    {
        static void Main()
        {
            var toCheck = Console.ReadLine();

            var win = "Correct";
            var notwin = "Incorrect";

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
            if (openBrackets==closeBrackets)
            {
                Console.WriteLine(win);
            }
            else
            {
                Console.WriteLine(notwin);
            }
        }
    }
}
