using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace FallingRocks3
{
    class Program
    {


        static void Main(string[] args)
        {
            Random randomNum = new Random();
            Console.BufferHeight = Console.WindowHeight = 20;
            Console.BufferWidth = Console.WindowWidth = 40;

            Console.CursorVisible = false;

            while (true)
            {
                Console.SetCursorPosition(20, 10);
                Console.Write("1");

                Console.SetCursorPosition(10, 5);
                Console.Write("1");


                List<int> test = new List<int>();
                




                if (Console.KeyAvailable)
                {
                    for (int i = 0; i < 5; i++)
                    {
                        Console.SetCursorPosition(randomNum.Next(0, Console.WindowWidth),
                            randomNum.Next(0, Console.WindowHeight));
                        Console.Write("0");
                    }

                    Console.Clear();
                    Thread.Sleep(150);
                }
            }
        }
    }
}
