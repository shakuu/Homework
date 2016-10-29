using Strategy.Strategies.Contracts;

namespace Strategy.Strategies
{
    public class StrategyB : IStrategy
    {
        public string ImplementedStrategy()
        {
            return @"StrategyB takes the same input parameters and returns the same type of result,
                    but the implementation can be very different.";
        }
    }
}
