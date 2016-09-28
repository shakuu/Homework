using log4net;
using log4net.Config;

namespace DevTools.Logging
{
    using System;

    public class Log4NetTest
    {
        private static readonly ILog Logger = LogManager.GetLogger(typeof(Log4NetTest));

        /// <summary>
        /// Logs the current date and time on every execution.
        /// </summary>
        public static void Main()
        {
            XmlConfigurator.Configure();
            Logger.Info("New entry at: " + DateTime.Now);
        }
    }
}
