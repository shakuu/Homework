
namespace _03_Trails_3D
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    class Player
    {
        public List<int> Position;
        public List<int> Speed;

        public Queue<string> Moves;
        public List<List<int>> Trail;

        public bool Crash = false;

        public int Tag;
        public int MovesCounter = 1;

        // Starting positions by cube size
        public Player(int x, int y, int z, bool isFront, int tag)
        {
            this.Tag = tag;
            // Center of the Front/ Back
            // side
            x = (x - 1) / 2;
            y = (y - 1) / 2;
            // Front or back
            z = isFront ? 0 : z - 1;

            this.Position = new List<int>();
            this.Position.Add(x);
            this.Position.Add(y);
            this.Position.Add(z);

            // Mark current position on the cube.
            Trails3D.cube[Position[0], Position[1], Position[2]] = Tag;

            // By default players are moving towards 
            // each other.
            this.Speed = new List<int>();
            this.Speed.Add(0);
            this.Speed.Add(0);
            this.Speed.Add(0);

            this.Moves = new Queue<string>();
            this.Trail = new List<List<int>>();
        }

        public bool HasMoves()
        {
            return this.Moves.Count() > 0 ? true : false;
        }

        public void Move()
        {
            // Change Direction
            this.GetDirection();

            var nextPosition = GetNextPosition();
            // Check Collision 
            // 0 -> noone has been there before
            if (Trails3D.cube[nextPosition[0], nextPosition[1], nextPosition[2]] == 0)
            {
                Position[0] = nextPosition[0];
                Position[1] = nextPosition[1];
                Position[2] = nextPosition[2];

                Trails3D.cube[Position[0], Position[1], Position[2]] = Tag;
            }
            else
            {
                Position[0] = nextPosition[0];
                Position[1] = nextPosition[1];
                Position[2] = nextPosition[2];

                Crash = true;
            }

            MovesCounter++;
        }

        private List<int> GetNextPosition()
        {
            var result = new int[3];

            // EDGES
            // Moving by Y
            if (Speed[1] == 1 && Position[1] == Trails3D.dims[1] - 1 && Position[2] == 0)
            {
                Speed[1] = 0;
                Speed[2] = 1;
            }
            else if (Speed[1] == 1 && Position[1] == Trails3D.dims[1] - 1 && Position[2] == Trails3D.dims[2] - 1)
            {
                Speed[1] = 0;
                Speed[2] = -1;
            }
            else if (Speed[1] == -1 && Position[1] == 0 && Position[2] == 0)
            {
                Speed[1] = 0;
                Speed[2] = 1;
            }
            else if (Speed[1] == -1 && Position[1] == 0 && Position[2] == Trails3D.dims[2] - 1)
            {
                Speed[1] = 0;
                Speed[2] = -1;
            }
            // Moving by Z 
            else if (Speed[2] == 1 && Position[2] == Trails3D.dims[1] - 1 && Position[1] == 0)
            {
                Speed[1] = 1;
                Speed[2] = 0;
            }
            else if (Speed[2] == 1 && Position[2] == Trails3D.dims[1] - 1 && Position[1] == Trails3D.dims[1] - 1)
            {
                Speed[1] = -1;
                Speed[2] = 0;
            }
            else if (Speed[2] == -1 && Position[2] == 0 && Position[1] == Trails3D.dims[1] - 1)
            {
                Speed[1] = -1;
                Speed[2] = 0;
            }
            else if (Speed[2] == -1 && Position[2] == 0 && Position[1] == 0)
            {
                Speed[1] = 1;
                Speed[2] = 0;
            }
            else if (Speed[0] == 1 && Position[0] == Trails3D.dims[0] - 1)
            {
                this.Crash = true;
            }
            else if (Speed[0] == -1 && Position[0] == 0)
            {
                this.Crash = true;
            }

            result[0] = this.Position[0] + Speed[0];
            result[1] = this.Position[1] + Speed[1];
            result[2] = this.Position[2] + Speed[2];

            return result.ToList();
        }

        private void GetDirection()
        {
            var next = this.Moves.Dequeue();

            if (next == "M")
            {
                // nothing
                return;
            }

            if (next == "L")
            {
                this.TurnLeft();
            }
            else if (next == "R")
            {
                this.TurnRight();
            }

            return;
        }

        private void TurnLeft()
        {
            // Moving Up/ Down Rows
            if (this.Speed[0] != 0)
            {
                this.Speed[0] = 0;
                this.Speed[1] = 0;
                this.Speed[2] = 0;

                // Front Left Edge/ Left Side
                if (this.Position[1] == 0 && this.Position[2] >= 0)
                {
                    this.Speed[2] = 1;
                }

                // Edge Front Right
                if (this.Position[1] <= Trails3D.dims[1] - 1 && this.Position[2] == 0)
                {
                    this.Speed[1] = -1;
                }

                // Black Left
                if (this.Position[1] >= 0 && this.Position[2] == Trails3D.dims[2] - 1)
                {
                    this.Speed[1] = 1;
                }

                // Back Right
                if (this.Position[1] == Trails3D.dims[1] - 1 && this.Position[2] <= Trails3D.dims[2] - 1)
                {
                    this.Speed[2] = -1;
                }
            }
            // If moving side to side
            else if (this.Speed[1] != 0 || this.Speed[2] != 0)
            {
                if (this.Speed[1] != 0)
                {
                    if (Speed[1] < 0 && Position[2] == 0)
                    {
                        Speed[0] = 1;
                    }
                    else if (Speed[1] < 0 && Position[2] == Trails3D.dims[2] - 1)
                    {
                        Speed[0] = -1;
                    }
                    else if (Speed[1] > 0 && Position[2] == 0)
                    {
                        Speed[0] = -1;
                    }
                    else if (Speed[1] > 0 && Position[2] == Trails3D.dims[2] - 1)
                    {
                        Speed[0] = 1;
                    }

                }
                else if (this.Speed[2] != 0)
                {
                    if (Speed[2] < 0 && Position[1] == 0)
                    {
                        Speed[0] = 1;
                    }
                    else if (Speed[2] < 0 && Position[1] == Trails3D.dims[1] - 1)
                    {
                        Speed[0] = -1;
                    }
                    else if (Speed[2] > 0 && Position[1] == 0)
                    {
                        Speed[0] = -1;
                    }
                    else if (Speed[2] > 0 && Position[1] == Trails3D.dims[1] - 1)
                    {
                        Speed[0] = 1;
                    }
                }

                this.Speed[1] = 0;
                this.Speed[2] = 0;
            }

            return;
        }

        private void TurnRight()
        {
            // Moving Up/ Down Rows
            if (this.Speed[0] != 0)
            {
                this.Speed[0] = 0;
                this.Speed[1] = 0;
                this.Speed[2] = 0;

                // Front Left Edge/ Left Side
                if (this.Position[1] == 0 && this.Position[2] >= 0)
                {
                    this.Speed[2] = -1;
                }

                // Edge Front Right
                if (this.Position[1] <= Trails3D.dims[1] - 1 && this.Position[2] == 0)
                {
                    this.Speed[1] = 1;
                }

                // Black Left
                if (this.Position[1] >= 0 && this.Position[2] == Trails3D.dims[2] - 1)
                {
                    this.Speed[1] = -1;
                }

                // Back Right
                if (this.Position[1] == Trails3D.dims[1] - 1 && this.Position[2] <= Trails3D.dims[2] - 1)
                {
                    this.Speed[2] = 1;
                }
            }
            // If moving side to side
            else if (this.Speed[1] != 0 || this.Speed[2] != 0)
            {
                if (this.Speed[1] != 0)
                {
                    this.Speed[0] = this.Speed[1];
                }
                else if (this.Speed[2] != 0)
                {
                    this.Speed[0] = this.Speed[2];
                }

                this.Speed[1] = 0;
                this.Speed[2] = 0;
            }

            return;
        }
    }

    class Trails3D
    {
        public static int[] dims;
        public static int[,,] cube;

        // Player Variables
        static Player red;
        static Player blue;

        static void Input()
        {
            // Line 1: Cube dims
            // Row, Col, Depth
            dims = Console.ReadLine()
                 .Trim()
                 .Split(' ')
                 .Select(int.Parse)
                 .Select(x => x + 1)
                 .ToArray();

            cube = new int[dims[0], dims[1], dims[2]];

            //moves = new List<Queue<string>>();
            // Line 2: Red Player
            red = new Player(dims[0], dims[1], dims[2], true, 1);
            GetMoves(red);
            // Line 3: Blue Player
            blue = new Player(dims[0], dims[1], dims[2], false, 2);
            GetMoves(blue);
        }

        static void GetMoves(Player player)
        {
            //moves.Add(new Queue<string>());
            //var player = moves.Count() - 1;

            var input = Console.ReadLine();

            var isDigit = false;
            var digit = new StringBuilder();

            foreach (var sym in input)
            {
                if (char.IsLetter(sym) && !isDigit)
                {
                    player.Moves.Enqueue(sym.ToString());
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
                        player.Moves.Enqueue(sym.ToString());
                    }

                    isDigit = false;
                    digit.Clear();
                }
            }
        }

        static void TrailsLogic()
        {
            red.Speed[1] = 1;
            blue.Speed[1] = 1;

            while (true)
            {
                // Move
                red.Move();
                blue.Move();

                // Break on crash
                if (red.Crash || blue.Crash) break;
            }

            Console.WriteLine(string.Join(" ", red.Position) + " " + red.MovesCounter + " " + red.Crash);
            Console.WriteLine(string.Join(" ", blue.Position) + " " + blue.MovesCounter + " " + blue.Crash);
        }

        static void Main()
        {
            Input();
            TrailsLogic();
        }
    }
}
