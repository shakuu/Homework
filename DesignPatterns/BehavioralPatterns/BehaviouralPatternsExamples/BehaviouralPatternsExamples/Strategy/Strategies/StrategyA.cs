using Strategy.Strategies.Contracts;
using System;

namespace Strategy.Strategies
{
    public class StrategyA : IStrategy
    {
        public string ImplementedStrategy()
        {
            return "StrategyA implements specific logic";
        }
    }
}
