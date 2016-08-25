namespace Events.Models
{
    using System;
    using System.Text;

    using Events.Contracts;

    public class Event : IEvent, IComparable
    {
        private const string ToStringSeparator = " | ";
        private const string ToStringDateFormat = "yyyy-MM-ddTHH:mm:ss";


        public Event(DateTime date, string title, string location)
        {
            this.Date = date;
            this.Title = title;
            this.Location = location;
        }

        public DateTime Date { get; set; }

        public string Title { get; set; }

        public string Location { get; set; }

        public int CompareTo(object obj)
        {
            Event other = obj as Event;
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
