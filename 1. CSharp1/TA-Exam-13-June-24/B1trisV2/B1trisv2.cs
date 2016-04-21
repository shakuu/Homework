using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsolePlayArea;
using B1tClass;
using System.Threading;

namespace B1trisV2
{
    class B1trisv2
    {
        public class Player
        {
            public string Name = "player1";
            public int Score = 0;
            public ConsoleKeyInfo Input = new ConsoleKeyInfo();
            public B1ts B1t;
        }

        static void Main(string[] args)
        {
            //settings
            Console.Clear();
            Console.OutputEncoding = Encoding.UTF8;

            PlayArea playField = new PlayArea(); 

            Console.BufferWidth = Console.WindowWidth = playField.CanvasWidth;
            Console.BufferHeight = Console.WindowHeight = playField.CanvasHeight;

            Console.Title = "B1tTris: The Game";

            Console.BackgroundColor = playField.BackgroundColor;
            Console.CursorVisible = false;

            Console.Clear();

            int difficultyMin = 1;
            int difficultyMax = 45;

            int appSpeed = 250; // lower is faster
            bool appIsRunning = true;

            Random mainRandomizer = new Random();
            //end settings

            //variables
            // empty playing field 
            B1tTracker playB1ts = new B1tTracker();

            for (int row = 0; row < playField.Height; row++)
            {
                string toAdd = "";
                toAdd = toAdd.PadLeft(playField.Width-2, ' ');
                playB1ts.rowTracker.Add(toAdd);
                playB1ts.rowTracker[row] = "+" + playB1ts.rowTracker[row] + "+";
                playB1ts.scoreTracker.Add(0);
            }
            //
            Player player1 = new Player();

            //Pre Print Borders
            playField.printSideBorder();
            playField.PrintBottomBorder();

            while (appIsRunning)
            {
                //create a new piece
                player1.B1t = new B1ts(mainRandomizer.Next(difficultyMin, difficultyMax));
                player1.B1t.firstX = (playField.Width - player1.B1t.toPrint.Length) / 2;

                while (player1.B1t.isMoving)
                {

                    //read Input
                    while (Console.KeyAvailable)
                    {
                        player1.Input = Console.ReadKey();
                        switch (player1.Input.Key)
                        {
                            case ConsoleKey.LeftArrow:
                                player1.B1t.hSpeed += -1;
                                if (player1.B1t.hSpeed <= -B1ts.MAXSPEED)
                                {
                                    player1.B1t.hSpeed = -3;
                                }
                                player1.Input = new ConsoleKeyInfo();
                                break;
                            case ConsoleKey.RightArrow:
                                player1.B1t.hSpeed += 1;
                                if (player1.B1t.hSpeed >= B1ts.MAXSPEED)
                                {
                                    player1.B1t.hSpeed = 3;
                                }
                                player1.Input = new ConsoleKeyInfo();
                                break;
                        }
                    }
                    //Move Left or Right 
                    if (player1.B1t.canMoveSides(playField, playB1ts))
                    {
                        player1.B1t.prevX = player1.B1t.firstX;
                        player1.B1t.firstX += player1.B1t.hSpeed;
                    }
                    player1.B1t.hSpeed = 0;

                    //Move Down
                    if (player1.B1t.canMoveDown(playField, playB1ts))
                    {
                        player1.B1t.prevY = player1.B1t.PosY;
                        player1.B1t.PosY += player1.B1t.vSpeed;
                        //guideline
                        playField.PrintBottomBorder(player1.B1t.Color,
                            player1.B1t.firstX, player1.B1t.toPrint.Length);
                    }
                    else
                    {
                        //stop the current B1t
                        player1.B1t.isMoving = false;
                        player1.B1t.vSpeed = 0;
                        //update score
                        player1.Score += player1.B1t.Score;
                        playB1ts.scoreTracker[player1.B1t.PosY] += player1.B1t.Score;
                        //Update the current row string
                        playB1ts.UpdateRow(player1.B1t);
                        //CheckFullRow return int
                        player1.Score += playB1ts.isFullRow(player1.B1t);

                        playB1ts.PrintAll(playField.playAreaSideBorderWidth); // print Rows
                    }
                    //test print
                    //Console.Clear();
                    
                    //playField.printSideBorder();
                    //playField.PrintBottomBorder();
                    //playB1ts.PrintAll(playField.playAreaSideBorderWidth); // print Rows

                    if (player1.B1t.isMoving)
                    {
                        player1.B1t.PrintOne();
                    }
                    Console.SetCursorPosition(0, 22);
                    Console.Write(player1.Score);
                    


                    Thread.Sleep(appSpeed);
                }


            }
        }
    }
}
