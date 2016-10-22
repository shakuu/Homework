using System.Collections.Generic;

using StructuralPatterns.Examples.Composite;
using StructuralPatterns.Examples.Decorator;
using StructuralPatterns.Examples.Facade;

namespace StructuralPatterns.Examples
{
    public class Program
    {
        public static void Main()
        {
            CompositeExample();
            DecoratorExample();
            FacadeExample();
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
            decoratedTypeInstance.ConsoleSum(2, 2);
            decorator.ConsoleSum(1, 1);
        }

        private static void FacadeExample()
        {
            // Use a number of objects to complete a single operation
            // containing different stages through a single method call.
            var workerA = new WorkerTypeA();
            var workerB = new WorkerTypeB();
            var facade = new FacadeType(workerA, workerB);

            facade.ComplicatedOperation();
        }
    }
}
