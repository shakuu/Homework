namespace Events.Models
{
    using System;
    using System.Collections.Generic;

    using Events.Contracts;

    using Wintellect.PowerCollections;

    public class EventsManager : IEventsManager
    {
        private MultiDictionary<string, IEvent> eventsListedByTitle =
             new MultiDictionary<string, IEvent>(true);

        private OrderedBag<IEvent> eventsListedByDate = new OrderedBag<IEvent>();

        private IEventsFactory eventsFactory;

        public EventsManager(IEventsFactory factory)
        {
            if(factory == null)
            {
                throw new ArgumentNullException("factory");
            }

            this.eventsFactory = factory;
        }

        /// <summary>
        /// Add a new IEvent with the provided parameters to the EventsManager.
        /// </summary>
        /// <param name="date">Date and Time for the new IEvent.</param>
        /// <param name="title">Title string for the new IEvent.</param>
        /// <param name="location">Location string, it can be an empty string.</param>
        /// <returns>Whether the operation was completed successfully.</returns>
        public bool AddEvent(DateTime date, string title, string location)
        {
            var newEvent = this.eventsFactory.CreateEvent(date, title, location);

            this.eventsListedByTitle.Add(title.ToLower(), newEvent);
            this.eventsListedByDate.Add(newEvent);

            return true;
        }

        /// <summary>
        /// Remove all IEvent objects with a matching Title property.
        /// </summary>
        /// <param name="titleToDelete">Title string to match.</param>
        /// <returns>The number of IEvent objects removed.</returns>
        public int DeleteEvents(string titleToDelete)
        {
            var removedEventsCount = 0;
            var title = titleToDelete.ToLower();
            foreach (var eventToRemove in this.eventsListedByTitle[title])
            {
                removedEventsCount++;
                this.eventsListedByDate.Remove(eventToRemove);
            }

            this.eventsListedByTitle.Remove(title);

            return removedEventsCount;
        }

        /// <summary>
        /// Returns count number of IEvent objects with a matching date.
        /// </summary>
        /// <param name="date">Date to match.</param>
        /// <param name="count">Maximum number of objects to return.</param>
        /// <returns>Collection of IEvent objects matching the criteria.</returns>
        public IEnumerable<IEvent> ListEvents(DateTime date, int count)
        {
            var eventsToDisplay = new List<IEvent>();

            OrderedBag<IEvent>.View eventsToShow =
               this.eventsListedByDate.RangeFrom(new Event(date, string.Empty, string.Empty), true);

            var displayedEventsCount = 0;
            foreach (var eventToShow in eventsToShow)
            {
                if (displayedEventsCount == count)
                {
                    break;
                }

                eventsToDisplay.Add(eventToShow);
                displayedEventsCount++;
            }

            return eventsToDisplay;
        }
    }
}
