using System.Reflection;

using Ninject;

namespace ADONET.Homework.ConsoleClient
{
    public class Program
    {
        public static void Main()
        {
            var ninject = new StandardKernel();
            ninject.Load(Assembly.GetExecutingAssembly());
        }
    }
}
