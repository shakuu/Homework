using System;

namespace StructuralPatterns.Examples.Facade
{
    public class WorkerTypeB
    {
        public void Work()
        {
            Console.WriteLine("Worker B doing it's part");
        }

        public void MoreRelatedWork()
        {
            Console.WriteLine("Worker B doing more work");
        }
    }
}
