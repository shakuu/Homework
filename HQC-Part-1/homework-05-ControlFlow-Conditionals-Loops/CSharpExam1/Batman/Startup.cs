using System;

using Batman.Models;

namespace Batman
{
    public class Startup
    {
        public static void Main()
        {
            var batmanSize = int.Parse(Console.ReadLine());
            var batmanCharacterToPrint = Console.ReadLine();

            var batman = new SuperBatman(batmanSize, batmanCharacterToPrint[0]);
            Console.WriteLine(batman.ToString());
        }
    }
}
