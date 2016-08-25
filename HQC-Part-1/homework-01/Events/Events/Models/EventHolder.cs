namespace Events.Models
{
    using System;

    using Events.Contracts;

    using Wintellect.PowerCollections;

    public class EventHolder : IEventHolder
    {
        private MultiDictionary<string, Event> eventsListedByTitle =
             new MultiDictionary<string, Event>(true);

        private OrderedBag<Event> eventsListedByDate = new OrderedBag<Event>();

        private ILogger messages;

        public EventHolder(ILogger logger)
        {
            this.messages = logger;
        }

        public void AddEvent(DateTime date, string title, string location)
        {
            var newEvent = new Event(date, title, location);

            eventsListedByTitle.Add(title.ToLower(), newEvent);
            eventsListedByDate.Add(newEvent);

            messages.EventAdded();
        }

        public void DeleteEvents(string titleToDelete)
        {
            var removed = 0;
            var title = titleToDelete.ToLower();
            foreach (var eventToRemove in eventsListedByTitle[title])
            {
                removed++;
                eventsListedByDate.Remove(eventToRemove);
            }

            eventsListedByTitle.Remove(title);

            messages.EventDeleted(removed);
        }

        public void ListEvents(DateTime date, int count)
        {
            OrderedBag<Event>.View eventsToShow =
                eventsListedByDate.RangeFrom(new Event(date, "", ""), true);

            var displayedEvents = 0;
            foreach (var eventToShow in eventsToShow)
            {
                if (displayedEvents == count)
                {
                    break;
                }

                messages.PrintEvent(eventToShow);
                displayedEvents++;
            }

            if (displayedEvents == 0)
            {
                messages.NoEventsFound();
            }
        }
    }
}
