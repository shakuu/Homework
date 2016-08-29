using System;

namespace Busses
{
    public class Busses
    {
        public static void Main()
        {
            var numberOfLinesTorRead = int.Parse(Console.ReadLine());
            
            var groupsCounter = 1;
            var previousBusSpeed = int.Parse(Console.ReadLine());
            for (int busIndex = 1; busIndex < numberOfLinesTorRead; busIndex++)
            {
                // If the current bus is travelling faster than the one in front 
                // then it will catch up to it. Otherwise it will start a new group of busses.
                var nextBusSpeed = int.Parse(Console.ReadLine());
                if (nextBusSpeed > previousBusSpeed)
                {
                    nextBusSpeed = previousBusSpeed;
                }
                else
                {
                    groupsCounter++;
                    previousBusSpeed = nextBusSpeed;
                }
            }

            Console.WriteLine(groupsCounter);
        }
    }
}
