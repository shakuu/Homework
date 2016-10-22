namespace StructuralPatterns.Examples.Composite
{
    public class WorkerClient
    {
        public void UseWorker(IWorker worker)
        {
            worker.DoWork();
        }
    }
}
