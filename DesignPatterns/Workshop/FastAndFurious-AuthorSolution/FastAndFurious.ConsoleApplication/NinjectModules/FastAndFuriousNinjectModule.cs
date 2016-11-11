using System;
using System.IO;
using System.Reflection;

using FastAndFurious.ConsoleApplication.Engine;
using FastAndFurious.ConsoleApplication.Engine.Commands;
using FastAndFurious.ConsoleApplication.Engine.Contracts;
using FastAndFurious.ConsoleApplication.Engine.Strategies;

using Ninject;
using Ninject.Extensions.Conventions;
using Ninject.Extensions.Interception.Infrastructure.Language;
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

        private const string DriverCommandName = "DriverCommand";
        private const string TuningCommandName = "TuningCommand";
        private const string VehicleCommandName = "VehicleCommand";

        public override void Load()
        {
            this.Kernel.Bind(ctx =>
                ctx.FromAssembliesInPath(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location))
                    .SelectAllClasses()
                    .BindDefaultInterface());

            this.Bind<IAssigningCommand>().To<DriverCommand>().Named(DriverCommandName);
            this.Bind<IAssigningCommand>().To<TuningCommand>().Named(TuningCommandName);
            this.Bind<IAssigningCommand>().To<VehicleCommand>().Named(VehicleCommandName);
            this.Bind<ICommand>().To<ComposedAssigningCommand>()
                .WhenInjectedInto<AssigningStrategy>().InSingletonScope();

            this.Bind<IStrategyChainOfResponsibility>().To<CreationStrategy>().Named(CreationStrategyName);
            this.Bind<IStrategyChainOfResponsibility>().To<RemovalStrategy>().Named(RemovalStrategyName);
            this.Bind<IStrategyChainOfResponsibility>().To<AssigningStrategy>().Named(AssigningStrategyName);
            this.Bind<IStrategyChainOfResponsibility>().To<SelectingStrategy>().Named(SelectingStrategyName);
            this.Bind<IStrategyChainOfResponsibility>().To<RunningStrategy>().Named(RunningStrategyName);
            this.Bind<IStrategyChainOfResponsibility>().To<DisplayingStrategy>().Named(DisplayingStrategyName);
            this.Bind<IStrategy>().ToMethod(ctx =>
            {
                var creationStrategy = this.Kernel.Get<IStrategyChainOfResponsibility>(CreationStrategyName);
                var removalStrategy = this.Kernel.Get<IStrategyChainOfResponsibility>(RemovalStrategyName);
                var assigningStrategy = this.Kernel.Get<IStrategyChainOfResponsibility>(AssigningStrategyName);
                var selectingStrategy = this.Kernel.Get<IStrategyChainOfResponsibility>(SelectingStrategyName);
                var runningStrategy = this.Kernel.Get<IStrategyChainOfResponsibility>(RunningStrategyName);
                var displayingStrategy = this.Kernel.Get<IStrategyChainOfResponsibility>(DisplayingStrategyName);

                creationStrategy.SetNextStrategy(removalStrategy);
                removalStrategy.SetNextStrategy(assigningStrategy);
                assigningStrategy.SetNextStrategy(selectingStrategy);
                selectingStrategy.SetNextStrategy(runningStrategy);
                runningStrategy.SetNextStrategy(displayingStrategy);

                return creationStrategy;
            })
            .WhenInjectedInto<Engine.Engine>()
            .InSingletonScope();

            this.Kernel.InterceptReplace<InterceptedInputOutputProvider>(p => p.ReadLine(), invocation => invocation.ReturnValue = Console.ReadLine());
            this.Kernel.InterceptReplace<InterceptedInputOutputProvider>(p => p.WriteLine(null), invocation =>
                        {
                            Console.WriteLine(string.Join(",", invocation.Request.Arguments));
                        });

            this.Bind<IInputOutputProvider>().To<InterceptedInputOutputProvider>()
                .WhenInjectedInto<Engine.Engine>();
        }
    }
}
