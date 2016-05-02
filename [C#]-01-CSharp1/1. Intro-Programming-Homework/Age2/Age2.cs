using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Age
{
    class Age
    {
        static void Main(string[] args)
        {
            //input    
            DateTime birthDate = DateTime.ParseExact(System.Console.ReadLine(), "MM.dd.yyyy", null);
            //output
            Console.WriteLine("{0}\n{1}",
                //Age now
                Math.Round((
                DateTime.Now.Subtract(birthDate).TotalDays -
                DateTime.Now.Subtract(birthDate).TotalDays % 365.25)
                / 365.25),
                //Age in 10 years
                Math.Round((
                DateTime.Now.Subtract(birthDate).TotalDays -
                DateTime.Now.Subtract(birthDate).TotalDays % 365.25)
                / 365.25) + 10
                );
        }
    }
}
