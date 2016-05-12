using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24_Order_Words
{
    class Program
    {
        static void Main()
        {
            // TODO: Might need manual sorting

            // input 
            var words = Console
                .ReadLine()
                .Trim()
                .Split(' ')
                .ToArray();

            Array.Sort(words);

            foreach (var word in words)
            {
                Console.WriteLine(word);
            }
        }
    }
}
