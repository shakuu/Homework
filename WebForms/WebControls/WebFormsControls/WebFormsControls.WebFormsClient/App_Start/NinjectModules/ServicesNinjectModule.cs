using Ninject.Modules;

using WebFormsControls.Calculator.CalculatorServices.Contracts;
using WebFormsControls.Calculator.CalculatorServices;

namespace WebFormsControls.WebFormsClient.App_Start.NinjectModules
{
    public class ServicesNinjectModule : NinjectModule
    {
        public override void Load()
        {
            this.Bind<ICalculatorService>().To<CalculatorService>();
        }
    }
}