using System;

namespace StructuralPatterns.Examples.Decorator
{
    public class SumProvider : ISumProvider
    {
        public void ConsoleSum(int x, int y)
        {
            var sum = x + y;
            Console.WriteLine(sum);
        }
    }
}
