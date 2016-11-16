using System;
using System.Collections.Generic;

namespace Problem02.ReverseWithStack
{
    public class Program
    {
        public static void Main()
        {
            var inputList = new Stack<int>();
            while (true)
            {
                var nextInputLine = Console.ReadLine();
                if (string.IsNullOrEmpty(nextInputLine))
                {
                    break;
                }

                int nextValue;
                var isParsed = int.TryParse(nextInputLine, out nextValue);
                if (isParsed)
                {
                    inputList.Push(nextValue);
                }
            }

            var outputList = new LinkedList<int>();
            while (inputList.Count > 0)
            {
                outputList.AddLast(inputList.Pop());
            }

            Console.WriteLine(string.Join(Environment.NewLine, outputList));
        }
    }
}
