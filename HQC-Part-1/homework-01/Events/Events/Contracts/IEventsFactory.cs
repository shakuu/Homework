namespace Events.Contracts
{
    using System;

    public interface IEventsFactory
    {
        /// <summary>
        /// Instantiate a new IEvent object of the type passed in the constructor with the provided constructor parameters.
        /// </summary>
        /// <param name="constructorParameters"></param>
        /// <returns>A new IEvent object.</returns>
        /// <exception cref = "ArgumentException" > Throws If constructor with the provided parameters was not found. </exception >
        IEvent CreateEvent(object[] constructorParameters);
    }
}
