using System;

namespace StructuralPatterns.Examples.Decorator
{
    public class DecoratedSumProvider : ISumProvider
    {
        private readonly ISumProvider decoratedSumProvider;

        public DecoratedSumProvider(ISumProvider decoratedSumProvider)
        {
            // An instance of the decorated type.
            this.decoratedSumProvider = decoratedSumProvider;
        }

        public void ConsoleSum(int x, int y)
        {
            // Add functionality.
            Console.WriteLine("---");
            // Use the functionality provided by the decorated type.
            this.decoratedSumProvider.ConsoleSum(x, y);
            // Add functionality.
            Console.WriteLine("---");
        }
    }
}
