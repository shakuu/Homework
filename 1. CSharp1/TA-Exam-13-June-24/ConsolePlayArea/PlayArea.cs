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

        public PlayArea()
        {
            this.CanvasWidth = 30;
            this.CanvasHeight = 24;

            this.Width = this.CanvasWidth * 1;
            this.Height = this.CanvasHeight * 5 / 6;

            this.TopRow = (this.CanvasHeight - this.Height) / 2;
            this.BotRow = this.CanvasHeight - ((this.CanvasHeight - this.Height) / 2);
        }
        //TODO PRINT
    }

   
}
