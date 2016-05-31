
namespace _05_OneTaskIsNotEnough
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
        private static int lastLamp;

        // JoroBot
        private static List<string> botSequences
            = new List<string>();

        private static int speedY;
        private static int speedX;
        private static bool seq1;
        private static bool seq2;

        static void Input()
        {
            lamps = int.Parse(Console.ReadLine());

            botSequences.Add(Console.ReadLine());
            botSequences.Add(Console.ReadLine());
        }
        static void Output()
        {
            var win = "bounded";
            var not = "unbounded";

            Console.WriteLine(lastLamp);

            if (seq1) Console.WriteLine(win);
            else      Console.WriteLine(not);

            if (seq2) Console.WriteLine(win);
            else      Console.WriteLine(not);
        }

        // JoroBot run sequence
        static bool JoroBotSequences(string sequence)
        {
            var startX = 0;
            var startY = 0;

            var maxX = 0;
            var maxY = 0;

            double curDistance = 0;
            double maxDistance = 0;

            double radius = 0;

            var botX = 0;
            var botY = 0;
            speedX = 0;
            speedY = 1;

            // Run 1
            for (int command = 0;
                     command < sequence.Length;
                     command++)
            {
                var nextMove = sequence[command];

                if      (nextMove == 'L') TurnLeft();
                else if (nextMove == 'R') TurnRight();

                botX += speedX;
                botY += speedY;

                // Test for length
                curDistance = Math.Abs(botX - startX) + Math.Abs(botY - speedY);

                if (curDistance > maxDistance)
                {
                    maxDistance = curDistance;
                    maxY = botY;
                    maxX = botX;
                }
            }

            // Calculate radius for midpoint start point
            // (X - centerX)^2 + (Y - centerY)^2 = radius^2
            var radiusSqrRun1 = Math.Pow((maxX - startX), 2) + Math.Pow((maxY - startY), 2);

            // run 2 coords
            var run2maxX = botX + maxX;
            var run2maxY = botY + maxY;

            var result = Math.Pow((run2maxX - startX), 2) + Math.Pow((run2maxY - startY), 2) <= radiusSqrRun1;

            return result;
        }

        static void TurnLeft()
        {
            if (speedX != 0)
            {
                speedY = speedX;
                speedX = 0;
                return;
            }

            if (speedY != 0)
            {
                speedX = -speedY;
                speedY = 0;
                return;
            }
        }

        static void TurnRight()
        {
            if (speedX != 0)
            {
                speedY = -speedX;
                speedX = 0;
                return;
            }

            if (speedY != 0)
            {
                speedX = speedY;
                speedY = 0;
                return;
            }
        }

        // Working: Might be slow.
        static void TurnOnTheLamps()
        {
            var flags = new bool[lamps];
            var counter = 0;
            var start = 0;
            var step = 2;

            while (true)
            {
                // Start switching
                // break if all lamps are on
                for (int lamp = start; lamp < lamps; lamp += step)
                {
                    if (!flags[lamp])
                    {
                        flags[lamp] = true;
                        counter++;

                        if (counter == lamps)
                        {
                            // Probably return;
                            lastLamp = lamp + 1;
                            return;
                        }
                    }
                }

                // Increment Step efficiently
                //while (true)
                //{
                //    step++;

                //    if (step > 2 && step % 2 == 0) continue;
                //    else if (step > 3 && step % 3 == 0) continue;
                //    else if (step > 5 && step % 5 == 0) continue;
                //    else break;
                //}

                step++;

                // Find the next lamp
                // not switched on
                for (int lamp = 1; lamp < lamps; lamp += 2)
                {
                    if (!flags[lamp])
                    {
                        start = lamp;
                        break;
                    }
                }
            }
        }

        static void Main()
        {
            Input();
            TurnOnTheLamps();

            seq1 = JoroBotSequences(botSequences[0]);
            seq2 = JoroBotSequences(botSequences[1]);

            Output();
        }
    }
}
