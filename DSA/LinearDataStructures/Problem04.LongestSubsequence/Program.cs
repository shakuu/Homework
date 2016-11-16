using System;
using System.Collections.Generic;

namespace Problem04.LongestSubsequence
{
    public class Program
    {
        public static void Main()
        {
            var inputValues = new List<int>();
            while (true)
            {
                var nextLine = Console.ReadLine();
                if (string.IsNullOrEmpty(nextLine))
                {
                    break;
                }

                int nextValue;
                var isParsed = int.TryParse(nextLine, out nextValue);
                if (isParsed)
                {
                    inputValues.Add(nextValue);
                }
            }

            var currentSequenceLength = 0;
            var maximumSequenceLength = 0;
            for (int i = 1; i < inputValues.Count; i++)
            {
                var currentAndPreviousElementsAreEqual = inputValues[i] == inputValues[i - 1];
                if (currentAndPreviousElementsAreEqual)
                {
                    currentSequenceLength++;
                }
                else
                {
                    if (currentSequenceLength > maximumSequenceLength)
                    {
                        maximumSequenceLength = currentSequenceLength;
                    }

                    currentSequenceLength = 0;
                }
            }

            Console.WriteLine($"Maximum length: {maximumSequenceLength}");
        }
    }
}
