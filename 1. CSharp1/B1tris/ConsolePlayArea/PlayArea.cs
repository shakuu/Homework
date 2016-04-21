using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsolePlayArea
{
    public class PlayArea
    {
        public int CanvasWidth;
        public int CanvasHeight;

        public int Width;
        public int Height;

        public int TopRow;
        public int BotRow;

        public ConsoleColor BackgroundColor = ConsoleColor.White;
        public ConsoleColor BorderColor = ConsoleColor.DarkGreen;

        //borders
        public int playAreaSideBorderWidth = 1;
        public int playAreaBottomBorderWidth = 1;

        public string SideBorderSymbol = "█";
        public string BottomBorderSymbol = "▀";
        public string BottomCanvasSymbol = "▄";

        public PlayArea()
        {
            this.Width = 30;
            this.Height = 20;

            this.CanvasWidth = this.Width * 1; // + additional screen for text
            this.CanvasHeight = this.Height / 5 * 6 +1; // + additional space bottom for text

            this.TopRow = (this.CanvasHeight - this.Height) / 2;
            this.BotRow = this.CanvasHeight - ((this.CanvasHeight - this.Height) / 2);
        }
        //TODO:
       
        public void PrintBottomBorder()
        {
            Console.ForegroundColor = ConsoleColor.Black;
            //CHANGING COLORS + change piece color according
            for (int col = this.playAreaSideBorderWidth; col < this.Width - this.playAreaSideBorderWidth; col++)
            {
                Console.SetCursorPosition(col, this.Height);
                Console.Write(this.BottomBorderSymbol);
            }
        }
        //Print PlayArea Bottom Border
        public void PrintBottomBorder(ConsoleColor newColor, int startPos, int Length)
        {
            Console.ForegroundColor = ConsoleColor.Black;
            //CHANGING COLORS + change piece color according
            for (int col = this.playAreaSideBorderWidth; col < this.Width - this.playAreaSideBorderWidth; col++)
            {
                if (col >= startPos && col <= startPos + Length - 1)
                {
                    Console.ForegroundColor = newColor;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Gray;
                }
                Console.SetCursorPosition(col, this.Height);
                Console.Write(this.BottomBorderSymbol);
            }
        }
        //Sides and bttom
        public void printSideBorder()
        {
            //print bottom canvas
            Console.ForegroundColor = this.BorderColor;
            Console.SetCursorPosition(1, this.CanvasHeight - 2);
            Console.Write(new string(this.BottomCanvasSymbol[0], this.Width-2));
            //Print Sides
            for (int i = 0; i < this.CanvasHeight -1; i++)
            {
                Console.SetCursorPosition(0, i);
                Console.Write(this.SideBorderSymbol);
                Console.SetCursorPosition(this.Width - 1, i);
                Console.Write(this.SideBorderSymbol);
            }
        }
        //Print Score
        public void PrintScore(int Score)
        {
            Console.SetCursorPosition(this.playAreaBottomBorderWidth + 1,
                this.CanvasHeight - 3);

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("Score:{0,1:D6}", Score);
        }
        //Print Score and Name
        public void PrintScore(int Score, string playerName)
        {
            Console.ForegroundColor = ConsoleColor.Blue;

            Console.SetCursorPosition(this.Width - 2 - playerName.Length, this.CanvasHeight - 3);
            Console.Write(playerName);

            Console.SetCursorPosition(this.playAreaBottomBorderWidth + 1,
                this.CanvasHeight - 3);
            Console.Write("Score:{0,1:D6}", Score);
        }
        //print score name and speed
        public void PrintScore(int Score, string playerName, int Speed)
        {
            Console.ForegroundColor = ConsoleColor.Blue;

            string printSpeed = "Spd:";

            Console.SetCursorPosition(this.Width - 2 - printSpeed.Length - 2, 0);
            Console.Write("{0}{1,1:D2}", printSpeed, (500- Speed) / 100);

            Console.SetCursorPosition(this.Width - 2 - playerName.Length, this.CanvasHeight - 3);
            Console.Write(playerName);

            Console.SetCursorPosition(this.playAreaBottomBorderWidth + 1,
                this.CanvasHeight - 3);
            Console.Write("Score:{0,1:D6}", Score);
        }

        //print score name and speed and int number
        public void PrintScore(int Score, string playerName, int Speed, int B1tNum)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            //b1tnum
            Console.SetCursorPosition(this.playAreaSideBorderWidth + 1, 0);
            Console.Write("B1t:{0,1:D2}", B1tNum);

            //speed
            string printSpeed = "Spd:";

            Console.SetCursorPosition(this.Width - 2 - printSpeed.Length - 2, 0);
            Console.Write("{0}{1,1:D2}", printSpeed, (500 - Speed) / 100);

            //playername
            Console.SetCursorPosition(this.Width - 2 - playerName.Length, this.CanvasHeight - 4);
            Console.Write(playerName);

            //score
            Console.SetCursorPosition(this.playAreaSideBorderWidth + 1,
                this.CanvasHeight - 4);
            Console.Write("Score:{0,1:D6}", Score);
        }
    }


}
