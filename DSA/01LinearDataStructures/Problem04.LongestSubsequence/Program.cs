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

            var currentSequence = new List<int>();
            var maximumSequence = new List<int>();
            for (int i = 1; i < inputValues.Count; i++)
            {
                var currentAndPreviousElementsAreEqual = inputValues[i] == inputValues[i - 1];
                if (currentAndPreviousElementsAreEqual)
                {
                    currentSequence.Add(inputValues[i]);
                }
                else
                {
                    if (maximumSequence.Count < currentSequence.Count)
                    {
                        maximumSequence = new List<int>(currentSequence);
                    }

                    currentSequence = new List<int>();
                    currentSequence.Add(inputValues[i]);
                }
            }

            Console.WriteLine(string.Join(", ", maximumSequence));
        }
    }
}
