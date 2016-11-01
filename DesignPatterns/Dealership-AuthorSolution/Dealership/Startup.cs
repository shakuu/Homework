using System;

using Dealership.Common;
using Dealership.Engine;

namespace Dealership
{
    public class Startup
    {
        public static void Main()
        {
            DealershipEngine.GetInstance(
                new Factories.DealershipFactory(),
                new GenericIOProvider(Console.Write, Console.ReadLine))
                .Start();
        }
    }
}
