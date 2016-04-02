using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace FallingRocks4
{
    class FallingRocks
    {
        public struct Player
        {
            public int posX;
            public int posY;
            public string toPrint;
            public ConsoleColor color;
            public bool isAlive;
            public ConsoleKeyInfo input;
            public int Score;
            public int Speed;

            public Player(int X, int Y, string Str, ConsoleColor Col, bool Alive)
            {
                this.posX = X;
                this.posY = Y;
                this.toPrint = Str;
                this.color = Col;
                this.isAlive = Alive;
                this.input = new ConsoleKeyInfo();
                this.Score = 0;
                this.Speed = 0;
            }
        }

        public class Rock
        {
            public int posX;
            public int posY;
            public string toPrint;
            public ConsoleColor color;

            public Rock(int X, int Y, string Str, ConsoleColor Col)
            {
                this.posX = X;
                this.posY = Y;
                this.toPrint = Str;
                this.color = Col;
            }
        }

        static void Main()
        {
            Console.BufferHeight = Console.WindowHeight = 20;
            Console.BufferWidth = Console.WindowWidth = 40;
            Console.CursorVisible = false;
            Console.BackgroundColor = ConsoleColor.DarkGray;
            Console.Title = "Falling Rocks";
            Console.Clear();

            Random mainRandom = new Random();

            bool appIsRunning = true;
            int appSpeed = 150;

            Player player1 = new Player(Console.WindowWidth / 2 - 1, Console.WindowHeight-4, "(0)", ConsoleColor.White, true);

            List<Rock> Rocks = new List<Rock>();
            Rock newRock = new Rock(10, 10, "!", ConsoleColor.Cyan);
            //1st Row of Rocks
            for (int i = 0; i < mainRandom.Next(0, 4); i++)
            { Rocks.Add(GenerateNewRock()); Thread.Sleep(5); }

            while (appIsRunning)
            {
                appSpeed = 150;
                player1.Speed = 0;

                //Read Input 
                while (Console.KeyAvailable)
                {
                    player1.input = Console.ReadKey(true);
                }

                if (player1.input.Key == ConsoleKey.LeftArrow && player1.posX > 0)
                {
                    player1.Speed--;
                    player1.input = new ConsoleKeyInfo();
                }
                if (player1.input.Key == ConsoleKey.RightArrow && player1.posX < Console.BufferWidth - 3)
                {
                    player1.Speed++;
                    player1.input = new ConsoleKeyInfo();
                }

                player1.posX += player1.Speed;
                //Move Existing Rocks down
                foreach (Rock element in Rocks)
                { element.posY++; }

                //Add More Rocks
                for (int i = 0; i < mainRandom.Next(0, 4); i++)
                { Rocks.Add(GenerateNewRock()); Thread.Sleep(5); appSpeed -= 5; }

                //Remove Old Rocks
                for (int i = 0; i < Rocks.Count; i++)
                {
                    if (Rocks[i].posY > Console.BufferHeight - 4)
                    {
                        Rocks.Remove(Rocks[i]);
                        i--;
                    }
                }
                //Check Collision
                foreach (Rock element in Rocks)
                {
                    for (int i = 0; i < 3; i++)
                    {
                        if (element.posX == player1.posX + i
                            && element.posY == player1.posY)
                        {
                            player1.isAlive = false;
                            player1.color = ConsoleColor.Red;
                        }
                    }
                }


                //Print
                Console.Clear();
                foreach (Rock element in Rocks)
                { Print(element.posX, element.posY, element.toPrint, element.color); }

                Print(player1.posX, player1.posY, player1.toPrint, player1.color);
                PrintScore(player1.Score, player1.isAlive);

                player1.Score++;
                Thread.Sleep(appSpeed);
            }

        }

        static Rock GenerateNewRock()
        {
            Random posX = new Random();
            string rockChars = "^@*&+%$#!.;-";

            List<ConsoleColor> color = new List<ConsoleColor>();
            color.Add(ConsoleColor.Cyan);
            color.Add(ConsoleColor.Magenta);
            color.Add(ConsoleColor.Yellow);
            color.Add(ConsoleColor.Green);

            for (int i = 0; i < 100; i++) { posX.Next(0, Console.BufferWidth); } //MOAR RNG

            Rock newRock = new Rock(posX.Next(0, Console.BufferWidth), 0,
               rockChars.ElementAt(posX.Next(0, rockChars.Length)).ToString(), color[posX.Next(0, color.Count)]);
            return newRock;
        }

        static void Print(int X, int Y, string Str, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.SetCursorPosition(X, Y);
            Console.Write(Str);
        }

        static void PrintScore(int Score, bool isAlive)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(0, Console.WindowHeight - 3);

            string Alive = "SCORE: ";
            string notAlive = "GAME OVER! ENTER: TRY AGAIN ESC: EXIT";

            for (int i = 0; i < Console.WindowWidth; i++)
            { Console.Write("-"); }

            if (isAlive == true)
            {
                Console.SetCursorPosition((Console.WindowWidth - Alive.Length - 4) / 2, Console.WindowHeight - 2);
                Console.Write("{0}{1,4:D4}", Alive, Score);
            }
            else
            {
                Console.SetCursorPosition((Console.WindowWidth - notAlive.Length) / 2, Console.WindowHeight - 2);
                Console.Write(notAlive);

                ConsoleKeyInfo continueKey = new ConsoleKeyInfo();
                do
                {
                    continueKey = Console.ReadKey();
                    if (continueKey.Key == ConsoleKey.Enter)
                    {
                        FallingRocks4.FallingRocks.Main();
                    }
                    else if (continueKey.Key == ConsoleKey.Escape)
                    {
                        Environment.Exit(0);
                    }
                } while (continueKey.Key != ConsoleKey.Enter
                || continueKey.Key != ConsoleKey.Escape);
            }

        }


    }
}
