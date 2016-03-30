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
            System.Console.WriteLine("Please enter your birthdate (mm.dd.yyyy):");
            DateTime birthDate = DateTime.ParseExact( System.Console.ReadLine(), "MM.dd.yyyy", null);
            //output
            Console.WriteLine("You are currently {0} years old\nYou will be {1} years old in 10 years time", 
                //Age now
                Math.Round((
                DateTime.Now.Subtract(birthDate).TotalDays - 
                DateTime.Now.Subtract(birthDate).TotalDays % 365)
                /365),
                //Age in 10 years
                Math.Round((
                DateTime.Now.Subtract(birthDate).TotalDays -
                DateTime.Now.Subtract(birthDate).TotalDays % 365)
                / 365) + 10
                );
        }
    }
}
