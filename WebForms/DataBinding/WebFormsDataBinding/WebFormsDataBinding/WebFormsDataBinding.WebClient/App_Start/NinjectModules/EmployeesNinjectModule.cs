using AutoMapper;

using Ninject;
using Ninject.Activation;
using Ninject.Modules;

using WebFormsDataBinding.WebClient.App_Start.AutomapperProfiles;

namespace WebFormsDataBinding.WebClient.App_Start.NinjectModules
{
    public class EmployeesNinjectModule : NinjectModule
    {
        public override void Load()
        {
            this.Bind<IConfigurationProvider>().ToMethod(this.GetConfiguration).InSingletonScope();

            this.Bind<IMapper>().ToMethod(x => x.Kernel.Get<IConfigurationProvider>().CreateMapper()).InSingletonScope();
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