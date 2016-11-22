using System;
using System.Linq;

namespace _01NestedLoops
{
    public class NestedLoops
    {
        public static void Main()
        {
            var loopsCount = int.Parse(Console.ReadLine());
            var numbers = Enumerable.Range(0, loopsCount).Select(x => 1).ToArray();

            NestedLoops.LoopWrite(numbers, loopsCount, loopsCount);
        }

        private static void LoopWrite(int[] range, int current, int count)
        {
            var initial = range[count - current];

            for (int i = 0; i < count; i++)
            {
                if (current > 1)
                {
                    NestedLoops.LoopWrite(range, current - 1, count);
                }
                else
                {
                    Console.WriteLine(string.Join(" ", range));
                }

                range[count - current]++;
            }

            range[count - current] = 1;
        }
    }
}
