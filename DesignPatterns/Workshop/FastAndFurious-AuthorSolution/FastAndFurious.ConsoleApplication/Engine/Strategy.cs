using System;
using System.Collections.Generic;

using FastAndFurious.ConsoleApplication.Engine.Contracts;

namespace FastAndFurious.ConsoleApplication.Engine
{
    public abstract class Strategy : IStrategy, IStrategyChainOfResponsibility
    {
        private IStrategy nextStrategy;

        public void Execute(IList<string> commandParameters, IEngineCollections engineCollections)
        {
            if (this.CanExecute(commandParameters))
            {
                this.ExecuteCommand(commandParameters, engineCollections);
            }

            if (this.nextStrategy != null)
            {
                this.nextStrategy.Execute(commandParameters, engineCollections);
            }

            throw new InvalidOperationException();
        }

        public void SetNextStrategy(IStrategy strategy)
        {
            this.nextStrategy = strategy;
        }

        protected abstract bool CanExecute(IList<string> commandParameters);

        protected abstract bool ExecuteCommand(IList<string> commandParameters, IEngineCollections engineCollections);
    }
}
