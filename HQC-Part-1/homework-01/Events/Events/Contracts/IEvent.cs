namespace Events.Contracts
{
    using System;

    /// <summary>
    /// Interface for Event objects defining their properties.
    /// </summary>
    public interface IEvent : IComparable
    {
        /// <summary>
        /// The date and time of the event.
        /// </summary>
        DateTime Date { get; set; }

        /// <summary>
        /// Title of this event.
        /// </summary>
        string Title { get; set; }

        /// <summary>
        /// Location for this event.
        /// </summary>
        string Location { get; set; }
    }
}
