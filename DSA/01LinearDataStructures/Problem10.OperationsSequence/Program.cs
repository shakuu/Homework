using System;
using System.Collections.Generic;

namespace Problem10.OperationsSequence
{
    public class Program
    {
        public static void Main()
        {
            var initialValue = int.Parse(Console.ReadLine());
            var targetValue = int.Parse(Console.ReadLine());

            var currentResult = initialValue;
            var eligibleOperations = 3;
            var results = new Stack<int>();
            var operations = new Stack<int>();
            var operationsCountHistory = new Stack<int>();
            var operationsCount = int.MaxValue;
            var currentOperationsCount = 0;

            results.Push(initialValue);
            operations.Push(2);
            operationsCountHistory.Push(0);

            var brachesCount = 3;
            while (brachesCount > 0)
            {
                if (eligibleOperations == 3)
                {
                    currentResult *= 2;
                }
                else if (eligibleOperations == 2)
                {
                    currentResult += 2;
                }
                else if (eligibleOperations == 1)
                {
                    currentResult += 1;
                }

                currentOperationsCount++;

                if (currentResult < targetValue)
                {
                    results.Push(currentResult);
                    operations.Push(eligibleOperations - 1);
                    operationsCountHistory.Push(currentOperationsCount);
                    eligibleOperations = 3;
                }
                else
                {
                    if (currentResult == targetValue && currentOperationsCount < operationsCount)
                    {
                        operationsCount = currentOperationsCount;
                    }

                    currentResult = results.Pop();
                    eligibleOperations = operations.Pop();
                    currentOperationsCount = operationsCountHistory.Pop();

                    while (eligibleOperations == 0 && results.Count > 0)
                    {
                        currentResult = results.Pop();
                        eligibleOperations = operations.Pop();
                        currentOperationsCount = operationsCountHistory.Pop();
                    }

                    if (results.Count == 0)
                    {
                        brachesCount--;
                    }
                }
            }

            Console.WriteLine($"Number of Operations: {operationsCount}");
        }
    }
}

