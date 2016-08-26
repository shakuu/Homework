namespace Events.Models
{
    using System;
    using System.Text;

    using Events.Contracts;

    /// <summary>
    /// Implements IEvent without any additions.
    /// </summary>
    public class Event : IEvent, IComparable
    {
        private const string ToStringSeparator = " | ";
        private const string ToStringDateFormat = "yyyy-MM-ddTHH:mm:ss";

        /// <summary>
        /// Create a new instance.
        /// </summary>
        /// <param name="date"> Sets Date property. </param>
        /// <param name="title"> Sets Title property. </param>
        /// <param name="location"> Sets Location property. It can be an empty string. </param>
        public Event(DateTime date, string title, string location)
        {
            this.Date = date;
            this.Title = title;
            this.Location = location;
        }

        /// <summary>
        /// The date and time of the event.
        /// </summary>
        public DateTime Date { get; set; }
        
        /// <summary>
        /// Title of this event.
        /// </summary>
        public string Title { get; set; }
        
        /// <summary>
        /// Location for this event.
        /// </summary>
        public string Location { get; set; }

        /// <summary>
        /// Compares this Event object to another IEvent object in the following order: Date, Title, Location.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns> Integer value representing the result. </returns>
        /// <exception cref="ArgumentException"> Throws if obj parameter type does not implement IEvent interface. </exception>
        public int CompareTo(object obj)
        {
            var other = obj as IEvent;
            if (other == null)
            {
                throw new ArgumentException();
            }

            int comaparisonByDate = this.Date.CompareTo(other.Date);
            if (comaparisonByDate != 0)
            {
                return comaparisonByDate;
            }

            int comparisonByTitle = this.Title.CompareTo(other.Title);
            if (comparisonByTitle != 0)
            {
                return comparisonByTitle;
            }

            int comparisonByLocation = this.Location.CompareTo(other.Location);

            return comparisonByLocation;
        }

        /// <summary>
        /// Generates a string in the following format: "{Date} | {Title} | {Location}"
        /// </summary>
        /// <returns> "{Date} | {Title} | {Location}" </returns>
        public override string ToString()
        {
            var stringBuilder = new StringBuilder();

            stringBuilder.Append(this.Date.ToString(Event.ToStringDateFormat));
            stringBuilder.Append(Event.ToStringSeparator + this.Title);

            if (!string.IsNullOrEmpty(this.Location))
            {
                stringBuilder.Append(Event.ToStringSeparator + this.Location);
            }

            return stringBuilder.ToString();
        }
    }
}
