﻿using System;
using System.Text;
using ConsoleWebServer.Framework;

namespace ConsoleWebServer.Application
{
    public class WebServerConsole
    {
        private readonly IResponseProvider responseProvider;
        public WebServerConsole(IResponseProvider responseProvider)
        {
            if (responseProvider == null)
            {
                throw new ArgumentNullException(nameof(responseProvider));
            }

            this.responseProvider = responseProvider;
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
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.WriteLine(response);
                    Console.ResetColor();
                    requestBuilder.Clear();
                    continue;
                }
                requestBuilder.AppendLine(inputLine);
            }
        }
    }
}