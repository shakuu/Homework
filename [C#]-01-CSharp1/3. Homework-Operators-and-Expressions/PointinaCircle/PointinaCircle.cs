using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointinaCircle
{
    class PointinaCircle
    {
        static void Main(string[] args)
        {
            //given
            byte kRadius = 2;
            byte circleX = 0;
            byte circleY = 0;
            //INPUT
            double pointX = double.Parse(Console.ReadLine());
            double pointY = double.Parse(Console.ReadLine());
            //pitagor
            double pointDistance = Math.Sqrt((Math.Pow(Math.Abs(pointX - circleX), 2) +
                Math.Pow(Math.Abs(pointY - circleY), 2)));

            if (pointDistance>kRadius)
            { Console.WriteLine("no " + pointDistance.ToString("0.00")); }
            else
            { Console.WriteLine("yes " + pointDistance.ToString("0.00")); }
        }
    }
}
