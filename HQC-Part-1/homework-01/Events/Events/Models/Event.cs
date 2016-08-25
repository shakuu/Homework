namespace Events.Models
{
    using System;
    using System.Text;

    using Events.Contracts;

    public class Event : IEvent, IComparable
    {
        private DateTime date;
        private string title;
        private string location;

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

            stringBuilder.Append(this.date.ToString("yyyy-MM-ddTHH:mm:ss"));
            stringBuilder.Append(" | " + this.title);

            if (!string.IsNullOrEmpty(this.location))
            {
                stringBuilder.Append(" | " + this.location);
            }

            return stringBuilder.ToString();
        }
    }
}
