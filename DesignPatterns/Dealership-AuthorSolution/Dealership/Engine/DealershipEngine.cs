using System;
using System.Collections.Generic;
using System.Text;

using Dealership.CommandHandlers.Contracts;
using Dealership.Common.Contracts;
using Dealership.Contracts;
using Dealership.Factories;

namespace Dealership.Engine
{
    public sealed class DealershipEngine : IEngine
    {
        private const string InvalidCommand = "Invalid command!";

        private const string UserAlreadyExist = "User {0} already exist. Choose a different username!";
        private const string UserLoggedInAlready = "User {0} is logged in! Please log out first!";
        private const string UserRegisterеd = "User {0} registered successfully!";
        private const string UserNotLogged = "You are not logged! Please login first!";
        private const string NoSuchUser = "There is no user with username {0}!";
        private const string UserLoggedOut = "You logged out!";
        private const string UserLoggedIn = "User {0} successfully logged in!";
        private const string WrongUsernameOrPassword = "Wrong username or password!";
        private const string YouAreNotAnAdmin = "You are not an admin!";

        private const string CommentAddedSuccessfully = "{0} added comment successfully!";
        private const string CommentRemovedSuccessfully = "{0} removed comment successfully!";

        private const string VehicleRemovedSuccessfully = "{0} removed vehicle successfully!";
        private const string VehicleAddedSuccessfully = "{0} added vehicle successfully!";

        private const string RemovedVehicleDoesNotExist = "Cannot remove comment! The vehicle does not exist!";
        private const string RemovedCommentDoesNotExist = "Cannot remove comment! The comment does not exist!";

        private const string CommentDoesNotExist = "The comment does not exist!";
        private const string VehicleDoesNotExist = "The vehicle does not exist!";
        
        private readonly IDealershipFactory factory;
        private readonly IIOProvider uiProvider;
        private readonly ICommandHandler commandHandler;

        private ICollection<IUser> users;
        private IUser loggedUser;

        public DealershipEngine(
            IDealershipFactory factory,
            IIOProvider uiProvider,
            ICommandHandler commandHandler)
        {
            if (factory == null)
            {
                throw new ArgumentNullException(nameof(factory));
            }

            if (uiProvider == null)
            {
                throw new ArgumentNullException(nameof(uiProvider));
            }

            if (commandHandler == null)
            {
                throw new ArgumentNullException(nameof(commandHandler));
            }

            this.factory = factory;
            this.uiProvider = uiProvider;
            this.commandHandler = commandHandler;

            this.users = new HashSet<IUser>();
            this.loggedUser = null;
        }
        
        public ICollection<IUser> Users
        {
            get
            {
                return this.users;
            }
        }

        public IUser LoggedUser
        {
            get
            {
                return this.loggedUser;
            }
        }
        
        public void SetLoggedUser(IUser user)
        {
            this.loggedUser = user;
        }

        public void Start()
        {
            var commands = this.ReadCommands();
            var commandResult = this.ProcessCommands(commands);
            this.PrintReports(commandResult);
        }

        public void Reset()
        {
            this.loggedUser = null;
            this.users = new HashSet<IUser>();
            var commands = new List<ICommand>();
            var commandResult = new List<string>();
            this.PrintReports(commandResult);
        }


        private IEnumerable<ICommand> ReadCommands()
        {
            var commands = new List<ICommand>();

            var currentLine = this.uiProvider.ReadLine();

            while (!string.IsNullOrEmpty(currentLine))
            {
                var currentCommand = this.factory.CreateCommand(currentLine);
                commands.Add(currentCommand);

                currentLine = this.uiProvider.ReadLine();
            }

            return commands;
        }

        private IEnumerable<string> ProcessCommands(IEnumerable<ICommand> commands)
        {
            var reports = new List<string>();

            foreach (var command in commands)
            {
                try
                {
                    var report = this.ProcessSingleCommand(command);
                    reports.Add(report);
                }
                catch (Exception ex)
                {
                    reports.Add(ex.Message);
                }
            }

            return reports;
        }

        private void PrintReports(IEnumerable<string> reports)
        {
            var output = new StringBuilder();

            foreach (var report in reports)
            {
                output.AppendLine(report);
                output.AppendLine(new string('#', 20));
            }

            this.uiProvider.Write(output.ToString());
        }

        private string ProcessSingleCommand(ICommand command)
        {
            if (command.Name != "RegisterUser" && command.Name != "Login")
            {
                if (this.loggedUser == null)
                {
                    return UserNotLogged;
                }
            }

            return this.commandHandler.HandleCommand(command, this);
        }
    }
}
