namespace Events.Contracts
{
    public interface ILogger
    {
        string Log { get; }

        void EventAdded();

        void EventDeleted(int numberOfEvents);

        void NoEventsFound();

        void PrintEvent(IEvent eventToPrint);
    }
}
