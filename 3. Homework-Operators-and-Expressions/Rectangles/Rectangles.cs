using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rectangles
{
    class Rectangles
    {
        static void Main(string[] args)
        {
            // INPUT width, height
            double width = double.Parse(Console.ReadLine());
            double height = double.Parse(Console.ReadLine());
            //OUTPUT
            Console.WriteLine((width * height).ToString("0.00") + " " 
                + (2 * width + 2 * height).ToString("0.00"));
        }
    }
}
