using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;

namespace _06_Workdays
{
    class WorkDays
    {
        static void Main()
        {
            Thread.CurrentThread.CurrentCulture =
                CultureInfo.InvariantCulture;

            // input - End Date
            DateTime EndDate = DateTime.Parse(Console.ReadLine());

            DateTime curDate = DateTime.Today.AddDays(1);

            List<DateTime> Holidays = new List<DateTime>();

            Holidays.Add(DateTime.Parse("05-24-2016"));

            int WorkDays = 0;

            while (curDate <= EndDate)
            {
                // if not a holiday
                if (curDate.DayOfWeek != DayOfWeek.Sunday &&
                    curDate.DayOfWeek != DayOfWeek.Saturday)
                {
                    // check for the list of dates
                    if (!Holidays.Contains(curDate))
                    {
                        WorkDays++;
                    }
                }
                curDate = curDate.AddDays(1);
            }

            Console.WriteLine(WorkDays);
        }
    }
}
