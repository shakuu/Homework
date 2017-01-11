using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guards
{
    class Guards
    {
        static void Main(string[] args)
        {
            var mazeSize = Console.ReadLine().Split(' ').ToArray();
            var mazeRows = long.Parse(mazeSize[0]);
            var mazeCols = long.Parse(mazeSize[1]);

            var maze = new long[mazeRows, mazeCols];

            var guardsCount = long.Parse(Console.ReadLine());
            for (long i = 0; i < guardsCount; i++)
            {
                var nextCommand = Console.ReadLine().Split(' ').ToArray();

                var guardRow = long.Parse(nextCommand[0]);
                var guardCol = long.Parse(nextCommand[1]);
                var guardDir = nextCommand[2];

                maze[guardRow, guardCol] = -1;

                // U, D, L and R
                if (guardDir == "U" && guardRow > 0)
                {
                    if (maze[guardRow - 1, guardCol] != -1)
                    {
                        maze[guardRow - 1, guardCol] = 2;
                    }
                }
                else if (guardDir == "D" && guardRow < mazeRows - 1)
                {
                    if (maze[guardRow + 1, guardCol] != -1)
                    {
                        maze[guardRow + 1, guardCol] = 2;
                    }
                }
                else if (guardDir == "R" && guardCol < mazeCols - 1)
                {
                    if (maze[guardRow, guardCol + 1] != -1)
                    {
                        maze[guardRow, guardCol + 1] = 2;
                    }
                }
                else if (guardDir == "L" && guardCol > 0)
                {
                    if (maze[guardRow, guardCol - 1] != -1)
                    {
                        maze[guardRow, guardCol - 1] = 2;
                    }
                }
            }

            if (maze[0, 0] == -1)
            {
                Console.WriteLine("Meow");
                return;
            }

            for (long row = 0; row < mazeRows; row++)
            {
                for (long col = 0; col < mazeCols; col++)
                {
                    if (maze[row, col] == -1)
                    {
                        continue;
                    }

                    maze[row, col]++;

                    if (row > 0 && col > 0)
                    {
                        var upVal = maze[row - 1, col];
                        var leftVal = maze[row, col - 1];

                        if (upVal == -1 && leftVal == -1)
                        {
                            maze[row, col] = -1;
                        }

                        else if (upVal > 0 && leftVal > 0)
                        {
                            maze[row, col] += Math.Min(upVal, leftVal);
                        }

                        else if (upVal == -1)
                        {
                            maze[row, col] += leftVal;
                        }

                        else if (leftVal == -1)
                        {
                            maze[row, col] += upVal;
                        }
                        else
                        {
                            maze[row, col] = -1;
                        }
                    }
                    else if (row > 0 && col <= 0)
                    {
                        var upVal = maze[row - 1, col];
                        if (upVal == -1)
                        {
                            maze[row, col] = -1;
                        }
                        else
                        {
                            maze[row, col] += upVal;
                        }
                    }
                    else if (col > 0 && row <= 0)
                    {
                        var leftVal = maze[row, col - 1];
                        if (leftVal == -1)
                        {
                            maze[row, col] = -1;
                        }
                        else
                        {
                            maze[row, col] += leftVal;
                        }
                    }

                    //var downValue = long.MaxValue;
                    //if (row > 0)
                    //{
                    //    downValue = maze[row - 1, col];
                    //    downValue = downValue != -1 ? downValue : long.MaxValue;
                    //}

                    //var rightValue = long.MaxValue;
                    //if (col > 0)
                    //{
                    //    rightValue = maze[row, col - 1];
                    //    rightValue = rightValue != -1 ? rightValue : long.MaxValue;
                    //}

                    //if (row > 0 || col > 0)
                    //{
                    //    maze[row, col] += Math.Min(downValue, rightValue) + 1;

                    //    if (maze[row, col] < -1)
                    //    {
                    //        maze[row, col] = long.MaxValue;
                    //    }
                    //}
                }
            }

            if (maze[mazeRows - 1, mazeCols - 1] <= 0)
            {
                Console.WriteLine("Meow");
                return;
            }

            Console.WriteLine(maze[mazeRows - 1, mazeCols - 1]);
        }
    }
}
