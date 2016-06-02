
namespace _05_The_Cat_Ate_It
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    class TheCatAteIt
    {
        static bool[] DigitsInUse = new bool[10];
        // Digit, Digits after this digit.
        // For each digit check that no other digit has it marked as after it.
        static bool[,] MarkParents = new bool[10, 10];

        static void Input()
        {
            var numberOfInstructions = int.Parse(Console.ReadLine());

            for (int line = 0;
                     line < numberOfInstructions;
                     line++)
            {
                //  0 -> Number 1 
                //  1 -> 1 Before, 0 After
                //  2 -> Number 2
                var instructions = Console.ReadLine()
                    .Trim()
                    .Split(' ')
                    .Where(x => char.IsDigit(x[0]) || (x[0] == 'a' || x[0] == 'b'))
                    .Select(x => !char.IsDigit(x[0]) ? Convert.ToString((int)x[0] - 'a') : x)
                    .Select(int.Parse)
                    .ToArray();

                if (instructions[1] == 1)
                {
                    EnterInput(
                        instructions[0],
                        instructions[2]);
                }
                else
                {
                    EnterInput(
                        instructions[2],
                        instructions[0]);
                }
            }
        }

        static void EnterInput(int before, int after)
        {
            DigitsInUse[before] = true;
            DigitsInUse[after] = true;

            MarkParents[before, after] = true;
        }

        static string Output()
        {
            var outputNumber = new StringBuilder();

            var numberOfDigits = DigitsInUse
                .Where(x => x == true)
                .Count();

            for (int digit = 0;
                     digit < numberOfDigits;
                     digit++)
            {
                for (int curDigit = 0;
                         curDigit < 10;
                         curDigit++)
                {
                    // Skip zero on first position
                    if (curDigit == 0 && digit == 0)
                        continue;

                    if (DigitsInUse[curDigit] &&
                        !HasDigitsBefore(curDigit))
                    {
                        outputNumber.Append(curDigit);
                        CleanUp(curDigit);

                        // Next Digit
                        break;
                    }
                }
            }

            return outputNumber.ToString();
        }

        static bool HasDigitsBefore(int curDigit)
        {
            for (int digit = 0; digit < 10; digit++)
            {
                if (MarkParents[digit, curDigit])
                    return true;
            }

            return false;
        }

        static void CleanUp(int curDigit)
        {
            DigitsInUse[curDigit] = false;

            for (int digit = 0; digit < 10; digit++)
            {
                MarkParents[curDigit, digit] = false;
            }
        }

        static void Main()
        {
            Input();
            Console.WriteLine(Output());
        }
    }
}
