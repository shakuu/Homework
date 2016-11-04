using System.IO;
using System.Reflection;

using Ninject.Modules;
using Ninject.Extensions.Conventions;
using Ninject.Extensions.Factory;

using Services.Factories;
using System.Data.Entity;
using SqlServer;
using Repositories.Contracts;
using Repositories.Base;
using System.Web.Mvc;
using WebClient.Controllers;
using WebClient.NinjectModules;

namespace ConsoleClient.NinjectModules
{
    public class UserMessagesBindings : NinjectModule
    {
        public override void Load()
        {
            this.Kernel.Bind(x =>
                x.FromAssembliesInPath(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location))
                .SelectAllClasses()
                .BindDefaultInterface());

            this.Bind(typeof(IRepository<>)).To(typeof(GenericRepository<>));

            this.Bind<DbContext>().To<MessagesDbContext>().InSingletonScope();

            this.Bind<IUnitOfWorkFactory>().ToFactory().InSingletonScope();
            this.Bind<IUserFactory>().ToFactory().InSingletonScope();
            this.Bind<IDataServiceFactory>().ToFactory().InSingletonScope();

            this.Bind<Controller>().To<HomeController>().Named("Home");
            this.Bind<IControllersFactory>().ToFactory().InSingletonScope();
        }
    }
}
