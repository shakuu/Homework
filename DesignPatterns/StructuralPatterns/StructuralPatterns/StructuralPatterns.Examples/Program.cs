using System.Collections.Generic;

using StructuralPatterns.Examples.Composite;
using StructuralPatterns.Examples.Decorator;

namespace StructuralPatterns.Examples
{
    public class Program
    {
        public static void Main()
        {
            CompositeExample();
            DecoratorExample();
        }

        private static void CompositeExample()
        {
            var workersComposition = new List<IWorker>()
            {
                new Worker(),
                new Worker(),
                new Worker()
            };

            var compositeWorker = new CompositeWorker(workersComposition);
            var worker = new Worker();

            // The client will treat a single a worker and a composition of workers
            // the same way, through a single interface method call.
            var client = new WorkerClient();
            // Use collection of workers.
            client.UseWorker(compositeWorker);
            // Use a single worker.
            client.UseWorker(worker);
        }

        private static void DecoratorExample()
        {
            var decoratedTypeInstance = new SumProvider();
            // Inject the instance into the decorator.
            var decorator = new DecoratedSumProvider(decoratedTypeInstance);
            // Decorator implements the same interface.
            decorator.ConsoleSum(1, 1);
        }
    }
}
