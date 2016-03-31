using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringsAndObjects
{
    class Program
    {
        static void Main(string[] args)
        {
            string varHello = "Hello";
            string varWorld = "World";
            object objHelloWorld = varHello + " " + varWorld;

            string varHelloWorld = objHelloWorld.ToString();
   
            Console.WriteLine(varHelloWorld);
        }
    }
}
