
namespace _05_Cat_Ate_It_Again
{
    using System;
    using System.Linq;
    using System.Text;

    class TheCatAteItAgain
    {
        static bool[] DigitsInUse = new bool[10];
        // Wait List for each digit. 
        // For each digit mark every other digit before it ( it has to wait for)
        // Strike each digit out of each other digits Wait List.
        static bool[,] WaitList = new bool[10, 10];

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

                // X Before Y
                if (instructions[1] == 1)
                {
                    EnterInput(
                        instructions[2],
                        instructions[0]);
                }
                // X After Y
                else
                {
                    EnterInput(
                        instructions[0],
                        instructions[2]);
                }
            }
        }

        static void EnterInput(int before, int after)
        {
            DigitsInUse[before] = true;
            DigitsInUse[after] = true;

            WaitList[before, after] = true;
        }

        static string Output()
        {
            var output = new StringBuilder();

            var numberOfDigits = DigitsInUse.Where(x => x == true).Count();

            for (int curDigit = 0; curDigit < numberOfDigits; curDigit++)
            {
                for (int digit = 0; digit < 10; digit++)
                {
                    if (digit == 0 && curDigit == 0) continue;

                    if (DigitsInUse[digit] && !isWaiting(digit))
                    {
                        output.Append(digit);
                        CleanUp(digit);
                        break;
                    }
                }
            }

            return output.ToString() ;
        }

        static void CleanUp(int digit)
        {
            DigitsInUse[digit] = false;

            for (int curDigit = 0; curDigit < 10; curDigit++)
            {
                WaitList[curDigit, digit] = false;
            }
        }

        static bool isWaiting(int digit)
        {
            for (int curDigit = 0; curDigit < 10; curDigit++)
            {
                if (WaitList[digit, curDigit]) return true;
            }

            return false;
        }

        static void Main()
        {
            Input();
            Console.WriteLine(Output());
        }
    }
}
