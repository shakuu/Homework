
namespace _03_Trails_3D
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    class Trails3D
    {
        static int[,,] cube;
        static List<Queue<string>> moves;

        static void Input()
        {
            // Line 1: Cube dims
            // Row, Col, Depth
            var dims = Console.ReadLine()
                .Trim()
                .Split(' ')
                .Select(int.Parse)
                .Select(x => x + 1)
                .ToArray();

            cube = new int[dims[0], dims[1], dims[2]];

            moves = new List<Queue<string>>();
            // Line 2: Red Player
            GetMoves();
            // Line 3: Blue Player
            GetMoves();
        }

        static void GetMoves()
        {
            moves.Add(new Queue<string>());
            var player = moves.Count() - 1;

            var input = Console.ReadLine();

            var isDigit = false;
            var digit = new StringBuilder();

            foreach (var sym in input)
            {
                if (char.IsLetter(sym) && !isDigit)
                {
                    moves[player].Enqueue(sym.ToString());
                }
                else if (char.IsDigit(sym))
                {
                    isDigit = true;
                    digit.Append(sym);
                }
                else if (char.IsLetter(sym) && isDigit)
                {
                    // Enque the appropriate number of moves
                    var counter = int.Parse( digit.ToString());

                    for (int i = 0; i < counter; i++)
                    {
                        moves[player].Enqueue(sym.ToString());
                    }

                    isDigit = false;
                    digit.Clear();
                }
            }
        }

        static void Main()
        {
            Input();
        }
    }
}
