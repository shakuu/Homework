using Abstraction.Contracts;

namespace Abstraction.Models
{
    public abstract class Figure : IFigure
    {
        protected Figure()
        {
        }

        public abstract double CalcPerimeter();

        public abstract double CalcSurface();

        public override string ToString()
        {
            var output = string.Format(
                "I am a circle. My perimeter is {0:f2}. My surface is {1:f2}.",
                 this.CalcPerimeter(),
                 this.CalcSurface());

            return output;
        }
    }
}
