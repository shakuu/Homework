using System;

namespace StructuralPatterns.Examples.Decorator
{
    public class SumProvider : ISum
    {
        public void ConsoleSum(int x, int y)
        {
            var sum = x + y;
            Console.WriteLine(sum);
        }
    }
}
