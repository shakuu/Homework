namespace Events.Contracts
{
    public interface ILogger
    {
        /// <summary>
        /// Returns all logged strings.
        /// </summary>
        string Log { get; }
        
        /// <summary>
        /// Logs "Event added".
        /// </summary>
        void EventAdded();

        /// <summary>
        /// Logs events deleted.
        /// </summary>
        /// <param name="numberOfEvents">The number of deleted events.</param>
        void EventDeleted(int numberOfEvents);

        /// <summary>
        /// Logs "No events found".
        /// </summary>
        void NoEventsFound();

        /// <summary>
        /// Logs the provided IEvent.toString().
        /// </summary>
        /// <param name="eventToPrint">IEvent object to log.</param>
        void PrintEvent(IEvent eventToPrint);
    }
}
