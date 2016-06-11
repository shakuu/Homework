namespace ExceptionsAssembly.InvalidRange
{
    using System;

    public class InvalidRangeException<T> : Exception
    {
        public InvalidRangeException()
        {
        }

        public InvalidRangeException(string message)
            : base(message)
        {

        }

        public InvalidRangeException(string message, Exception original)
            : base(message, original)
        {

        }

        public InvalidRangeException(string message, T min, T max)
            : base(message)
        {
            this.Min = min;
            this.Max = max;
        }

        public override string Message
        {
            get
            {
                return base.Message;
            }
        }

        public T Min { get; private set; }
        public T Max { get; private set; }
    }
}
