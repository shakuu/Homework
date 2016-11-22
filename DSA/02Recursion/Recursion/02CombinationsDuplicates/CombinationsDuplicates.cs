using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02CombinationsDuplicates
{
    public class CombinationsDuplicates
    {
        public static void Main()
        {
            var loopsCount = int.Parse(Console.ReadLine());
            var combinationLength = int.Parse(Console.ReadLine());

            var numbers = Enumerable.Range(0, combinationLength).Select(x => 1).ToArray();

            CombinationsDuplicates.LoopWrite(numbers, combinationLength, loopsCount);
        }

        private static void LoopWrite(int[] range, int current, int count)
        {
            for (int i = 0; i < count; i++)
            {
                if (current > 1)
                {
                    CombinationsDuplicates.LoopWrite(range, current - 1, count);
                }
                else
                {
                    Console.WriteLine(string.Join(" ", range));
                }

                range[range.Length - current]++;
            }

            range[range.Length - current] = 1;
        }
    }
}
