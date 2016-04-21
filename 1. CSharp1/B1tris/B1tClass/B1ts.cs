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
        public int lastX = 0;
        public int PosY = 0;
        public string toPrint = "";
        public ConsoleColor Color = ConsoleColor.Blue;
        public bool isMoving = true;
        
        public int intValue;
        public int Score = 0;

        public int hSpeed = 0;
        public int vSpeed = 1;
        public const int MAXSPEED = 3;

        public int prevX = 0;
        public int prevY = 0;
        //update las X 
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


        public B1ts(int rndNumber)
        {
            this.toPrint = (Convert.ToString(rndNumber, 2).PadLeft(32, '0')).Substring(24, 8);
            this.toPrint = this.toPrint.TrimStart('0');
            this.toPrint = this.toPrint.TrimEnd('0');

            this.intValue = Convert.ToInt32(this.toPrint, 2);

            this.Score = rndNumber;
            //TODO assign COLOR
        }

        public void UpdateLastX()
        {
            this.lastX = this.firstX + this.toPrint.Length - 1;
        }
        //Move LEFT/ RIGHT
        public bool canMoveSides(PlayArea Area, B1tTracker existingBits)
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
            if (!existingBits.rowTracker[this.PosY].Contains('1'))
            {
                return true; //if no 1s then always true
            }

            //Check3
            int newspeed = 0;
            for (int col = 0; col <= Math.Abs(this.hSpeed); col++)
            {
                if (existingBits.rowTracker[this.PosY][this.firstX - col] == '1' && this.hSpeed < 0)
                {
                    newspeed = -col + 1;
                    break;
                }
                else if (this.hSpeed < 0)
                { newspeed = -col; }
                if (existingBits.rowTracker[this.PosY][this.lastX + col] == '1' && this.hSpeed > 0)
                {
                    newspeed = col - 1;
                    break;
                }
                else if (this.hSpeed > 0)
                { newspeed = col; }
            }
            this.hSpeed = newspeed;

            return canMove;
        }
        //Move DOWN
        public bool canMoveDown(PlayArea Area, B1tTracker existingBits)
        {
            bool canMove = true;

            //Check 0; Out of bounds
            if (this.PosY + this.vSpeed >= Area.Height)
            {
                return false;
            }

            //check 1: if row contains ANY 1s
            if (!existingBits.rowTracker[this.PosY + 1].Contains('1'))
            {
                return true;
            }

            string toCheck = existingBits.rowTracker[this.PosY + 1].Substring(this.firstX, this.toPrint.Length);
            toCheck = toCheck.Replace(' ', '0');
            int Check = Convert.ToInt32(toCheck, 2);

            if ((Check & this.intValue) > 0)
            {
                canMove = false;
            }

            return canMove;
        }
        //PRINT
        public void PrintOne()
        {
            //clear previous position
            Console.SetCursorPosition(this.prevX, this.prevY);
            Console.Write(new string(' ', this.toPrint.Length));
            //print on new positions
            Console.ForegroundColor = this.Color;
            Console.SetCursorPosition(this.firstX, this.PosY);
            Console.Write(this.toPrint);
        }
    }

    public class B1tTracker
    {
        public List<string> rowTracker = new List<string>();
        public List<int> scoreTracker = new List<int>();

        public void UpdateRow(B1ts B1t)
        {
            //get the string to combine
            string toCheck = this.rowTracker[B1t.PosY].Substring(B1t.firstX, B1t.toPrint.Length);
            toCheck = toCheck.Replace(' ', '0');
            int Check = Convert.ToInt32(toCheck, 2);
            //combine
            Check = Check | B1t.intValue;
            toCheck = Convert.ToString(Check, 2);
            //insert new string
            this.rowTracker[B1t.PosY] = this.rowTracker[B1t.PosY].Insert(B1t.firstX, toCheck);
            this.rowTracker[B1t.PosY] = this.rowTracker[B1t.PosY].Remove(B1t.lastX + 1, toCheck.Length);
        }

        public int isFullRow(B1ts B1t)
        {
            int Score = 0;

            if (this.rowTracker[B1t.PosY].Contains('0') ||
               this.rowTracker[B1t.PosY].Contains(' '))
            {
                return 0;
            }

            //get the score
            Score = this.scoreTracker[B1t.PosY] * 2;
            //shift Rows down
            for (int row = B1t.PosY; row>0; row--)
            {
                this.rowTracker[row] = this.rowTracker[row - 1];
                this.scoreTracker[row] = this.scoreTracker[row - 1];
            }
            //reset row 0
            this.scoreTracker[0] = 0;
            this.rowTracker[0] = this.rowTracker[0].Replace('0', ' ' );
            this.rowTracker[0] = this.rowTracker[0].Replace('1', ' ');

            return Score;
        }

        public void PrintAll(int BorderSize)
        {
            for (int row = 0; row < this.rowTracker.Count; row++)
            {
                Console.ForegroundColor = ConsoleColor.Black;

                Console.SetCursorPosition(0 + BorderSize, row);
                Console.Write(this.rowTracker[row].Substring(BorderSize, 
                    this.rowTracker[row].Length - 2 * BorderSize));
            }
        }
    }
}
