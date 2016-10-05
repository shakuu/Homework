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
            
            var isRunning = true;
            do
            {
                var inputLine = Console.ReadLine();
                if (inputLine == null)
                {
                    isRunning = false;
                }
                else if (string.IsNullOrWhiteSpace(inputLine))
                {
                    var request = requestBuilder.ToString();
                    requestBuilder.Clear();

                    var response = this.responseProvider.GetResponse(request);
                    this.logger.Log(response);
                }
                else
                {
                    requestBuilder.AppendLine(inputLine);
                }
            }
            while (isRunning);
        }
    }
}