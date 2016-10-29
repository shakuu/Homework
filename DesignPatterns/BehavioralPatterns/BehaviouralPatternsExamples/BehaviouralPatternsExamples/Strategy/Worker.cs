using Strategy.Strategies.Contracts;

namespace Strategy
{
    public class Worker
    {
        public void DoWork(IStrategy strategy)
        {
            strategy.ImplementedStrategy();
        }
    }
}
