using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Divide7and5
{
    class Divide57
    {
        static void Main(string[] args)
        {
            int NUMBER = int.Parse(Console.ReadLine());
            bool div57;

            if(NUMBER%5==0 && NUMBER%7==0)
                { div57 = true;}
            else { div57 = false; }

            Console.WriteLine(div57.ToString().ToLower() +
                " " + NUMBER);
        }
    }
}
