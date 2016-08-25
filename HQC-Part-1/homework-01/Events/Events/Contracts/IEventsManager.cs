namespace Events.Contracts
{
    using System;
    using System.Collections.Generic;

    using Events.Contracts;

    public interface IEventsManager
    {
        bool AddEvent(DateTime date, string title, string location);

        int DeleteEvents(string titleToDelete);

        IEnumerable<IEvent> ListEvents(DateTime date, int count);
    }
}
