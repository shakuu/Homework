using System;
using System.Collections.Generic;

namespace Problem05.RemoveNegativeValues
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

            var outputValues = new LinkedList<int>();
            foreach (var value in inputValues)
            {
                if (0 <= value)
                {
                    outputValues.AddLast(value);
                }
            }

            Console.WriteLine(string.Join(Environment.NewLine, outputValues));
        }
    }
}
