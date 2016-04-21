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

        public PlayArea()
        {
            this.Width = 30;
            this.Height = 20;

            this.CanvasWidth = this.Width * 1; // + additional screen for text
            this.CanvasHeight = this.Height / 5 * 6; // + additional space bottom for text
            
            this.TopRow = (this.CanvasHeight - this.Height) / 2;
            this.BotRow = this.CanvasHeight - ((this.CanvasHeight - this.Height) / 2);
        }
        //TODO:
        //1. Print Borders
        //2. Print Bottom Border
        //3. Print Score and Player Name
        public void PrintBottomBorder()
        {
            Console.ForegroundColor = ConsoleColor.Black;
            //CHANGING COLORS + change piece color according
            for (int col = this.playAreaSideBorderWidth; col < this.Width-this.playAreaSideBorderWidth; col++)
            {
                Console.SetCursorPosition(col, this.Height);
                Console.Write(this.BottomBorderSymbol);
            }
        }
        //Print with color
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

        public void printSideBorder()
        {
            Console.ForegroundColor = this.BorderColor;
            for (int i = 0; i < this.CanvasHeight ; i++)
            {
                Console.SetCursorPosition(0, i);
                Console.Write(this.SideBorderSymbol);
                Console.SetCursorPosition(this.Width - 1, i);
                Console.Write(this.SideBorderSymbol);
            }
        }
    }


}
