using System;
using System.Linq;

namespace DogePlusPlus
{
    public class Doge
    {
        private const int Enemy = -1;

        public static void Main()
        {
            var coordinates = Console.ReadLine().Split(' ');
            var labyrinthRows = int.Parse(coordinates[0]);
            var labyrinthCols = int.Parse(coordinates[1]);
            var stepsBack = int.Parse(coordinates[2]);

            var labyrinth = new int[labyrinthRows + 1, labyrinthCols + 1];

            var enemiesCoordinates = Console.ReadLine().Split(';').Select(x => x.Trim());
            foreach (var enemyCoordinates in enemiesCoordinates)
            {
                var coords = enemyCoordinates.Split(' ');
                var row = int.Parse(coords[0]);
                var col = int.Parse(coords[1]);

                labyrinth[row, col] = Doge.Enemy;
            }

            labyrinth[0, 0] = 1;
            for (int row = 0; row < labyrinthRows; row++)
            {
                for (int col = 0; col < labyrinthCols; col++)
                {
                    if (labyrinth[row, col] < 0)
                    {
                        continue;
                    }

                    var rightCellValue = labyrinth[row, col + 1];
                    if (rightCellValue >= 0)
                    {
                        labyrinth[row, col + 1] += labyrinth[row, col];
                    }

                    var bottomCellValue = labyrinth[row + 1, col];
                    if (bottomCellValue >= 0)
                    {
                        labyrinth[row + 1, col] += labyrinth[row, col];
                    }
                }
            }

            Console.WriteLine(labyrinth[labyrinthRows - 1, labyrinthCols - 1]);
        }
    }
}
