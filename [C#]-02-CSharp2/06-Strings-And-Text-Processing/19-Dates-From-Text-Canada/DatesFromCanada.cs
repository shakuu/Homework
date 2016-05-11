using System;
using System.Globalization;
using System.Threading;
using System.Text.RegularExpressions;

namespace _19_Dates_From_Text_Canada
{
    class DatesFromCanada
    {
        static void Main(string[] args)
        {
            // https://en.wikipedia.org/wiki/Date_and_time_notation_in_Canada
            // YYYY MM DD

            // Set culture to Canada - en-CA.
            Thread.CurrentThread.CurrentCulture =
                CultureInfo.CreateSpecificCulture("en-CA");

            // Input.
            var toParse = Console.ReadLine();

            // Extract all dates.
            var datePattern = @"(\d{2}\.\d{2}\.\d{4}).*?";
            var dateRegex = new Regex(datePattern);

            var dateMatches = dateRegex.Matches(toParse);

            //var dates = new List<DateTime>();

            foreach (var date in dateMatches)
            {
                // Convert to DateTime
                var thisDate =
                    DateTime.Parse(date.ToString());

                Console.WriteLine(
                    thisDate.ToString("MMMM dd yyyy"));
            }
        }
    }
}
