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

            eventsListedByTitle.Add(title.ToLower(), newEvent);
            eventsListedByDate.Add(newEvent);

            //messages.EventAdded();
            return true;
        }

        public int DeleteEvents(string titleToDelete)
        {
            var removed = 0;
            var title = titleToDelete.ToLower();
            foreach (var eventToRemove in eventsListedByTitle[title])
            {
                removed++;
                eventsListedByDate.Remove(eventToRemove);
            }

            eventsListedByTitle.Remove(title);

            //messages.EventDeleted(removed);
            return removed;
        }

        public IEnumerable<IEvent> ListEvents(DateTime date, int count)
        {
            var eventsToList = new List<IEvent>();

            OrderedBag<Event>.View eventsToShow =
                eventsListedByDate.RangeFrom(new Event(date, "", ""), true);

            var displayedEvents = 0;
            foreach (var eventToShow in eventsToShow)
            {
                if (displayedEvents == count)
                {
                    break;
                }

                //messages.PrintEvent(eventToShow);
                eventsToList.Add(eventToShow);
                displayedEvents++;
            }

            return eventsToList;

            //if (displayedEvents == 0)
            //{
            //    messages.NoEventsFound();
            //}
        }
    }
}
