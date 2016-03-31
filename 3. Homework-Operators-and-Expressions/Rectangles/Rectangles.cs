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
            float width = float.Parse(Console.ReadLine());
            float height = float.Parse(Console.ReadLine());
            //OUTPUT
            Console.WriteLine((2 * width + 2 * height).ToString("0.00") + " " +
                (width*height).ToString("0.00"));
        }
    }
}
