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

            var engineIsRunning = true;
            while (engineIsRunning)
            {
                var nextCommand = Console.ReadLine();
                engineIsRunning = engine.ExecuteNextCommand(nextCommand);
            }

            Console.WriteLine(engine.Log);
        }

        private static IEngine CreateEngine()
        {
            var logger = new Messages();
            var events = new EventHolder();
            var engine = new EventsEngine(logger, events);

            return engine;
        }
    }
}
