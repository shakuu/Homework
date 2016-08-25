namespace Events.Models
{
    using System;
    using System.Collections.Generic;

    using Events.Contracts;

    using Wintellect.PowerCollections;

    public class EventsManager : IEventsManager
    {
        private MultiDictionary<string, Event> eventsListedByTitle =
             new MultiDictionary<string, Event>(true);

        private OrderedBag<Event> eventsListedByDate = new OrderedBag<Event>();

        public bool AddEvent(DateTime date, string title, string location)
        {
            var newEvent = new Event(date, title, location);

            this.eventsListedByTitle.Add(title.ToLower(), newEvent);
            this.eventsListedByDate.Add(newEvent);

            return true;
        }

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

        public IEnumerable<IEvent> ListEvents(DateTime date, int count)
        {
            var eventsToDisplay = new List<IEvent>();

            OrderedBag<Event>.View eventsToShow =
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
