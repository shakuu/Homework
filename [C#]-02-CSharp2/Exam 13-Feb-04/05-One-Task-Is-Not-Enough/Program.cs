
namespace _05_One_Task_Is_Not_Enough
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    class Program
    {
        // Lamps
        private static int lamps;

        // JoroBot
        private static List<string> sequences =
            new List<string>();

        private static int last;

        static void Input()
        {
            lamps = int.Parse(Console.ReadLine());

            sequences.Add(Console.ReadLine());
            sequences.Add(Console.ReadLine());

        }

        static void TurnOnTheLights()
        {
            var lampsArray = Enumerable.Range(0, lamps + 1).ToArray();
            var flags = new bool[lamps+1];
            var step = 2;
            
            while (lamps > 0)
            {
                // Clear the flags
                Array.Clear(flags, 1, lamps);

                // Mark which lamps are turned on this cycle
                // All lamps off are at the start of the arraay
                // up to the index of their count.
                for (int lamp = 1; lamp <= lamps; lamp+=step)
                    flags[lamp] = true;

                // Count how many lamps remain to be turned on
                // Move those lamps to the start of the array
                // Get the new count ( end index of for cycles )
                var newIndex = 0;
                for (int lamp = 1; lamp <= lamps; lamp++)
                {
                    if (!flags[lamp])
                    {
                        newIndex++;
                        lampsArray[newIndex] = lampsArray[lamp];
                        last = lampsArray[lamp];
                    }
                }

                lamps = newIndex;
                step++;
            }

        }

        static void Main()
        {
            Input();
            TurnOnTheLights();
        }
    }
}
