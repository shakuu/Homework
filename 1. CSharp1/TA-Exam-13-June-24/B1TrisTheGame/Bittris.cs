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
        class Pieces
        {
            public int posX = 0; //row
            public int posY = 0; //col
            public int vSpeed = 1;
            public int hSpeed = 0;
            public string toPrint = "";
            public int stringLength;
            public int hasOnes;
            public int Score;
            public ConsoleColor Color;
            public bool isMoving = true;

            public Pieces(string currStr, ConsoleColor currColor)
            {
                this.toPrint = currStr;
                this.Color = currColor;
                this.stringLength = currStr.Length;
                
            }

        }

        static void Main()
        {
            //settings
            const int CanvastWidth = 40;
            const int CanvasHeight = 20;

            Console.BufferWidth = Console.WindowWidth = CanvastWidth;
            Console.BufferHeight = Console.WindowHeight = CanvasHeight;

            Console.BackgroundColor = ConsoleColor.Gray;
            Console.CursorVisible = false;

            Console.Clear();

            int appSpeed = 150;
            bool appIsRunning = true;

            while(appIsRunning)
            {

                Thread.Sleep(appSpeed)
            }

        }
    }
}
