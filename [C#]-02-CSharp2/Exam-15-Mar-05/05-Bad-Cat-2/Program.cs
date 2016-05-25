
namespace _05_Bad_Cat_2
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    class Program
    {
        static void Main()
        {
            var numberOfInstructions = int.Parse(Console.ReadLine());

            var instrucitonList = new List<string[]>();

            var output = new List<int>();

            // Get All instrucions.
            // Add all numbers.
            for (int instrinction = 0; instrinction < numberOfInstructions; instrinction++)
            {
                var toAdd = Console.ReadLine()
                    .Trim()
                    .Split(' ')
                    .ToArray();

                instrucitonList.Add(toAdd);

                if (output.IndexOf(int.Parse( toAdd[0])) < 0)
                {
                    output.Add(int.Parse(toAdd[0]));
                }

                if (output.IndexOf(int.Parse(toAdd[3])) < 0)
                {
                    output.Add(int.Parse(toAdd[3]));
                }
            }

            // Sort the list to get the smallest possible number
            output.Sort();

            

            Console.WriteLine(string.Join("", output));
        }

        static void AdjustPositionsBefore(
                List<int> output,
                int Left,
                int Right)
        {

            var leftNumberPosition = output.IndexOf(Left);
            var rightNumberPosition = output.IndexOf(Right);

            

            if (leftNumberPosition < rightNumberPosition)
            {
                return;
            }
            else
            {
                output.RemoveAt(rightNumberPosition);
                output.Insert(leftNumberPosition, Right);

                for (int position = leftNumberPosition - 1; position >= 0; position--)
                {
                    if (true)
                    {

                    }
                }
            }
        }
    }
}
