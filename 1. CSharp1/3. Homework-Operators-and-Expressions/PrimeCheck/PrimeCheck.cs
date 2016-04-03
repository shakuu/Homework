using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimeCheck
{
    class PrimeCheck
    {
        static void Main(string[] args)
        {
            //INPUT
            int checkN = int.Parse(Console.ReadLine());
            //Larger than 1
            if (checkN <= 1) { Console.WriteLine("false");
                Environment.Exit(0); }
            //Account for 2, 3
            if ( checkN == 2 || checkN == 3)
            {  Console.WriteLine("true");
                Environment.Exit(0);
            }
            //Trial Division
            bool isPrime = true; //innocent till proven guilty
            for ( int divBy =2; divBy <= Math.Sqrt(checkN); divBy++ )
            {
                if(checkN%divBy == 0)
                { isPrime = false; }
            }
            //Print Result
            Console.WriteLine(isPrime.ToString().ToLower()); 
        }
    }
}
