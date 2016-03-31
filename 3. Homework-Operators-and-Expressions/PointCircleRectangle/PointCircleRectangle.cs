using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointCircleRectangle
{
    class PointCircleRectangle
    {
        static void Main(string[] args)
        {
            //GIVEN
            int circleX = 1;
            int circleY = 1;
            double circleR = 1.5;

            int rectangleLeft = -1;
            int rectangleWidth = 6;
            int rectangleTop = 1;
            int rectangleHeight = 2;
            //INPUT
            double pointX = double.Parse(Console.ReadLine());
            double pointY = double.Parse(Console.ReadLine());

            //CHECK CIRCLE
           if ( Math.Sqrt(Math.Pow((Math.Abs(circleX - pointX)), 2) +
                Math.Pow(Math.Abs(circleY-pointY),2 )) > circleR )
            { Console.Write("outside circle "); }
           else { Console.Write("inside circle "); }

           //CHECK RECTANGLE
           if ( (pointX >= rectangleLeft 
                && pointX<= rectangleLeft + rectangleWidth) 
                || (pointY<= rectangleTop
                && pointY >= rectangleTop-rectangleHeight) )
            { Console.Write("inside rectangle"); }
           else { Console.Write("outside rectangle"); }
        }
    }
}
