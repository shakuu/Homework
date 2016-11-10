using System.Collections.Generic;

namespace FastAndFurious.ConsoleApplication.Engine.Contracts
{
    public interface IStrategy
    {
        void Execute(IList<string> commandParameters, IEngine engine);
    }
}
