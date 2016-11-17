using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem09.QueueSequence
{
    public class Program
    {
        public static void Main()
        {
            var initialValue = int.Parse(Console.ReadLine());

            var sequence = new Queue<int>();
            sequence.Enqueue(initialValue);

            // value + 1
            // value * 2 + 1
            // value + 2

            var resultingSequence = new List<int>();
            resultingSequence.Add(initialValue);
            while (resultingSequence.Count < 50)
            {
                var nextValue = sequence.Dequeue();

                var firstOperation = nextValue + 1;
                sequence.Enqueue(firstOperation);

                var secondOperation = (nextValue * 2) + 1;
                sequence.Enqueue(secondOperation);

                var thirdOperation = nextValue + 2;
                sequence.Enqueue(thirdOperation);

                resultingSequence.AddRange(new[]
                {
                    firstOperation,
                    secondOperation,
                    thirdOperation
                });
            }

            Console.WriteLine(string.Join(Environment.NewLine, resultingSequence.Take(50)));
        }
    }
}
