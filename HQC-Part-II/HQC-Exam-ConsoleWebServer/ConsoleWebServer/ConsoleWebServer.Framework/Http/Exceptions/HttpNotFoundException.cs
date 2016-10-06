using System;

namespace ConsoleWebServer.Framework.Http.Exceptions
{
    public class HttpNotFoundException : Exception
    {
        public HttpNotFoundException(string message) : base(message)
        {
        }

        public class ParserException : Exception
        {
            public ParserException(string message, ActionDescriptor request = null)
                : base(message)
            {
            }
        }
    }
}