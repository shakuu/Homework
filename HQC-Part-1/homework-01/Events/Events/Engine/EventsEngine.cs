namespace Events.Engine
{
    using System;

    using Events.Contracts;

    public class EventsEngine : IEngine
    {
        private const string AddCommand = "AddEvent";
        private const string ListCommand = "ListEvents";
        private const string DeleteCommand = "DeleteEvents";

        private const char AddCommandFirstLetter = 'A';
        private const char ListCommandFirstLetter = 'L';
        private const char DeleteCommandFirstLetter = 'D';
        private const char EndCommandFirstLetter = 'E';
        private const char CommandsSeparator = '|';

        private ILogger logger;
        private IEventsManager events;

        public EventsEngine(ILogger logger, IEventsManager events)
        {
            if (logger == null)
            {
                throw new ArgumentNullException("ILogger");
            }

            if (events == null)
            {
                throw new ArgumentNullException("IEventHolder");
            }

            this.logger = logger;
            this.events = events;
        }

        public string Log
        {
            get
            {
                return this.logger.Log;
            }
        }

        public bool ExecuteNextCommand(string command)
        {
            var status = true;

            var commandFirstLetter = command[0];
            switch (commandFirstLetter)
            {
                case EventsEngine.AddCommandFirstLetter:
                    this.AddEvent(command);
                    break;
                case EventsEngine.DeleteCommandFirstLetter:
                    this.DeleteEvents(command);
                    break;
                case EventsEngine.ListCommandFirstLetter:
                    this.ListEvents(command);
                    break;
                case EventsEngine.EndCommandFirstLetter:
                    status = false;
                    break;
                default:
                    break;
            }

            return status;
        }

        private void ListEvents(string command)
        {
            var separatorIndex = command.IndexOf(EventsEngine.CommandsSeparator);
            var countString = command.Substring(separatorIndex + 1);
            var count = int.Parse(countString);

            var date = this.GetDate(command, EventsEngine.ListCommand);

            var eventsToDisplay = this.events.ListEvents(date, count);

            var numberOfEventsDisplayed = 0;
            foreach (var eventToDisplay in eventsToDisplay)
            {
                this.logger.PrintEvent(eventToDisplay);
                numberOfEventsDisplayed++;
            }

            if (numberOfEventsDisplayed == 0)
            {
                this.logger.NoEventsFound();
            }
        }

        private void DeleteEvents(string command)
        {
            var length = EventsEngine.DeleteCommand.Length;
            var title = command.Substring(length + 1);

            var numberOfEventsDeleted = this.events.DeleteEvents(title);
            this.logger.EventDeleted(numberOfEventsDeleted);
        }

        private void AddEvent(string command)
        {
            DateTime date;
            string title;
            string location;
            this.GetParameters(command, EventsEngine.AddCommand, out date, out title, out location);

            var isSuccessfull = this.events.AddEvent(date, title, location);
            if (isSuccessfull)
            {
                this.logger.EventAdded();
            }
        }

        private void GetParameters(
            string commandForExecution,
            string commandType,
            out DateTime dateAndTime,
            out string eventTitle,
            out string eventLocation)
        {
            dateAndTime = this.GetDate(commandForExecution, commandType);

            var commandWords = commandForExecution
                .Split(new[] { EventsEngine.CommandsSeparator }, StringSplitOptions.RemoveEmptyEntries);

            eventTitle = commandWords[1].Trim();
            eventLocation = commandWords.Length == 3 ?
                  commandWords[2].Trim() : string.Empty;
        }

        private DateTime GetDate(string command, string commandType)
        {
            var date = DateTime.Parse(command.Substring(commandType.Length + 1, 20));
            return date;
        }
    }
}
