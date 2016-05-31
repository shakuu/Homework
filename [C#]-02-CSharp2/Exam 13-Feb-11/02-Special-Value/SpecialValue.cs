
namespace _02_Special_Value
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    class SpecialValue
    {
        private static int[][] input;
        private static int specialNumber;

        static void Input()
        {
            var size = int.Parse(Console.ReadLine());

            input = new int[size][];

            for (int line = 0; line < size; line++)
            {
                input[line] = Console.ReadLine()
                    .Trim()
                    .Split(new[] { ' ', ',' },
                        StringSplitOptions.RemoveEmptyEntries)
                    .Where(x => x != " ")
                    .Select(int.Parse)
                    .ToArray();
            }
        }

        static bool[][] CreateFlags()
        {
            var output = new bool[input.Length][];

            for (int line = 0; line < input.Length; line++)
            {
                output[line] = new bool[input[line].Length];
            }

            return output;
        }
        static void CheckPaths()
        {
            specialNumber = int.MinValue;

            for (int cell = 0; cell < input[0].Length; cell++)
            {
                var sum = 0;
                var row = 0;
                var col = cell;
                var steps = 0;
                var flags = CreateFlags();

                while (true)
                {
                    var cellValue = input[row][col];

                    // Stop on negative number
                    // or checked cell
                    if (cellValue < 0)
                    {
                        sum = steps + 1 + Math.Abs(cellValue);

                        specialNumber = sum > specialNumber ?
                                        sum : specialNumber;

                        break;
                    }
                    else if (flags[row][col])
                    {
                        break;
                    }
                    // Else Move to the next position
                    // in the path.
                    else
                    {
                        flags[row][col] = true;
                        steps++;
                        col = cellValue;
                        row = steps % input.Length;
                    }
                }
            }
        }

        static void Main()
        {
            Input();
            CheckPaths();
            Console.WriteLine(specialNumber);
        }
    }
}
