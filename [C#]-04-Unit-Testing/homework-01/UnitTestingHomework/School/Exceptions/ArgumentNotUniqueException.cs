namespace School.Exceptions
{
    using System;

    public class ArgumentNotUniqueException : ArgumentException
    {
        public ArgumentNotUniqueException(string message)
            : base(message)
        {
            // TODO:
            throw new NotImplementedException();
        }
    }
}
