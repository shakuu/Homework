using System;

using Dealership.Common;
using Dealership.Common.Contracts;
using Dealership.CommandHandlers.Contracts;
using Dealership.CommandHandlers;
using Dealership.Contracts;
using Dealership.Engine;
using Dealership.Factories;
using Dealership.Models;

using Ninject;
using Ninject.Extensions.Conventions;
using Ninject.Extensions.Factory;
using Ninject.Modules;

namespace Dealership.NinjectBindings
{
    public class DealershipBindings : NinjectModule
    {
        private const string RegisterUserCommandHandlerName = "RegisterUserCommandHandler";
        private const string LoginCommandHandlerName = "LoginCommandHandler";
        private const string LogoutCommandHandlerName = "LogoutCommandHandler";
        private const string AddVehicleCommandHandlerName = "AddVehicleCommandHandler";
        private const string RemoveVehicleCommandHandlerName = "RemoveVehicleCommandHandler";
        private const string AddCommentCommandHandlerName = "AddCommentCommandHandler";
        private const string RemoveCommentCommandHandlerName = "RemoveCommentCommandHandler";
        private const string ShowUsersCommandHandlerName = "ShowUsersCommandHandler";
        private const string ShowVehiclesCommandHandlerName = "ShowVehiclesCommandHandler";
        private const string LoggedUserCommandHandlerName = "LoggedUserCommandHandler";

        private const string CarName = "Car";
        private const string MotorcycleName = "Motorcycle";
        private const string TruckName = "Truck";

        public override void Load()
        {
            Kernel.Bind(x =>
                x.FromThisAssembly()
                .SelectAllClasses()
                .BindDefaultInterface()
            );

            this.Bind<Func<string>>().ToMethod(ctx => () =>
            {
                return Console.ReadLine();
            });

            this.Bind<Action<string>>().ToMethod(ctx => (param) =>
            {
                Console.Write(param);
            });

            this.Bind<IIOProvider>().To<GenericIOProvider>();

            this.Bind<IVehicle>().To<Car>().Named(CarName);
            this.Bind<IVehicle>().To<Motorcycle>().Named(MotorcycleName);
            this.Bind<IVehicle>().To<Truck>().Named(TruckName);
            this.Bind<IDealershipFactory>().ToFactory().InSingletonScope();

            this.Bind<ICommandHandler>().To<LoggedUserCommandHandler>().Named(LoggedUserCommandHandlerName);
            this.Bind<ICommandHandler>().To<RegisterUserCommandHandler>().Named(RegisterUserCommandHandlerName);
            this.Bind<ICommandHandler>().To<LoginCommandHandler>().Named(LoginCommandHandlerName);
            this.Bind<ICommandHandler>().To<LogoutCommandHandler>().Named(LogoutCommandHandlerName);
            this.Bind<ICommandHandler>().To<AddVehicleCommandHandler>().Named(AddVehicleCommandHandlerName);
            this.Bind<ICommandHandler>().To<RemoveVehicleCommandHandler>().Named(RemoveVehicleCommandHandlerName);
            this.Bind<ICommandHandler>().To<AddCommentCommandHandler>().Named(AddCommentCommandHandlerName);
            this.Bind<ICommandHandler>().To<RemoveCommentCommandHandler>().Named(RemoveCommentCommandHandlerName);
            this.Bind<ICommandHandler>().To<ShowUsersCommandHandler>().Named(ShowUsersCommandHandlerName);
            this.Bind<ICommandHandler>().To<ShowVehiclesCommandHandler>().Named(ShowVehiclesCommandHandlerName);

            this.Bind<ICommandHandler>().ToMethod(ctx =>
            {
                var loggedUserHandler = ctx.Kernel.Get<ICommandHandler>(LoggedUserCommandHandlerName);
                var registerUserHandler = ctx.Kernel.Get<ICommandHandler>(RegisterUserCommandHandlerName);
                var loginHandler = ctx.Kernel.Get<ICommandHandler>(LoginCommandHandlerName);
                var logoutHandler = ctx.Kernel.Get<ICommandHandler>(LogoutCommandHandlerName);
                var addVehicleHandler = ctx.Kernel.Get<ICommandHandler>(AddVehicleCommandHandlerName);
                var removeVehicleHandler = ctx.Kernel.Get<ICommandHandler>(RemoveVehicleCommandHandlerName);
                var addCommnentHandler = ctx.Kernel.Get<ICommandHandler>(AddCommentCommandHandlerName);
                var removeCommentHandler = ctx.Kernel.Get<ICommandHandler>(RemoveCommentCommandHandlerName);
                var showUsersHandler = ctx.Kernel.Get<ICommandHandler>(ShowUsersCommandHandlerName);
                var showVehiclesHandler = ctx.Kernel.Get<ICommandHandler>(ShowVehiclesCommandHandlerName);

                loggedUserHandler.AddCommandHandler(registerUserHandler);
                registerUserHandler.AddCommandHandler(loginHandler);
                loginHandler.AddCommandHandler(logoutHandler);
                logoutHandler.AddCommandHandler(addVehicleHandler);
                addVehicleHandler.AddCommandHandler(removeVehicleHandler);
                removeVehicleHandler.AddCommandHandler(addCommnentHandler);
                addCommnentHandler.AddCommandHandler(removeCommentHandler);
                removeCommentHandler.AddCommandHandler(showUsersHandler);
                showUsersHandler.AddCommandHandler(showVehiclesHandler);

                return registerUserHandler;
            })
            .WhenInjectedInto<DealershipEngine>()
            .InSingletonScope();

            this.Bind<IEngine>().To<DealershipEngine>().InSingletonScope();
        }
    }
}
