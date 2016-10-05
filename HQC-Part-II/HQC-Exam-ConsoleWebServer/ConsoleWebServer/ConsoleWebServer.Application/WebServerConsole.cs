using System;
using System.Text;

using ConsoleWebServer.Application.Loggers;
using ConsoleWebServer.Framework;

namespace ConsoleWebServer.Application
{
    public class WebServerConsole
    {
        private readonly IResponseProvider responseProvider;
        private readonly ILogger logger;

        public WebServerConsole(IResponseProvider responseProvider, ILogger logger)
        {
            if (responseProvider == null)
            {
                throw new ArgumentNullException(nameof(responseProvider));
            }

            if (logger == null)
            {
                throw new ArgumentNullException(nameof(logger));
            }

            this.responseProvider = responseProvider;
            this.logger = logger;
        }

        public void Start()
        {
            var requestBuilder = new StringBuilder();
            string inputLine;
            while ((inputLine = Console.ReadLine()) != null)
            {
                if (string.IsNullOrWhiteSpace(inputLine))
                {
                    var response = this.responseProvider.GetResponse(requestBuilder.ToString());

                    requestBuilder.Clear();
                    continue;
                }
                requestBuilder.AppendLine(inputLine);
            }
        }
    }
}