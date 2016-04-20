using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B1tClass
{
    public class B1ts
    {
        public int PosX = 0;
        public int PosY = 0;
        public string toPrint = "";
        public ConsoleColor Color = new ConsoleColor();
        public bool isMoving = true;

        public int hSpeed = 0;
        public int vSpeed = 1;

        public B1ts(int rndNumber)
        {
            this.toPrint = (Convert.ToString(rndNumber, 2).PadLeft(32, '0')).Substring(24, 8);
            this.toPrint = this.toPrint.TrimStart('0');
            this.toPrint = this.toPrint.TrimEnd('0');

            //TODO assign COLOR
        }

        //TODO 
        //MOVE LEFT
        //MOVE RIGHT
        public bool MoveSides()
        {
            bool canMove = true;



            return canMove;
        }
        //PRINT
    }
}
