
namespace _02_Kitty
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    class Kitty // 100
    {
        const char Soul = '@';
        const char Food = '*';
        const char Deadlock = 'x';


        private static int[] moves;
        private static StringBuilder path;

        static int souls = 0;
        static int foods = 0;
        static int deadlocks = 0;
        private static bool[] isVisited;
        private static int cat;
        static bool isDeadlocked = false;
        static int deadlockedPos = 0;

        static void Input()
        {
            path = new StringBuilder().Append(Console.ReadLine().Trim());

            moves = Console.ReadLine()
                .Trim()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
        }

        static void CatMove()
        {
            cat = 0;
            isVisited = new bool[path.Length];

            for (int move = 0; move < moves.Length; move++)
            {
                CheckPosition(cat);

                if (isDeadlocked)
                {
                    deadlockedPos = move;
                    break;
                }

                var nextMove = moves[move];

                cat += nextMove;

                OnPath();
            }

            CheckPosition(cat);
        }

        static void OnPath()
        {
            if (cat < 0)
            {
                while (cat < 0)
                {
                    cat = path.Length + cat;
                }
            }

            else if (cat >= path.Length)
            {
                while (cat >= path.Length)
                {
                    cat = (cat - path.Length);
                }
            }
        }

        static void CheckPosition(int cat)
        {
            var positionContents = path[cat];

            if (positionContents == Soul && !isVisited[cat])
            {
                souls++;
                isVisited[cat] = true;
            }
            else if (positionContents == Food && !isVisited[cat])
            {
                foods++;
                isVisited[cat] = true;
            }
            else if (positionContents == Deadlock)
            {
                deadlocks++;

                // on odd leave food 
                if (cat % 2 == 1)
                {
                    if (foods > 0)
                    {
                        foods--;
                        // Possibly not 
                        path[cat] = Food;
                    }
                    else
                    {
                        isDeadlocked = true;
                    }
                }
                else if (cat % 2 == 0)
                {
                    if (souls > 0)
                    {
                        souls--;
                        path[cat] = Soul;
                    }
                    else
                    {
                        isDeadlocked = true;
                    }
                }
            }
        }

        static void Output()
        {
            if (isDeadlocked)
            {
                Console.WriteLine("You are deadlocked, you greedy kitty!");
                Console.WriteLine("Jumps before deadlock: {0}", deadlockedPos);
            }
            else
            {
                Console.WriteLine("Coder souls collected: {0}", souls);
                Console.WriteLine("Food collected: {0}", foods);
                Console.WriteLine("Deadlocks: {0}", deadlocks);
            }
        }

        static void Main()
        {
            Input();
            CatMove();
            Output();
        }
    }
}
