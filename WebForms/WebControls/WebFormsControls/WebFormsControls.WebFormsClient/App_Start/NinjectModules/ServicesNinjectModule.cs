using Ninject.Modules;

using WebFormsControls.Calculator.CalculatorServices.Contracts;
using WebFormsControls.Calculator.CalculatorServices;

using WebFormsControls.TicTacToe.TicTacToeServices.Contracts;
using WebFormsControls.TicTacToe.TicTacToeServices.Strategies;

namespace WebFormsControls.WebFormsClient.App_Start.NinjectModules
{
    public class ServicesNinjectModule : NinjectModule
    {
        public override void Load()
        {
            this.Bind<ICalculatorService>().To<CalculatorService>();

            this.Bind<ITicTacToeStrategy>().To<SimpletonTicTacToeStrategy>().InSingletonScope();
        }
    }
}