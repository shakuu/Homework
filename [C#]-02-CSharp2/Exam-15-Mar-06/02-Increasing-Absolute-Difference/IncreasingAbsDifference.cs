
namespace _02_Increasing_Absolute_Difference
{
    using System;
    using System.Linq;

    class IncreasingAbsDifference
    {
        static void Main()
        {
            var separators = @" .,~!@#$%^&*()_+=?/\";

            var inputLines = int.Parse(Console.ReadLine());

            for (int i = 0; i < inputLines; i++)
            {
                var curCatSequence = Console
                    .ReadLine()
                    .Trim()
                    .Split(
                        separators.ToCharArray(),
                        StringSplitOptions.RemoveEmptyEntries)
                    .Select(long.Parse)
                    .ToArray();

                Console.WriteLine(isCatSequence(curCatSequence));
            }
        }

        static bool isCatSequence(long[] CatNumbers)
        {
            var prevDif = Math.Abs(CatNumbers[1] - CatNumbers[0]);

            for (int cat = 1;
                     cat < CatNumbers.Length;
                     cat++)
            {
                var curDif = Math.Abs(CatNumbers[cat] - CatNumbers[cat - 1]);

                if (!(curDif - prevDif >= 0 && 
                      curDif - prevDif <= 1))
                {
                    return false;
                }

                prevDif = Math.Abs(CatNumbers[cat] - CatNumbers[cat - 1]);
            }

            return true;
        }
    }
}
