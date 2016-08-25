namespace Events.Models
{
    using System;
    using System.Collections.Generic;

    using Events.Contracts;

    using Wintellect.PowerCollections;

    public class EventHolder : IEventHolder
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
            var removed = 0;
            var title = titleToDelete.ToLower();
            foreach (var eventToRemove in this.eventsListedByTitle[title])
            {
                removed++;
                this.eventsListedByDate.Remove(eventToRemove);
            }

            this.eventsListedByTitle.Remove(title);

            return removed;
        }

        public IEnumerable<IEvent> ListEvents(DateTime date, int count)
        {
            var eventsToList = new List<IEvent>();

            OrderedBag<Event>.View eventsToShow =
               this.eventsListedByDate.RangeFrom(new Event(date, string.Empty, string.Empty), true);

            var displayedEvents = 0;
            foreach (var eventToShow in eventsToShow)
            {
                if (displayedEvents == count)
                {
                    break;
                }

                eventsToList.Add(eventToShow);
                displayedEvents++;
            }

            return eventsToList;
        }
    }
}
