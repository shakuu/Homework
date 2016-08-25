namespace Events.Engine
{
    using System;

    using Events.Contracts;

    public class EventsEngine : IEngine
    {
        private const string AddCommand = "AddEvent";
        private const string ListCommand = "ListEvents";
        private const string DeleteCommand = "DeleteEvents";
        private const string CommandsSeparator = "|";

        private ILogger logger;
        private IEventHolder events;

        public EventsEngine(ILogger logger, IEventHolder events)
        {
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
            var commandFirstLetter = command[0];
            var status = true;

            switch (commandFirstLetter)
            {
                case 'A':
                    this.AddEvent(command);
                    break;
                case 'D':
                    this.DeleteEvents(command);
                    break;
                case 'L':
                    this.ListEvents(command);
                    break;
                case 'E':
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
            var date = this.GetDate(command, EventsEngine.ListCommand);

            var countString = command.Substring(separatorIndex + 1);
            var count = int.Parse(countString);

            var eventsDisplayed = this.events.ListEvents(date, count);

            var numberOfEventsDisplayed = 0;
            foreach (var eventToPrint in eventsDisplayed)
            {
                this.logger.PrintEvent(eventToPrint);
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

        private void GetParameters(string commandForExecution, string commandType, out DateTime dateAndTime, out string eventTitle, out string eventLocation)
        {
            dateAndTime = this.GetDate(commandForExecution, commandType);

            int firstSeparatorIndex = commandForExecution.IndexOf(EventsEngine.CommandsSeparator);
            int lastSeparatorInex = commandForExecution.LastIndexOf(EventsEngine.CommandsSeparator);

            if (firstSeparatorIndex == lastSeparatorInex)
            {
                eventTitle = commandForExecution.Substring(firstSeparatorIndex + 1).Trim();
                eventLocation = string.Empty;
            }
            else
            {
                eventTitle = commandForExecution
                    .Substring(firstSeparatorIndex + 1, lastSeparatorInex - firstSeparatorIndex - 1)
                    .Trim();
                eventLocation = commandForExecution.Substring(lastSeparatorInex + 1).Trim();
            }
        }

        private DateTime GetDate(string command, string commandType)
        {
            var date = DateTime.Parse(command.Substring(commandType.Length + 1, 20));
            return date;
        }
    }
}
