
namespace _05_Bad_Cat_5
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    class Program
    {
        static bool[] isUsed = new bool[10];

        static bool[,] Graph = new bool[10, 10]; // number, children ( after )

        static void Input()
        {
            var linesOfInput = int.Parse(Console.ReadLine());

            for (int line = 0; line < linesOfInput; line++)
            {
                var curInput = Console.ReadLine();

                // Get numbers. 
                var digits = curInput
                    .Trim()
                    .Split(' ')
                    .Where(x => char.IsDigit(x[0]))
                    .Select(int.Parse)
                    .ToArray();

                var isBefore = curInput
                    .Trim()
                    .Split(' ')
                    .Where(x => x[0] == 'a' || x[0] == 'b')
                    .Select(x => x[0] == 'b' ? true : false)
                    .ToArray();

                if (isBefore[0])
                {
                    // Mark [0] as parent of [1]
                    FillArrays(digits[0], digits[1]);
                }
                else
                {
                    FillArrays(digits[1], digits[0]);
                }
            }
        }

        static void FillArrays(int isBefore, int isAfter)
        {
            isUsed[isBefore] = true;
            isUsed[isAfter] = true;

            // Mark parents/ children
            Graph[isBefore, isAfter] = true;
        }

        static string Output()
        {
            var output = new StringBuilder();

            var resultLength = isUsed.Where(x => x == true).Count();

            for (int curDigit = 0; curDigit < resultLength; curDigit++)
            {
                for (int digit = 0; digit < isUsed.Length; digit++)
                {
                    if (digit == 0 && curDigit == 0) continue;
                    
                    // If the current digit 
                    // 1. Has not been used yet
                    // 2. Is not marked as a child of another digit
                    // ( is not marked as AFTER another digit )
                    if (isUsed[digit] && NoParents(digit))
                    {
                        output.Append(digit);

                        UnFillArrays(digit);
                        break;
                    }
                }
            }

            return output.ToString();
        }

        static bool NoParents(int child)
        {
            // If the current digit is marked as a child 
            // of any other digits
            for (int parent = 0; parent < 10; parent++)
            {
                if (Graph[parent, child])
                {
                    return false;
                }
            }

            return true;
        }

        static void UnFillArrays(int digit)
        {
            isUsed[digit] = false;

            // Remove all children 
            // from the element
            // as it is already in use.
            for (int i = 0; i < 10; i++)
            {
                Graph[digit, i] = false;
            }
        }

        static void Main()
        {
            Input();
            Console.WriteLine(Output());
        }
    }
}
