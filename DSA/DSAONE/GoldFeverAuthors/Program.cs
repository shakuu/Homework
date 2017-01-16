using System;
using System.Linq;

namespace GoldFever
{
    class Program
    {
        static void Main(string[] args)
        {
            int.Parse(Console.ReadLine());
            int[] days = Console.ReadLine().Split().Select(int.Parse).ToArray();

            long sum = 0;
            int currentMax = 0;

            for (int j = days.Length - 1; j > -1; j--)
            {
                if (days[j] > currentMax)
                {
                    currentMax = days[j];
                    continue;
                }

                sum += currentMax - days[j];
            }

            Console.WriteLine(sum);
        }
    }
}