namespace Events.Utils
{
    using System;
    using System.Text;

    using Events.Contracts;

    public class Messages : ILogger
    {
        private StringBuilder output = new StringBuilder();

        public string Log
        {
            get
            {
                return this.output.ToString();
            }
        }

        public void EventAdded()
        {
            this.output.Append("Event added");
            this.AppendNewLine();
        }

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

        public void NoEventsFound()
        {
            this.output.Append("No events found");
            this.AppendNewLine();
        }

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
