namespace Events.Contracts
{
    using System;

    public interface IEventsFactory
    {

        /// <summary>
        /// Create a new IEvent object based on the input parameters.
        /// </summary>
        /// <param name="date"></param>
        /// <param name="title"></param>
        /// <param name="location"></param>
        /// <returns>A new IEvent object.</returns>
        IEvent CreateEvent(DateTime date, string title, string location);
    }
}
