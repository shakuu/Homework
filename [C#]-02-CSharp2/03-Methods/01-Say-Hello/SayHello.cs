using System;

namespace _01_Say_Hello
{
    class SayHello
    {
        static void Main()
        {
            //print output
            Console.WriteLine("Hello, {0}!", GetName());
        }

        public static string GetName()
        {
            // read the Name off the console
            return Console.ReadLine();
        }
    }
}
