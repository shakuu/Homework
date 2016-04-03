using System;

namespace Printing
{
    class Printing
    {
        static void Main()
        {
            int realmOfPaper = 500;

            double numberOfStudents = double.Parse(Console.ReadLine());
            double paperPerStudent = double.Parse(Console.ReadLine());
            double pricePerRealm = double.Parse(Console.ReadLine());

            Console.WriteLine("{0,0:F2}", ((numberOfStudents * paperPerStudent) / realmOfPaper) * pricePerRealm);
        }
    }
}
