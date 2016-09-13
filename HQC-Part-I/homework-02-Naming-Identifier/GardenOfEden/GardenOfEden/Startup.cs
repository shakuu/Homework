using System;

using GardenOfEden.Models;

namespace GardenOfEden
{
    internal class Startup
    {
        internal static void Main()
        {
            var dudette = Person.Create(1);
            var dude = Person.Create(2);

            Console.WriteLine(dudette.Name);
            Console.WriteLine(dude.Name);
        }
    }
}
