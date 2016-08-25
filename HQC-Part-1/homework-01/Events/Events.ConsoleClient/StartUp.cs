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

            var continueExecuion = true;
            while (continueExecuion)
            {
                var nextCommand = Console.ReadLine();
                continueExecuion = engine.ExecuteNextCommand(nextCommand);
            }

            Console.WriteLine(engine.Log);
        }

        private static IEngine CreateEngine()
        {
            var logger = new MessageLogger();
            var events = new EventHolder();
            var engine = new EventsEngine(logger, events);

            return engine;
        }
    }
}
