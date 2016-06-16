namespace FieldTesting
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    class Program
    {
        static void Main()
        {
            Console.WriteLine(  new string('-', 101));

            for (int i = 0; i < 25; i++)
            {
                Console.WriteLine('|' + new string(' ', 99) + '|');
            }

            Console.WriteLine(new string('-', 101));
        }
    }
}
