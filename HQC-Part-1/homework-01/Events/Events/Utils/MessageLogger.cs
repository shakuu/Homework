namespace Events.Utils
{
    using System;
    using System.Text;

    using Events.Contracts;

    public class MessageLogger : ILogger
    {
        private StringBuilder output = new StringBuilder();

        /// <summary>
        /// Returns all logged strings.
        /// </summary>
        public string Log
        {
            get
            {
                return this.output.ToString();
            }
        }

        /// <summary>
        /// Logs "Event added".
        /// </summary>
        public void EventAdded()
        {
            this.output.Append("Event added");
            this.AppendNewLine();
        }

        /// <summary>
        /// Logs events deleted.
        /// </summary>
        /// <param name="numberOfEvents">The number of deleted events.</param>
        public void EventDeleted(int numberOfEvents)
        {
            if (numberOfEvents == 0)
            {
                this.NoEventsFound();
            }
            else
            {
                this.output.AppendFormat("{0} events deleted", numberOfEvents);
                this.AppendNewLine();
            }
        }

        /// <summary>
        /// Logs "No events found".
        /// </summary>
        public void NoEventsFound()
        {
            this.output.Append("No events found");
            this.AppendNewLine();
        }

        /// <summary>
        /// Logs the provided IEvent.toString().
        /// </summary>
        /// <param name="eventToPrint">IEvent object to log.</param>
        public void PrintEvent(IEvent eventToPrint)
        {
            if (eventToPrint != null)
            {
                this.output.Append(eventToPrint);
                this.AppendNewLine();
            }
        }

        private void AppendNewLine()
        {
            this.output.Append(Environment.NewLine);
        }
    }
}
