namespace Events.Contracts
{
    using System;
    using System.Collections.Generic;

    using Events.Contracts;

    /// <summary>
    /// Interface for classes managing IEvent objects. Inludes AddEvent(), DeleteEvents(), ListEvents().
    /// </summary>
    public interface IEventsManager
    {
        /// <summary>
        /// Add a new IEvent with the provided parameters to the EventsManager.
        /// </summary>
        /// <param name="date">Date and Time for the new IEvent.</param>
        /// <param name="title">Title string for the new IEvent.</param>
        /// <param name="location">Location string, it can be an empty string.</param>
        /// <returns>Whether the operation was completed successfully.</returns>
        bool AddEvent(DateTime date, string title, string location);

        /// <summary>
        /// Remove all IEvent objects with a matching Title property.
        /// </summary>
        /// <param name="titleToDelete">Title string to match.</param>
        /// <returns>The number of IEvent objects removed.</returns>
        int DeleteEvents(string titleToDelete);

        /// <summary>
        /// Returns count number of IEvent objects, with a matching date.
        /// </summary>
        /// <param name="date">Date to match.</param>
        /// <param name="count">Maximum number of objects to return.</param>
        /// <returns>Collection of IEvent objects matching the criteria.</returns>
        IEnumerable<IEvent> ListEvents(DateTime date, int count);
    }
}
