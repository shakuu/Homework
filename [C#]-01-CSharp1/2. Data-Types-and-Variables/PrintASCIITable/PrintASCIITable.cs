using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintASCIITable
{
    class PrintASCIITable
    {
        static void Main(string[] args)
        {
           // Console.OutputEncoding = System.Text.Encoding.ASCII;
            for(byte asciiIndex = 33; asciiIndex<127; asciiIndex++ )
            { 
            Console.Write((char)asciiIndex);
            }
        }
    }
}
