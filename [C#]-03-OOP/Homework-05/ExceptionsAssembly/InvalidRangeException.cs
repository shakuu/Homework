namespace ExceptionsAssembly
{
    using System;

    public class InvalidRangeException<T> : ApplicationException
    {
        public InvalidRangeException(string message, T min, T max)
            : base(message)
        {
            this.Min = min;
            this.Max = max;
        }

        public override string Message => string.Format(
            $"Error: Value out of range {this.Min} - {this.Max}");

        public T Min { get; private set; }
        public T Max { get; private set; }
    }
}
