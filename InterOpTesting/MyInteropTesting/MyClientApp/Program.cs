using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace MyClientApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(GetResult());
        }

        [DllImport("MyTestingLibrary.dll", EntryPoint = "GetResult", CallingConvention = CallingConvention.StdCall)]
        static extern string GetResult();
    }
}
