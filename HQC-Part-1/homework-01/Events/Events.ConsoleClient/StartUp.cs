namespace Events.ConsoleClient
{
    using System;

    using Events.Contracts;
    using Events.Engine;
    using Events.Models;
    using Events.Utils;

    public class Startup
    {
        public static void Main()
        {
            var engine = CreateEngine();

            var continueExecution = true;
            while (continueExecution)
            {
                var nextCommand = Console.ReadLine();
                continueExecution = engine.ExecuteNextCommand(nextCommand);
            }

            Console.WriteLine(engine.Log);
        }

        private static IEngine CreateEngine()
        {
            var logger = new MessageLogger();
            var events = new EventsManager();
            var engine = new EventsEngine(logger, events);

            return engine;
        }
    }
}
