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

            public Player()
            { }

            public Player(string name)
            {
                this.Name = name;
            }
        }

        static void Main()
        {
            Console.OutputEncoding = Encoding.UTF8;
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
            int difficultyMax = 63;

            int initialAppSpeed = 400; // lower is faster + to increment
            int curAppSpeed = initialAppSpeed;
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
                player1.B1t = new B1ts(mainRandomizer.Next(difficultyMin, difficultyMax), 
                    mainRandomizer.Next(1, 15)); //change to 20
                player1.B1t.firstX = (playField.Width - player1.B1t.toPrint.Length +1) / 2;

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
                            case ConsoleKey.DownArrow:
                                player1.B1t.vSpeed += 1;
                                if (player1.B1t.vSpeed >= B1ts.MAXSPEED)
                                {
                                    player1.B1t.vSpeed = 3;
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
                    if (player1.B1t.canMoveDownSpeed(playField, playB1ts))
                    {
                        player1.B1t.prevY = player1.B1t.PosY;
                        player1.B1t.PosY += player1.B1t.vSpeed;
                        player1.B1t.vSpeed = 1;
                        //guideline
                        playField.PrintBottomBorder(player1.B1t.Color,
                            player1.B1t.firstX, player1.B1t.toPrint.Length);
                    }
                    else
                    {
                        //GAME OVER
                        if (player1.B1t.PosY == 0)
                        {
                            appIsRunning = false;
                            break;
                        }

                        //stop the current B1t
                        player1.B1t.isMoving = false;
                        player1.B1t.vSpeed = 0;
                        //update score
                        player1.Score += player1.B1t.Score;
                        playB1ts.scoreTracker[player1.B1t.PosY] += player1.B1t.Score;
                        //green fill as many 0s as possible
                        if (player1.B1t.Color == ConsoleColor.Green &&
                            player1.B1t.PosY < playField.Height-1)
                        {
                            playB1ts.isGreen(player1.B1t);
                        }
                        else
                        {
                            //Update the current row string
                            playB1ts.UpdateRow(player1.B1t);
                        }
                        //action based on color
                        //red -> destroy current row
                        if ( player1.B1t.Color==ConsoleColor.Red)
                        {
                            player1.Score+= playB1ts.isRed(player1.B1t);
                        }
                        
                        //CheckFullRow return int
                        player1.Score += playB1ts.isFullRow(player1.B1t);

                        playB1ts.PrintAll(playField.playAreaSideBorderWidth); // print Rows
                    }

                    //print player b1t
                    if (appIsRunning)
                    {
                        if (player1.B1t.isMoving)
                        {
                            player1.B1t.PrintOne();
                            //Re-Draw Previous Line
                            playB1ts.PrintOne(playField.playAreaSideBorderWidth, player1.B1t.prevY);
                        }
                        playField.PrintScore(player1.Score, player1.Name,
                            curAppSpeed, player1.B1t.intValue); 
                    }

                    curAppSpeed = initialAppSpeed - ( player1.Score / 50) > 100 ?
                         initialAppSpeed -( player1.Score / 50) : 100;
                    Thread.Sleep(curAppSpeed);
                }
            }

            //GAME OVER
            if(!appIsRunning)
            {
                string PrintGO = "GAME OVER";
                Console.ForegroundColor = ConsoleColor.Red;
                Console.SetCursorPosition((playField.Width - PrintGO.Length) / 2 +1, 0);
                Console.Write(PrintGO);

                string Continue = "Enter:Continue ESC:Exit";
                Console.SetCursorPosition((playField.Width - Continue.Length) / 2 + 1,
                    playField.CanvasHeight-3);
                Console.Write(Continue);

                while (player1.Input.Key != ConsoleKey.Escape ||
                    player1.Input.Key != ConsoleKey.Enter)
                {
                    player1.Input = new ConsoleKeyInfo();
                    player1.Input = Console.ReadKey();

                    if (player1.Input.Key == ConsoleKey.Enter)
                    {
                        B1trisV2.B1trisv2.Main();
                    }
                    else if (player1.Input.Key == ConsoleKey.Escape)
                    {
                        return;
                    }
                }     
            }
        }
    }
}
