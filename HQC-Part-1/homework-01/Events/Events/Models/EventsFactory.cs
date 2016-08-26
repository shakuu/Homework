namespace Events.Models
{
    using System;
    using System.Reflection;

    using Events.Contracts;

    public class EventsFactory : IEventsFactory
    {
        private Type typeToCreate;

        /// <summary>
        /// Instantiates a new EventsFactory object.
        /// </summary>
        /// <param name="type">The type must be implementing IEvent interface and specifies the type of objects CreateEvent() should instantiate.</param>
        /// <exception cref = "ArgumentNullException" > Throws If type parameter is null. </ exception >
        /// <exception cref = "ArgumentException" > Throws If type does not implement IEvent. </ exception >
        public EventsFactory(Type type)
        {
            if (type == null)
            {
                throw new ArgumentNullException("type");
            }

            var typeImplementsIEvent = type.GetInterface("IEvent");
            if (typeImplementsIEvent == null)
            {
                throw new ArgumentException("Invalid type");
            }

            this.typeToCreate = type;
            this.CreateEvent(new object[] { new DateTime(), "str", "str" });
        }

        /// <summary>
        /// Instantiate a new IEvent object of the type passed in the constructor with the provided constructor parameters.
        /// </summary>
        /// <param name="constructorParameters"></param>
        /// <returns>A new IEvent object.</returns>
        /// <exception cref = "ArgumentException" > Throws If constructor with the provided parameters was not found. </ exception >
        public IEvent CreateEvent(object[] contructorParameters)
        {
            var constructorToInvoke = this.GetTypeToCreateConstructor(this.typeToCreate, contructorParameters);
            var newlyCreatedEvent = (IEvent)constructorToInvoke.Invoke(contructorParameters);

            return newlyCreatedEvent;
        }

        private ConstructorInfo GetTypeToCreateConstructor(Type type, object[] constructorParameters)
        {
            var constructorParametersTypes = this.GetConstructorParametersTypes(constructorParameters);

            var constructor = type.GetConstructor(
                BindingFlags.Instance | BindingFlags.Public,
                null,
                constructorParametersTypes,
                null);

            if (constructor == null)
            {
                type.GetConstructor(
                    BindingFlags.Instance | BindingFlags.NonPublic,
                    null,
                    constructorParametersTypes,
                    null);
            }

            if (constructor == null)
            {
                throw new ArgumentException("Type does not have a constructor with these parameters.");
            }

            return constructor;
        }

        private Type[] GetConstructorParametersTypes(object[] constructorParameters)
        {
            var numberOfParameters = constructorParameters.Length;
            var constructorParametersTypes = new Type[numberOfParameters];

            for (int i = 0; i < numberOfParameters; i++)
            {
                constructorParametersTypes[i] = constructorParameters[i].GetType();
            }

            return constructorParametersTypes;
        }
    }
}
