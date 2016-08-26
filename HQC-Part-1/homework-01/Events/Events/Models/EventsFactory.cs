namespace Events.Models
{
    using System;
    using System.Reflection;

    using Events.Contracts;

    public class EventsFactory : IEventsFactory
    {
        private ConstructorInfo typeToCreateConstructor;

        public EventsFactory(Type type)
        {
            this.GetTypeToCreateConstructor(type);
        }

        public IEvent CreateEvent(DateTime date, string title, string location)
        {
            throw new NotImplementedException();
        }

        private ConstructorInfo GetTypeToCreateConstructor(Type type)
        {
            var constructor = type.GetConstructor(
                BindingFlags.Instance | BindingFlags.Public,
                null,
                new[] { typeof(DateTime), typeof(string), typeof(string) },
                null);

            return constructor;
        }
    }
}
