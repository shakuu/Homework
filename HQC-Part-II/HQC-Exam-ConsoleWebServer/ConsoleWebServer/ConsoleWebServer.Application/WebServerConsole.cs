using System;
using System.Text;

using ConsoleWebServer.Application.Loggers;
using ConsoleWebServer.Application.UI;
using ConsoleWebServer.Framework.Http.Contracts;

namespace ConsoleWebServer.Application
{
    public class WebServerConsole
    {
        private readonly IResponseProvider responseProvider;
        private readonly IInputProvider inputProvider;
        private readonly ILogger logger;

        public WebServerConsole(IResponseProvider responseProvider, IInputProvider inputProvider, ILogger logger)
        {
            if (responseProvider == null)
            {
                throw new ArgumentNullException(nameof(responseProvider));
            }

            if (inputProvider == null)
            {
                throw new ArgumentNullException(nameof(inputProvider));
            }

            if (logger == null)
            {
                throw new ArgumentNullException(nameof(logger));
            }

            this.responseProvider = responseProvider;
            this.inputProvider = inputProvider;
            this.logger = logger;
        }

        public void Start()
        {
            var requestBuilder = new StringBuilder();

            var isRunning = true;
            do
            {
                var inputLine = this.inputProvider.ReadLine();
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