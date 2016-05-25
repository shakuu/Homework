
namespace _05_Bad_Cat
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    class BadCat
    {
        static void Main()
        {
            var before = "before";
            var after = "after";

            var inputLines = int.Parse(Console.ReadLine());

            var output = "";

            for (int instruction = 0;
                     instruction < inputLines;
                     instruction++)
            {
                // instruction format
                // 1 is before 2
                var curLine = Console.ReadLine()
                    .Trim()
                    .Split(' ')
                    .ToArray();

                var leftNumber = curLine[0];
                var rightNumber = curLine[3];

                var position = curLine[2];

                var leftNumberPosition = output.IndexOf(leftNumber);
                var rightNumberPosition = output.IndexOf(rightNumber);

                // Both are not found
                if (leftNumberPosition < 0)
                {
                    output = leftNumber + output;
                }

                if (rightNumberPosition < 0)
                {
                    output = rightNumber + output;
                }
                
                // Both are
                if (position == before)
                {
                    AdjustPositions(ref output, leftNumber, rightNumber);
                }
                else if (position == after)
                {
                    AdjustPositions(ref output, rightNumber, leftNumber);
                }
            }

            Console.WriteLine(output);
        }

        static void AdjustPositions(
            ref string output,
                string toLeft, 
                string toRight)
        {
           
            var leftNumberPosition = output.IndexOf(toLeft);
            var rightNumberPosition = output.IndexOf(toRight);

            if (leftNumberPosition < rightNumberPosition)
            {
                return;
            }
            else
            {
                output = output.Remove(rightNumberPosition, toRight.Length);
                leftNumberPosition = output.IndexOf(toLeft);

                if (leftNumberPosition == output.Length-1)
                {
                    output += toRight;
                }
                else
                {
                    output = output.Insert(leftNumberPosition + 1, toRight);
                }
            }
        }
    }
}
