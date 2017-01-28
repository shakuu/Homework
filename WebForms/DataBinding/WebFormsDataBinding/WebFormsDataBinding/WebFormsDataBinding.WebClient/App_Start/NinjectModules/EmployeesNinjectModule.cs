using AutoMapper;

using Ninject;
using Ninject.Activation;
using Ninject.Extensions.Conventions;
using Ninject.Modules;

using WebFormsDataBinding.Employees;
using WebFormsDataBinding.Employees.Services;
using WebFormsDataBinding.Employees.Services.Contracts;

using WebFormsDataBinding.WebClient.App_Start.AutomapperProfiles;

namespace WebFormsDataBinding.WebClient.App_Start.NinjectModules
{
    public class EmployeesNinjectModule : NinjectModule
    {
        public override void Load()
        {
            this.Kernel.Bind(x => x.FromAssemblyContaining<IEmployeesService>().SelectAllClasses().BindDefaultInterface());

            this.Bind<NorthwindEntities>().ToSelf().InSingletonScope();

            this.Bind<IConfigurationProvider>().ToMethod(this.GetConfiguration).InSingletonScope();

            this.Bind<IMapper>().ToMethod(x => x.Kernel.Get<IConfigurationProvider>().CreateMapper()).InSingletonScope();

            this.Rebind<IEmployeesService>().To<EmployeesService>().InSingletonScope();
        }

        private IConfigurationProvider GetConfiguration(IContext ctx)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new EmployeesProfile());
            });

            return config;
        }
    }
}