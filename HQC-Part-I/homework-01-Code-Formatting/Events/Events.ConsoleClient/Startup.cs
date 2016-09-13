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
            var eventsEngine = CreateEngine();

            var continueExecution = true;
            while (continueExecution)
            {
                var nextCommand = Console.ReadLine();
                continueExecution = eventsEngine.ExecuteNextCommand(nextCommand);
            }

            Console.WriteLine(eventsEngine.Log);
        }

        private static IEngine CreateEngine()
        {
            var factory = new EventsFactory(typeof(Event));
            var events = new EventsManager(factory);
            var logger = new MessageLogger();
            var engine = new EventsEngine(logger, events);

            return engine;
        }
    }
}
