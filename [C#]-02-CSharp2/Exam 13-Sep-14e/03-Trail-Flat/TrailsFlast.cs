
namespace _03_Trail_Flat
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    class Player
    {
        private int StartX;
        private int StartY;

        public int ManhattanDistance = 0;
        public int PosX;
        public int PosY;
        public int NextX;
        public int NextY;
        public int SpeedX;
        public int SpeedY;
        public int Steps;
        public int Tag;
        public string NextMove;
        public bool Crash;
        public Queue<string> Moves;

        public Player(int x, int y, int tag)
        {
            this.StartX = x;
            this.StartY = y;
            this.PosX = x;
            this.PosY = y;
            this.NextX = 0;
            this.NextY = 0;
            this.SpeedX = 0;
            this.SpeedY = 0;
            this.Tag = tag;
            this.Steps = 0;
            this.NextMove = "";
            this.Crash = false;
            this.Moves = new Queue<string>();
        }

        public void GetMoves()
        {
            //moves.Add(new Queue<string>());
            //var player = moves.Count() - 1;

            var input = Console.ReadLine();

            // REMOVE Ms After L/ R
            for (int chr = 0; chr < input.Length; chr++)
            {
                if (input[chr] == 'L' || input[chr] == 'R')
                {
                    if (input[chr+1] == 'M')
                    {
                        input = input.Remove(chr + 1, 1);
                    }
                }
            }

            var isDigit = false;
            var digit = new StringBuilder();

            foreach (var sym in input)
            {
                if (char.IsLetter(sym) && !isDigit)
                {
                    this.Moves.Enqueue(sym.ToString());
                }
                else if (char.IsDigit(sym))
                {
                    isDigit = true;
                    digit.Append(sym);
                }
                else if (char.IsLetter(sym) && isDigit)
                {
                    // Enque the appropriate number of moves
                    var counter = int.Parse(digit.ToString());

                    for (int i = 0; i < counter; i++)
                    {
                        this.Moves.Enqueue(sym.ToString());
                    }

                    isDigit = false;
                    digit.Clear();
                }
            }
        }

        public void Move()
        {
            this.NextMove = this.Moves.Dequeue();

            // Get next position.
            if      (NextMove == "L") TurnLeft();
            else if (NextMove == "R") TurnRight();

            NextX = PosX + SpeedX;
            NextY = PosY + SpeedY;

            // Check Out Of Range
            if (CheckAreaBounds())
            {
                // Check colision.
                if (TrailsFlat.area[NextX, NextY] != 0)
                {
                    this.Crash = true;

                    PosX = NextX;
                    PosY = NextY;
                    Steps++;
                }
                else
                {
                    PosX = NextX;
                    PosY = NextY;
                    Steps++;

                    TrailsFlat.area[PosX, PosY] = Tag;
                }
            }
        }

        private bool CheckAreaBounds()
        {
            // Out Of Bounds X = crash
            if (NextX < 0 || NextX >= TrailsFlat.area.GetLength(0))
            {
                this.Crash = true;
                return false;
            }

            if (NextY < 0) NextY = TrailsFlat.area.GetLength(1) - 1;
            if (NextY > TrailsFlat.area.GetLength(1) - 1) NextY = 0;
            
            return true;
        }

        private void TurnLeft()
        {
            if (SpeedX != 0)
            {
                SpeedY = SpeedX;
                SpeedX = 0;
            }
            else if (SpeedY != 0)
            {
                SpeedX = -SpeedY;
                SpeedY = 0;
            }
        }

        private void TurnRight()
        {
            if (SpeedX != 0)
            {
                SpeedY = -SpeedX;
                SpeedX = 0;
            }
            else if (SpeedY != 0)
            {
                SpeedX = SpeedY;
                SpeedY = 0;
            }
        }

        public void FlushMovesQueue()
        {
            while(this.Moves.Count > 0)
            {
                this.Move();
                if (this.Crash) break;
            }
        }

        public int GetManhattanDistance()
        {
            var distanceX = Math.Abs(this.StartX - this.PosX);
            var distanceY = Math.Abs(this.StartY - this.PosY);

            this.ManhattanDistance = distanceX + distanceY;

            return this.ManhattanDistance;
        }
    }

    class TrailsFlat
    {
        public static int[,] area;

        static Player red;
        static Player blue;

        static void Input()
        {
            // Get Area dimensions
            // Input X Y Z 
            // Dimensions: X x 2Y + 2Z
            // Add plus 1 to all dimensions
            // Moving on edges.
            var dimensions = Console.ReadLine()
                .Trim()
                .Split(' ')
                .Select(int.Parse)
                .Select(x => x + 1)
                .ToArray();

            var areaX = dimensions[1];
            var areaY = dimensions[0]
                      + dimensions[0]
                      + dimensions[2]
                      + dimensions[2];

            // Create the area.
            area = new int[areaX, areaY];

            // Starting Positions for the players
            // 1. Red
            var startPosX = (dimensions[1] - 1) / 2;
            var startPosY1 = (dimensions[0] - 1) / 2;
            var startPosY2 = startPosY1 + dimensions[0] + dimensions[2];

            // Create Players
            red = new Player(startPosX, startPosY1, 1);
            blue = new Player(startPosX, startPosY2, 2);

            // Get Moves for each player
            red.GetMoves();
            blue.GetMoves();
        }

        static void PrintArea()
        {
            for (int row = 0; row < area.GetLength(0); row++)
            {
                for (int col = 0; col < area.GetLength(1); col++)
                {
                    Console.Write(area[row, col]);
                }
                Console.WriteLine();
            }
        }

        static void Output()
        {
            if (red.Crash && blue.Crash) Console.WriteLine("DRAW");
            else if (red.Crash) Console.WriteLine("BLUE");
            else if (blue.Crash) Console.WriteLine("RED");
            
            red.FlushMovesQueue();
            Console.WriteLine(red.GetManhattanDistance());
        }

        static void Trails()
        {
            red.SpeedY = 1;
            blue.SpeedY = -1;

            area[red.PosX, red.PosY] = red.Tag;
            area[blue.PosX, blue.PosY] = blue.Tag;

            while (true)
            {
                red.Move();
                blue.Move();

                // TESTING
                //Console.Clear();
                //PrintArea();

                if (red.Crash || blue.Crash) break;
            }
        }

        static void Main()
        {
            Input();
            Trails();
            Output();
        }
    }
}
