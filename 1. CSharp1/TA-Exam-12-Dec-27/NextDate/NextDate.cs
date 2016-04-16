using System;

namespace NextDate
{
    class NextDate
    {
        static void Main()
        {
            string inputDay = Console.ReadLine().PadLeft(2, '0');
            string inputMonth = Console.ReadLine().PadLeft(2, '0');
            string inputYear = Console.ReadLine();
            string inputDateTime = inputDay + "."
                + inputMonth + "." + inputYear;

            DateTime toPrint = new DateTime();

            toPrint = DateTime.ParseExact(inputDateTime, "dd.MM.yyyy", null);
            toPrint = toPrint.AddDays(1);

            Console.WriteLine(toPrint.ToString("d.M.yyyy"));
        }
    }
}
