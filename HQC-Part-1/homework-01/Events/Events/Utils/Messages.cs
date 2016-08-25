namespace Events.Utils
{
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
            output.Append("Event added\n");
        }

        public void EventDeleted(int numberOfEvents)
        {
            if (x == 0) NoEventsFound();

            else output.AppendFormat("{0} events deleted\n", x);
        }

        public void NoEventsFound()
        {
            output.Append("No events found\n");
        }

        public void PrintEvent(IEvent eventToPrint)
        {
            if (eventToPrint != null)
            {
                output.Append(eventToPrint + "\n");
            }
        }
    }
}
