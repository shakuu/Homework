namespace Events.Contracts
{
    using System;

    public interface IEvent : IComparable
    {
        DateTime Date { get; set; }

        string Title { get; set; }

        string Location { get; set; }
    }
}
