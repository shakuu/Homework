using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsolePlayArea;
namespace B1tClass
{
    public class B1ts
    {
        private int pfirstX = 0;

        public int firstX
        {
            get
            {
                return pfirstX;
            }
            set
            {
                pfirstX = (int)value;
                UpdateLastX();
            }
        }

        public int lastX = 0;
        public int PosY = 0;
        public string toPrint = "";
        public ConsoleColor Color = new ConsoleColor();
        public bool isMoving = true;

        public int hSpeed = 0;
        public int vSpeed = 1;

        public const int MAXSPEED = 3;

        public B1ts(int rndNumber)
        {
            this.toPrint = (Convert.ToString(rndNumber, 2).PadLeft(32, '0')).Substring(24, 8);
            this.toPrint = this.toPrint.TrimStart('0');
            this.toPrint = this.toPrint.TrimEnd('0');


            //TODO assign COLOR
        }

        public void UpdateLastX()
        {
            this.lastX = this.firstX + this.toPrint.Length - 1;
        }

        //TODO 
        //MOVE LEFT
        //MOVE RIGHT
        public bool canMoveSides(PlayArea Area, List<string> existingBits)
        {
            bool canMove = true;

            //Check 1: Adjust speed withing Bounds
            for (int speed = Math.Abs(this.hSpeed); speed >= 0; speed--)
            {
                if (this.firstX - speed >= 1 && this.hSpeed < 0) // check left
                {
                    this.hSpeed = -speed;
                    break;
                }
                if (this.lastX + speed <= Area.Width - 2 && this.hSpeed > 0) // check right 
                {
                    this.hSpeed = speed;
                    break;
                }
            }

            //Check 2: row below contains any 1s
            if (!existingBits[this.PosY + 1].Contains('1'))
            {
                return true; //if no 1s then always true
            }

            //Check 3 
            string toCheck = existingBits[this.PosY + 1].
                Substring(this.firstX + this.hSpeed, this.toPrint.Length);
            for (int currBit = 0; currBit < toCheck.Length; currBit++)
            {
                if (this.toPrint[currBit] == 1 && toCheck[currBit] == 1)
                {
                    canMove = false;
                }
            }

            return canMove;
        }
        //PRINT
    }
}
