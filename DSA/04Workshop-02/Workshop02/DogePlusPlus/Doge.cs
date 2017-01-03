using System;
using System.Linq;

namespace DogePlusPlus
{
    public class Doge
    {
        private const int Enemy = -1;
        private const int Dog = 1;

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
                var enemyRow = int.Parse(coords[0]);
                var enemyCol = int.Parse(coords[1]);

                labyrinth[enemyRow, enemyCol] = Doge.Enemy;
            }

            labyrinth[0, 0] = Doge.Dog;
            for (int row = 0; row < labyrinthRows; row++)
            {
                for (int col = 0; col < labyrinthCols; col++)
                {
                    var cellValue = labyrinth[row, col];
                    if (cellValue == Doge.Enemy)
                    {
                        continue;
                    }

                    var rightCellValue = labyrinth[row, col + 1];
                    if (rightCellValue != Doge.Enemy)
                    {
                        labyrinth[row, col + 1] += cellValue;
                    }

                    var bottomCellValue = labyrinth[row + 1, col];
                    if (bottomCellValue != Doge.Enemy)
                    {
                        labyrinth[row + 1, col] += cellValue;
                    }
                }
            }

            Console.WriteLine(labyrinth[labyrinthRows - 1, labyrinthCols - 1]);
        }
    }
}
