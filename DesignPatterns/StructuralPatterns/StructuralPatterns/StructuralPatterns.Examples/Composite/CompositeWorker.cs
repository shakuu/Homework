using System.Collections.Generic;

namespace StructuralPatterns.Examples.Composite
{
    public class CompositeWorker : IWorker
    {
        private ICollection<IWorker> composition;

        public CompositeWorker(ICollection<IWorker> composition)
        {
            this.composition = composition;
        }

        public void DoWork()
        {
            foreach (var worker in composition)
            {
                System.Console.WriteLine("composite worker call:");
                worker.DoWork();
            }
        }
    }
}
