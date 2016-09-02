using Abstraction.Contracts;

namespace Abstraction.Models
{
    public abstract class Figure : IFigure
    {
        private const string ToStringTemplate = "I am a {2}. My perimeter is {0:f2}. My surface is {1:f2}.";

        protected Figure()
        {
        }

        public abstract double CalcPerimeter();

        public abstract double CalcSurface();

        public override string ToString()
        {
            var output = string.Format(
                 Figure.ToStringTemplate,
                 this.CalcPerimeter(),
                 this.CalcSurface(),
                 this.GetType().Name);

            return output;
        }

        protected virtual bool CheckIfInputValueIsValid(double value)
        {
            var valueIsValid = true;
            if (value <= 0)
            {
                valueIsValid = false;
            }

            return valueIsValid;
        }
    }
}
