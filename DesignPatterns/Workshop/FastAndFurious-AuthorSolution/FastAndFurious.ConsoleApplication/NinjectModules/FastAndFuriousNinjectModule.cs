using System.IO;
using System.Reflection;

using FastAndFurious.ConsoleApplication.Engine;
using FastAndFurious.ConsoleApplication.Engine.Contracts;
using FastAndFurious.ConsoleApplication.Engine.Strategies;

using Ninject;
using Ninject.Extensions.Conventions;
using Ninject.Modules;

namespace FastAndFurious.ConsoleApplication.NinjectBindings
{
    public class FastAndFuriousNinjectModule : NinjectModule
    {
        private const string CreationStrategyName = "CreationStrategy";
        private const string RemovalStrategyName = "RemovalStrategy";
        private const string AssigningStrategyName = "AssigningStrategy";
        private const string SelectingStrategyName = "SelectingStrategy";
        private const string RunningStrategyName = "RunningStrategy";
        private const string DisplayingStrategyName = "DisplayingStrategy";

        public override void Load()
        {
            this.Kernel.Bind(ctx =>
                ctx.FromAssembliesInPath(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location))
                    .SelectAllClasses()
                    .BindDefaultInterface());

            this.Bind<IStrategy>().To<CreationStrategy>().Named(CreationStrategyName);
            this.Bind<IStrategy>().To<RemovalStrategy>().Named(RemovalStrategyName);
            this.Bind<IStrategy>().To<AssigningStrategy>().Named(AssigningStrategyName);
            this.Bind<IStrategy>().To<SelectingStrategy>().Named(SelectingStrategyName);
            this.Bind<IStrategy>().To<RunningStrategy>().Named(RunningStrategyName);
            this.Bind<IStrategy>().To<DisplayingStrategy>().Named(DisplayingStrategyName);
            this.Bind<IStrategy>().ToMethod(ctx =>
            {
                var creationStrategy = this.Kernel.Get<IStrategy>(CreationStrategyName);
                var removalStrategy = this.Kernel.Get<IStrategy>(RemovalStrategyName);
                var assigningStrategy = this.Kernel.Get<IStrategy>(AssigningStrategyName);
                var selectingStrategy = this.Kernel.Get<IStrategy>(SelectingStrategyName);
                var runningStrategy = this.Kernel.Get<IStrategy>(RunningStrategyName);
                var displayingStrategy = this.Kernel.Get<IStrategy>(DisplayingStrategyName);

                ((IStrategyChainOfResponsibility)creationStrategy).SetNextStrategy(removalStrategy);
                ((IStrategyChainOfResponsibility)removalStrategy).SetNextStrategy(assigningStrategy);
                ((IStrategyChainOfResponsibility)assigningStrategy).SetNextStrategy(selectingStrategy);
                ((IStrategyChainOfResponsibility)selectingStrategy).SetNextStrategy(runningStrategy);
                ((IStrategyChainOfResponsibility)runningStrategy).SetNextStrategy(displayingStrategy);

                return creationStrategy;
            })
            .WhenInjectedInto<Engine.Engine>()
            .InSingletonScope();

            this.Bind<IInputOutputProvider>().To<ConsoleInputOutputProvider>()
                .WhenInjectedInto<Engine.Engine>();
        }
    }
}
