using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntDoubleString
{
    class Program
    {
        static void Main()
        {
            string varType = Console.ReadLine();

            switch(varType)
            {
                case "integer":
                    int varInt=int.Parse(Console.ReadLine()) + 1;
                    Console.WriteLine(varInt);
                    break;
                case "real":
                    double varDouble = double.Parse(Console.ReadLine()) + 1;
                    Console.WriteLine("{0,0:F2}", varDouble);
                    break;
                case "text":
                    string varString = Console.ReadLine() + "*";
                    Console.WriteLine(varString);
                    break;
                default: break;
            }
        }
    }
}
