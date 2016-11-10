using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastAndFurious.ConsoleApplication.Engine.Contracts
{
    public interface ICommand
    {
        bool IsCommand(IList<string> commandParameters);

        void ExecuteCommand();
    }
}
