using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace FallingRocks
{
    class TestingFallingRocks
    {
        static void Main(string[] args)
        {
            
            Console.CursorVisible = false;
            int emptyRows = 0;

            for(int i = 0; i< 10001; i++)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Green;
                for ( int p = 0; p < emptyRows; p++)
                { Console.WriteLine(); }
                emptyRows++;
                if ( emptyRows > 10) { emptyRows = 0; }
                Console.WriteLine("111");
                Thread.Sleep(250);
            }

            Console.ReadLine();
        }
    }
}
