using System;

using Dealership.Common.Contracts;
using Dealership.Common;
using Dealership.CommandHandlers.Contracts;
using Dealership.CommandHandlers;
using Dealership.Engine;
using Dealership.Factories;

using Ninject;
using Ninject.Modules;

namespace Dealership.NinjectBindings
{
    public class DealershipBindings : NinjectModule
    {
        public override void Load()
        {
            this.Bind<IDealershipFactory>().To<DealershipFactory>();
            this.Bind<IIOProvider>().ToMethod(io => new GenericIOProvider(Console.Write, Console.ReadLine));
            this.Bind<ICommandHandler>().ToMethod(ch =>
            {
                var registerUserHandler = new RegisterUserCommandHandler();
                var loginHandler = new LoginCommandHandler();
                var logoutHandler = new LogoutCommandHandler();
                var addVehicleHandler = new AddVehicleCommandHandler();
                var removeVehicleHandler = new RemoveVehicleCommandHandler();
                var addCommnentHandler = new AddCommentCommandHandler();
                var removeCommentHandler = new RemoveCommentCommandHandler();
                var showUsersHandler = new ShowUsersCommandHandler();
                var showVehiclesHandler = new ShowVehiclesCommandHandler();

                registerUserHandler.AddCommandHandler(loginHandler);
                loginHandler.AddCommandHandler(logoutHandler);
                logoutHandler.AddCommandHandler(addVehicleHandler);
                addVehicleHandler.AddCommandHandler(removeVehicleHandler);
                removeVehicleHandler.AddCommandHandler(addCommnentHandler);
                addCommnentHandler.AddCommandHandler(removeCommentHandler);
                removeCommentHandler.AddCommandHandler(showUsersHandler);
                showUsersHandler.AddCommandHandler(showVehiclesHandler);

                return registerUserHandler;
            });

            this.Bind<IEngine>().To<DealershipEngine>().InSingletonScope()
                .WithConstructorArgument("factory", ctx => ctx.Kernel.Get<IDealershipFactory>())
                .WithConstructorArgument("uiProvider", ctx => ctx.Kernel.Get<IIOProvider>())
                .WithConstructorArgument("commandHandler", ctx => ctx.Kernel.Get<ICommandHandler>());
        }
    }
}
