using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SheetsWithBits
{
    class Program
    {
        static void Main()
        {
            int AsyaNeeds = int.Parse(Console.ReadLine());

            for (int i = 10; i >= 0; i--)
            {
                if(AsyaNeeds%2==0)
                {
                    Console.WriteLine("A" + i.ToString());
                }
                AsyaNeeds = AsyaNeeds >> 1;
            }

        }
    }
}
