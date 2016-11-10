using System;
using System.Collections.Generic;

using FastAndFurious.ConsoleApplication.Engine.Contracts;

namespace FastAndFurious.ConsoleApplication.Engine
{
    public abstract class Strategy : IStrategy, IStrategyChainOfResponsibility
    {
        private IStrategy nextStrategy;

        public void Execute(IList<string> commandParameters, IEngine engine)
        {
            if (this.CanExecute(commandParameters))
            {
                this.ExecuteCommand(commandParameters, engine);
            }

            if (this.nextStrategy != null)
            {
                this.nextStrategy.Execute(commandParameters, engine);
            }

            throw new InvalidOperationException();
        }

        public void SetNextStrategy(IStrategy strategy)
        {
            this.nextStrategy = strategy;
        }

        protected abstract bool CanExecute(IList<string> commandParameters);

        protected abstract bool ExecuteCommand(IList<string> commandParameters, IEngine engine);
    }
}
