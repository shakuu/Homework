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
                this.CanvasWidth = 30;
                this.CanvasHeight = 24;

                this.Width = this.CanvasWidth *1;
                this.Height = this.CanvasHeight * 5 / 6;

                this.TopRow = (this.CanvasHeight - this.Height) / 2;
                this.BotRow = this.CanvasHeight - ((this.CanvasHeight - this.Height) / 2);
            }

        }

        public class Pieces
        {
            public int posRow = 0; //row
            public int posCol = 10; //col
            public int vSpeed = 1;
            public int hSpeed = 0;
            public string toPrint = "";
            public int stringLength;
            public int Score;
            public ConsoleColor Color;
            public bool isMoving = true;
            public bool isVisible = true;

            public Pieces(int rndNumber)
            {
                //TODO: ADD COLORS, Start Position
                this.toPrint = (Convert.ToString(rndNumber, 2).
                    PadLeft(32, '0')).
                    Substring(24, 8); // conver to binary
                this.toPrint = this.toPrint.TrimStart('0');
                this.toPrint = this.toPrint.TrimEnd('0');
                this.stringLength = this.toPrint.Length;
                this.Score = rndNumber;

                //get score ( number of ones )
                foreach (char digit in this.toPrint)
                { if (digit == '1') { this.Score++; } }

            }

            //TODO inside
            public bool CheckSides(Pieces currElement, List<Pieces> existingPieces, PlayerArea Area)
            {
                //TODO 
                //2. ReWrite for current instance
                bool result = true;

                // each existing piece
                if (currElement.hSpeed < 0) //check Left
                {
                    //adjust speed and stay in play area
                    for (int speed = -this.hSpeed; speed >= 0; speed--)
                    {
                        if (this.posCol -speed >1)
                        { this.hSpeed = -speed; break; }
                    }

                    foreach (Pieces piece in existingPieces)
                    {
                        if (piece.posRow == currElement.posRow)
                        {
                            if (piece.posCol + piece.stringLength >
                                currElement.posCol + currElement.hSpeed) ;
                            {
                                result = false;
                            }
                        }
                    }
                }
                else //Check Right
                {
                    for (int speed = this.hSpeed; speed >= 0; speed--)
                    {
                        if ( this.posCol+this.stringLength+speed < Area.Width-1)
                        { this.hSpeed = speed; break; }
                    }

                    foreach (Pieces piece in existingPieces)
                    {
                        if (piece.posRow == currElement.posRow)
                        {
                            if (piece.posCol <
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
            //TODO - DONE
            public bool CheckRowBelow(List<Pieces> existingPieces, PlayerArea Area)
            {
                //working
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
                            if (Enumerable.Range(longerString.posCol, longerString.stringLength ).Contains(shorterString.posCol)
                                || Enumerable.Range(longerString.posCol, longerString.stringLength ).Contains(shorterString.posCol + shorterString.stringLength ))
                            {
                                Pieces higherCol;
                                Pieces lowerCol;
                                //broken if equal!!!
                                if (piece.posCol > this.posCol)
                                {
                                    higherCol = piece;
                                    lowerCol = this;
                                }
                                else if (piece.posCol == this.posCol)
                                {
                                    higherCol = piece;
                                    lowerCol = this;
                                }
                                else 
                                {
                                    higherCol = this;
                                    lowerCol = piece;
                                }

                                int StartPosition = higherCol.posCol - lowerCol.posCol;
                                //step 3 check each bit
                                for (int col = 0;
                                    col < Math.Min(lowerCol.stringLength - StartPosition,
                                    shorterString.stringLength); col++)
                                {
                                    if (higherCol.toPrint[col] == '1'
                                        && lowerCol.toPrint[higherCol.posCol - lowerCol.posCol + col] == '1')
                                    {
                                        isFree = false;
                                    }
                                }
                            }
                        }
                    }
                }
                return isFree;
            }
            //TODO -> somethings not rihgt
            public List<Pieces> CleanUp(List<Pieces> existingPieces)
            {

                string toReplace = "";

                foreach (Pieces piece in existingPieces)
                {
                    Pieces longerString = piece.stringLength >= this.stringLength ?
                        piece : this;
                    Pieces shorterString = piece.stringLength < this.stringLength ?
                        piece : this;

                    //step1 check if they are on the same row
                    if (piece.posRow == this.posRow)
                    {
                        //step2 check if they intersect
                        if (Enumerable.Range(longerString.posCol, longerString.stringLength ).Contains(shorterString.posCol)
                            || Enumerable.Range(longerString.posCol, longerString.stringLength ).Contains(shorterString.posCol + shorterString.stringLength ))
                        {
                            Pieces higherCol;
                            Pieces lowerCol;
                            //broken if equal!!!
                            if (piece.posCol > this.posCol)
                            {
                                higherCol = piece;
                                lowerCol = this;
                            }
                            else if (piece.posCol == this.posCol)
                            {
                                higherCol = piece;
                                lowerCol = this;
                            }
                            else
                            {
                                higherCol = this;
                                lowerCol = piece;
                            }

                            int StartPosition = higherCol.posCol - lowerCol.posCol;
                            toReplace = "";
                            //step 3 build a the strings
                            for (int col = 0;
                                col < Math.Min(lowerCol.stringLength - StartPosition,
                                shorterString.stringLength); col++)
                            {

                                if (higherCol.toPrint[col] == '1'
                                    || lowerCol.toPrint[higherCol.posCol - lowerCol.posCol + col] == '1')
                                {
                                    toReplace += "1";
                                }
                                else
                                {
                                    toReplace += "0";
                                }
                            }

                            lowerCol.toPrint = lowerCol.toPrint.Insert(
                                higherCol.posCol - lowerCol.posCol, toReplace);
                            lowerCol.toPrint = lowerCol.toPrint.Remove(
                                 higherCol.posCol - lowerCol.posCol + toReplace.Length,
                                 toReplace.Length);

                            //get the tail if higherCol.ToPrint is longer
                            if (higherCol.posCol + higherCol.stringLength >=
                                lowerCol.posCol + lowerCol.stringLength)
                            {
                                int offset = (higherCol.posCol + higherCol.stringLength) -
                                  (lowerCol.posCol + lowerCol.stringLength);

                                lowerCol.toPrint += higherCol.toPrint.Substring(
                                  higherCol.toPrint.Length - offset, offset);
                            }
                            lowerCol.stringLength = lowerCol.toPrint.Length;
                            //step four add new one, make old ones invisible
                            if (higherCol != lowerCol)
                            {
                                higherCol.isVisible = false;
                            }
                        }
                    }
                }



                return existingPieces;
            }
            //TODO inside
            public void PrintMe()
            {
                //TODO INSERT COLOR
                if (isVisible)
                {
                    Console.SetCursorPosition(this.posCol, this.posRow);
                    Console.Write(this.toPrint);
                }
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

            int appSpeed = 300; // lower is faster
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
                player1.activePiece = new Pieces(mainRandomizer.Next(0, 31));
                //allign the new piece to the middle of the area
                player1.activePiece.posCol = (playArea.Width - player1.activePiece.stringLength) / 2;
                //MAIN
                while (player1.activePiece.isMoving)
                {
                    //read player input
                    while (Console.KeyAvailable)
                    {
                        player1.Input = Console.ReadKey();
                        switch (player1.Input.Key)
                        {
                            case ConsoleKey.LeftArrow:
                                player1.activePiece.hSpeed += -1;
                                if(player1.activePiece.hSpeed<-3)
                                {
                                    player1.activePiece.hSpeed = -3;
                                }
                                player1.Input = new ConsoleKeyInfo();
                                break;
                            case ConsoleKey.RightArrow:
                                player1.activePiece.hSpeed += 1;
                                if (player1.activePiece.hSpeed >3)
                                {
                                    player1.activePiece.hSpeed = 3;
                                }
                                player1.Input = new ConsoleKeyInfo();
                                break;
                        }
                    }
                    //check if position left or right is free
                    if (player1.activePiece.CheckSides(player1.activePiece, staticPieces, playArea))
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

                    if (!player1.activePiece.isMoving)
                    {
                        //GAME OVER
                        if(player1.activePiece.posRow==0)
                        {
                            appIsRunning = false;
                        }

                        staticPieces = player1.activePiece.CleanUp(staticPieces);
                        staticPieces.Add(player1.activePiece);
                       
                        //remove hidden blocks
                        for (int i = 0; i < staticPieces.Count; i++)
                        {
                            if (!staticPieces[i].isVisible)
                            {
                                staticPieces.Remove(staticPieces[i]);
                                i--;
                            }
                        }
                    }

                    //INSERT PRINT FINCTION
                    Console.Clear();

                    foreach (Pieces piece in staticPieces) { piece.PrintMe(); }
                    player1.activePiece.PrintMe();

                    Thread.Sleep(appSpeed);
                }
                // Thread.Sleep(appSpeed);
            }

            Console.WriteLine("game over");
            Console.ReadLine();
        }
    }
}
