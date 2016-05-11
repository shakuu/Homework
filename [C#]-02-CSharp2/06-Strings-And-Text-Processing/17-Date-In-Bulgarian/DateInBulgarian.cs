using System;
using System.Text;
using System.Globalization;

namespace _17_Date_In_Bulgarian
{
    class DateInBulgarian
    {
        static void Main()
        {
            System.Threading.Thread.CurrentThread.CurrentCulture =
                CultureInfo.CreateSpecificCulture("BG");

            Console.OutputEncoding = Encoding.UTF8;

            // Input.
            var Date = DateTime
                .ParseExact(
                    Console.ReadLine(),
                    "d.MM.yyyy H:mm:ss",
                    CultureInfo.InvariantCulture);

            Date = Date.AddHours(6);
            Date = Date.AddMinutes(30);

            Console.WriteLine(Date.ToString("d.MM.yyyy h:mm:ss dddd"));
        }
    }
}
