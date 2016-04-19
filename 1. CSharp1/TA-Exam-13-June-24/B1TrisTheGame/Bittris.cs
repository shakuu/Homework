using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace B1TrisTheGame
{
    class Bittris
    {
        public class PlayerArea
        {
            public int CanvasWidth;
            public int CanvasHeight;

            public int Width;
            public int Height;

            public int TopRow;
            public int BotRow;

            public PlayerArea()
            {
                this.CanvasWidth = 36;
                this.CanvasHeight = 30;

                this.Width = this.CanvasWidth * 1;
                this.Height = this.CanvasHeight * 5 / 6;

                this.TopRow = (this.CanvasHeight - this.Height) / 2;
                this.BotRow = this.CanvasHeight - ((this.CanvasHeight - this.Height) / 2);
            }

        }

        public class Pieces
        {
            public int posRow = 0; //row
            public int posCol = 20; //col
            public int vSpeed = 1;
            public int hSpeed = 0;
            public string toPrint = "";
            public int stringLength;
            public int Score;
            public ConsoleColor Color;
            public bool isMoving = true;

            public Pieces(int rndNumber)
            {
                //TODO: ADD COLORS, Start Position
                this.toPrint = (Convert.ToString(rndNumber, 2).
                    PadLeft(32, '0')).
                    Substring(24, 8); // conver to binary
                this.toPrint = this.toPrint.TrimStart('0');
                this.toPrint = this.toPrint.TrimEnd('0');
                this.stringLength = this.toPrint.Length;

                //get score ( number of ones )
                foreach (char digit in this.toPrint)
                { if (digit == '1') { this.Score++; } }

            }
            
            //TODO inside
            public bool CheckSides(Pieces currElement, List<Pieces> existingPieces)
            {
                //TODO 
                //1. Check Outside of player Area
                //2. ReWrite for current instance
                bool result = true;

                // each existing piece
                if (currElement.hSpeed < 0) //check Left
                {
                    foreach (Pieces piece in existingPieces)
                    {
                        if (piece.posRow == currElement.posRow)
                        {
                            if (piece.posCol + piece.stringLength >=
                                currElement.posCol + currElement.hSpeed) ;
                            {
                                result = false;
                            }
                        }
                    }
                }
                else //Check Right
                {
                    foreach (Pieces piece in existingPieces)
                    {
                        if (piece.posRow == currElement.posRow)
                        {
                            if (piece.posCol <=
                                currElement.posCol + currElement.stringLength
                                + currElement.hSpeed) ;
                            {
                                result = false;
                            }
                        }
                    }
                }
                return result;
            }
            //TODO inside
            public bool CheckRowBelow(List<Pieces> existingPieces, PlayerArea Area)
            {
                //THIS IS BROKEN elements stick to the row above
                //TODO: 0 moves THROUGH 0, detailed check ! 
                /////////////////////////////////////////////////////

                bool isFree = true;

                //check if out of bounds
                if (this.posRow + 1 > Area.Height)
                {
                    isFree = false;
                }
                else //check for elements on the row below
                {
                    foreach (Pieces piece in existingPieces)
                    {
                        Pieces longerString = piece.stringLength >= this.stringLength ?
                            piece : this;
                        Pieces shorterString = piece.stringLength < this.stringLength ?
                            piece : this;

                        //step1 check if they are on the same row
                        if (piece.posRow == this.posRow + 1)
                        {
                            //step2 check if they intersect
                            if(Enumerable.Range(longerString.posCol, longerString.stringLength-1).Contains(shorterString.posCol)
                                || Enumerable.Range(longerString.posCol, longerString.stringLength-1).Contains(shorterString.posCol + shorterString.stringLength-1))
                            {
                                isFree = false;
                            }
                        }
                    }
                }
                return isFree;
            }
            //TODO inside
            public void PrintMe()
            {
                //TODO INSERT COLOR
                Console.SetCursorPosition(this.posCol, this.posRow);
                Console.Write(this.toPrint);
            }
        }

        class Player
        {
            public string Name = "";
            public int Score = 0;
            public ConsoleKeyInfo Input = new ConsoleKeyInfo();
            public Pieces activePiece;

            public Player(string cName)
            {
                this.Name = cName;
            }

            public Player()
            {
                this.Name = "Player1";
            }
        }

        static void Main()
        {
            //settings
            Console.Clear();

            PlayerArea playArea = new PlayerArea();

            Console.BufferWidth = Console.WindowWidth = playArea.CanvasWidth;
            Console.BufferHeight = Console.WindowHeight = playArea.CanvasHeight;

            Console.Title = "B1tTris The Game";

            Console.BackgroundColor = ConsoleColor.Black;
            Console.CursorVisible = false;

            Console.Clear();

            int appSpeed = 300;
            bool appIsRunning = true;

            Random mainRandomizer = new Random();
            // end settings

            //variables
            List<Pieces> staticPieces = new List<Pieces>();

            Player player1 = new Player();
            //end variables

            while (appIsRunning)
            {
                //Create a new Shape
                player1.activePiece = new Pieces(mainRandomizer.Next(0, Int32.MaxValue));

                //MAIN
                while (player1.activePiece.isMoving)
                {
                    //read player input
                    while (Console.KeyAvailable)
                    {
                        player1.Input = Console.ReadKey();
                    }
                    //Change Position
                    switch (player1.Input.Key)
                    {
                        case ConsoleKey.LeftArrow:
                            player1.activePiece.hSpeed = -1;
                            player1.Input = new ConsoleKeyInfo();
                            break;
                        case ConsoleKey.RightArrow:
                            player1.activePiece.hSpeed = 1;
                            player1.Input = new ConsoleKeyInfo();
                            break;
                    }
                    //check if position left or right is free
                    if (player1.activePiece.CheckSides(player1.activePiece, staticPieces))
                    {
                        player1.activePiece.posCol += player1.activePiece.hSpeed; //move the piece
                    }
                    player1.activePiece.hSpeed = 0; //rest hSpeed

                    if (player1.activePiece.CheckRowBelow(staticPieces, playArea))
                    {
                        player1.activePiece.posRow++;
                    }
                    else
                    {
                        player1.activePiece.isMoving = false;
                    }

                    //INSERT PRINT FINCTION
                    Console.Clear();
                    player1.activePiece.PrintMe();
                    foreach(Pieces piece in staticPieces) { piece.PrintMe(); }
                    
                    Thread.Sleep(appSpeed);
                }

                staticPieces.Add(player1.activePiece);

                Thread.Sleep(appSpeed);
            }

        }
    }
}
