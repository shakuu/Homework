using System.Reflection;

using Application.Services;

using Ninject;

namespace ConsoleClient
{
    public class Program
    {
        public static void Main()
        {
            var ninject = new StandardKernel();
            ninject.Load(Assembly.GetExecutingAssembly());

            var userService = ninject.Get<UsersService>();
            userService.CreateUser("Joe");
        }
    }
}
