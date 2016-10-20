using System.Reflection;

using Ninject;

using ADONET.Homework.Logic.Models;
using ADONET.Homework.Logic.QueryEngines.Contract;
using ADONET.Homework.Logic.CommandProviders.Contracts;

namespace ADONET.Homework.ConsoleClient
{
    public class Program
    {
        public static void Main()
        {
            var ninject = new StandardKernel();
            ninject.Load(Assembly.GetExecutingAssembly());

            var commandProvider = ninject.Get<ICommandProvider>();
            var command = commandProvider.CreateCommand("SELECT * FROM Categories", null);

            var queryEngine = ninject.Get<IQueryEngine>();
            queryEngine.ExecuteCommand<Category>(command);
        }
    }
}
