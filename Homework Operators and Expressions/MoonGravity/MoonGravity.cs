using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoonGravity
{
    class MoonGravity
    {
        static void Main(string[] args)
        {
            float W = float.Parse(Console.ReadLine());
            Console.WriteLine((W * 0.17).ToString("0.000"));
        }
    }
}
