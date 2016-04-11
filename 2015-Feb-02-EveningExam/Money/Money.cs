using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Money
{
    class Program
    {
        static void Main()
        {
            short studentsN = short.Parse(Console.ReadLine());
            short paperPerStudent = short.Parse(Console.ReadLine());
            double priceOfPaper = double.Parse(Console.ReadLine());
            short REALM = 400;

            Console.WriteLine(
                ( (((double)studentsN * (double)paperPerStudent) / (double)REALM) * priceOfPaper).ToString("0.000"));
        }
    }
}
