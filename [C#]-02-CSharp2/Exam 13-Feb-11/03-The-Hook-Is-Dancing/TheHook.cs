using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_The_Hook_Is_Dancing
{
    class TheHook
    {
        // Vaeiables
        private static List<string> dances =
            new List<string>();

        private static string[,] theDanceFloor;
        private static int hookX;
        private static int hookY;
        private static int hookSpeedX;
        private static int hookSpeedY;

        static void Input()
        {
            var numberOfDances = int.Parse(Console.ReadLine());

            for (int line = 0; line < numberOfDances; line++)
            {
                dances.Add(Console.ReadLine());
            }
        }
        static void BuildTheDanceFloor()
        {
            var red = "RED";
            var blue = "BLUE";
            var green = "GREEN";

            theDanceFloor = new string[3, 3]
            {
                { red , blue , red  },
                { blue, green, blue },
                { red , blue , red  },
            };
        }

        static void EvaluateDances()
        {
            for (int routine = 0; routine < dances.Count; routine++)
            {
                Dance(dances[routine]);
            }
        }
        private static void Dance(string routine)
        {
            hookX = 1;
            hookY = 1;

            hookSpeedX = 0;
            hookSpeedY = 1;

            for (int move = 0; move < routine.Length; move++)
            {
                var next = routine[move];

                if (next == 'W') Move();
                else if (next == 'R') TurnRight();
                else if (next == 'L') TurnLeft();
            }

            Console.WriteLine(theDanceFloor[hookX, hookY]);
        }

        private static void Move()
        {
            hookX += hookSpeedX;
            hookY += hookSpeedY;

            // Move the dance floor
            if (hookX < 0) hookX = 2;
            else if (hookX > 2) hookX = 0;
            else if (hookY < 0) hookY = 2;
            else if (hookY > 2) hookY = 0;
        }
        private static void TurnRight()
        {
            if (hookSpeedY != 0)
            {
                hookSpeedX = hookSpeedY;
                hookSpeedY = 0;
                return;
            }

            if (hookSpeedX != 0)
            {
                hookSpeedY = -hookSpeedX;
                hookSpeedX = 0;
                return;
            }
        }
        private static void TurnLeft()
        {
            if (hookSpeedY != 0)
            {
                hookSpeedX = -hookSpeedY;
                hookSpeedY = 0;
                return;
            }

            if (hookSpeedX != 0)
            {
                hookSpeedY = hookSpeedX;
                hookSpeedX = 0;
                return;
            }
        }

        static void Main(string[] args)
        {
            Input();
            BuildTheDanceFloor();
            EvaluateDances();
        }
    }
}
