
namespace _02_Even_Differences
{
    using System;
    using System.Linq;
    using System.Numerics;

    class EvenDifferences
    {
        static void Main()
        {
            // Get the Input 
            var input = Console.ReadLine()
                .Trim()
                .Split(' ')
                .Select(BigInteger.Parse)
                .ToArray();

            // Start at Index 1 per definition
            var inputSize = input.Length;
            var startIndex = 1;

            BigInteger outputSum = 0;

            for (int curIndex = startIndex; 
                     curIndex < inputSize; 
                     curIndex++)
            {
                var absoluteDifference = BigInteger.Parse(
                     (input[curIndex] - input[curIndex - 1])
                     .ToString().Replace("-", string.Empty));

                // Default step is ONE -> Odd jump
                // If even jump increment index by 1 
                if ((absoluteDifference & 1) == 0)
                {
                    curIndex++;
                    outputSum += absoluteDifference;
                }
            }

            Console.WriteLine(outputSum);
        }
    }
}
