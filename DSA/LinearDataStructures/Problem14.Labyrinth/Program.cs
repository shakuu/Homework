using System;

namespace Problem14.Labyrinth
{
    public class Program
    {
        private const int LabyrinthSize = 6;
        private const string FullCell = "x";
        private const string StartCell = "*";

        private static bool[,] visitedCells = new bool[Program.LabyrinthSize, Program.LabyrinthSize];

        private static string[,] labyrinth = new[,]
            {
                { "0", "0", "0", "x", "0", "x"},
                { "0", "x", "0", "x", "0", "x"},
                { "0", "*", "x", "0", "x", "0"},
                { "0", "x", "0", "0", "0", "0"},
                { "0", "0", "0", "x", "x", "0"},
                { "0", "0", "0", "x", "0", "x"},
            };

        public static void Main()
        {
            Program.GetPath(2, 0, 0);

            for (int i = 0; i < Program.LabyrinthSize; i++)
            {
                for (int j = 0; j < Program.LabyrinthSize; j++)
                {
                    if (Program.labyrinth[i, j] == "0")
                    {
                        Program.labyrinth[i, j] = "u";
                    }

                    Console.Write(Program.labyrinth[i, j] + " ");
                }

                Console.WriteLine();
            }
        }

        private static void GetPath(int row, int col, int stepCount)
        {
            Program.visitedCells[row, col] = true;

            var currentCellValue = int.Parse(Program.labyrinth[row, col]);
            if (currentCellValue == 0 || stepCount < currentCellValue)
            {
                Program.labyrinth[row, col] = (++stepCount).ToString();
            }

            if (Program.IsInBounds(row, col - 1) && Program.IsEmpty(row, col - 1) && Program.ShouldBeVisited(row, col - 1, stepCount))
            {
                Program.GetPath(row, col - 1, stepCount);
            }

            if (Program.IsInBounds(row - 1, col) && Program.IsEmpty(row - 1, col) && Program.ShouldBeVisited(row - 1, col, stepCount))
            {
                Program.GetPath(row - 1, col, stepCount);
            }

            if (Program.IsInBounds(row, col + 1) && Program.IsEmpty(row, col + 1) && Program.ShouldBeVisited(row, col + 1, stepCount))
            {
                Program.GetPath(row, col + 1, stepCount);
            }

            if (Program.IsInBounds(row + 1, col) && Program.IsEmpty(row + 1, col) && Program.ShouldBeVisited(row + 1, col, stepCount))
            {
                Program.GetPath(row + 1, col, stepCount);
            }
        }

        private static bool IsEmpty(int row, int col)
        {
            return Program.labyrinth[row, col] != Program.FullCell && Program.labyrinth[row, col] != Program.StartCell;
        }

        private static bool ShouldBeVisited(int row, int col, int stepCount)
        {
            var currentCellValue = int.Parse(Program.labyrinth[row, col]);
            var shouldUpdate = (currentCellValue == 0 || stepCount < currentCellValue);

            return !Program.visitedCells[row, col] || shouldUpdate;
        }

        private static bool IsInBounds(int row, int col)
        {
            var rowIsInBounds = 0 <= row && row < Program.LabyrinthSize;
            var colIsInBounds = 0 <= col && col < Program.LabyrinthSize;

            return rowIsInBounds && colIsInBounds;
        }
    }
}
