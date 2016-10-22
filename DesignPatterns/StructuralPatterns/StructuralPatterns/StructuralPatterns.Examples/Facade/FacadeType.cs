namespace StructuralPatterns.Examples.Facade
{
    public class FacadeType
    {
        private WorkerTypeA workerA;
        private WorkerTypeB workerB;

        public FacadeType(WorkerTypeA workerA, WorkerTypeB workerB)
        {
            this.workerA = workerA;
            this.workerB = workerB;
        }

        public void ComplicatedOperation()
        {
            System.Console.WriteLine("Starting complicated operation:");
            workerA.Work();
            workerB.Work();
            workerB.MoreRelatedWork();
        }
    }
}
