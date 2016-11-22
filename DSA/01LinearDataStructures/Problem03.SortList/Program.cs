using System;
using System.Collections.Generic;

namespace Problem03.SortList
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

            for (int i = 0; i < inputValues.Count - 1; i++)
            {
                for (int j = i + 1; j < inputValues.Count; j++)
                {
                    if (inputValues[i] > inputValues[j])
                    {
                        inputValues[i] ^= inputValues[j];
                        inputValues[j] ^= inputValues[i];
                        inputValues[i] ^= inputValues[j];
                    }
                }
            }

            Console.WriteLine(string.Join(Environment.NewLine, inputValues));
        }
    }
}
