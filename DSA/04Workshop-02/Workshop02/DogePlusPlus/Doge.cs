using System;
using System.Numerics;

namespace DogePlusPlus
{
    public class Doge
    {
        private const int Enemy = -1;
        private const int Dog = 1;

        public static void Main()
        {
            //var coordinates = Console.ReadLine().Split(' ');
            //var labyrinthRows = int.Parse(coordinates[0]);
            //var labyrinthCols = int.Parse(coordinates[1]);
            //var stepsBack = int.Parse(coordinates[2]);

            //var enemies = new bool[labyrinthRows, labyrinthCols];
            //var enemiesCoordinates = Console.ReadLine().Split(';');
            //foreach (var enemyCoordinates in enemiesCoordinates)
            //{
            //    var coords = enemyCoordinates.Split(' ');
            //    var enemyRow = int.Parse(coords[0]);
            //    var enemyCol = int.Parse(coords[1]);

            //    enemies[enemyRow, enemyCol] = true;
            //}

            //var labyrinth = new BigInteger[stepsBack + 1, labyrinthRows, labyrinthCols];
            //labyrinth[0, 0, 0] = Doge.Dog;
            //for (int layer = 0; layer <= stepsBack; layer++)
            //{
            //    for (int row = 0; row < labyrinthRows; row++)
            //    {
            //        for (int col = 0; col < labyrinthCols; col++)
            //        {
            //            if (enemies[row, col])
            //            {
            //                continue;
            //            }

            //            if (0 < row)
            //            {
            //                labyrinth[layer, row, col] += labyrinth[layer, row - 1, col];
            //            }

            //            if (0 < col)
            //            {
            //                labyrinth[layer, row, col] += labyrinth[layer, row, col - 1];
            //            }

            //            if (layer > 0)
            //            {
            //                if (row < labyrinthRows - 1)
            //                {
            //                    labyrinth[layer, row, col] += labyrinth[layer - 1, row + 1, col];
            //                }

            //                if (col < labyrinthCols - 1)
            //                {
            //                    labyrinth[layer, row, col] += labyrinth[layer - 1, row, col + 1];
            //                }
            //            }
            //        }
            //    }
            //}

            //BigInteger total = 0;
            //for (int i = 0; i <= stepsBack; ++i)
            //{
            //    total += labyrinth[i, labyrinthRows - 1, labyrinthCols - 1];
            //}

            //Console.WriteLine(total);
            string[] str = Console.ReadLine().Split(' ');

            int n = int.Parse(str[0]);
            int m = int.Parse(str[1]);
            int k = int.Parse(str[2]);

            bool[,] wall = new bool[n + 1, m + 1];

            str = Console.ReadLine().Split(';');
            foreach (var x in str)
            {
                var s = x.Split(' ');
                wall[int.Parse(s[0]), int.Parse(s[1])] = true;
            }

            var table = new BigInteger[k + 1, n, m];
            table[0, 0, 0] = 1;

            for (int t = 0; t <= k; ++t)
            {
                for (int i = 0; i < n; ++i)
                {
                    for (int j = 0; j < m; ++j)
                    {
                        if (wall[i, j])
                        {
                            continue;
                        }

                        if (i > 0)
                        {
                            table[t, i, j] += table[t, i - 1, j];
                        }
                        if (j > 0)
                        {
                            table[t, i, j] += table[t, i, j - 1];
                        }
                        if (t > 0)
                        {
                            if (i < n - 1)
                            {
                                table[t, i, j] += table[t - 1, i + 1, j];
                            }
                            if (j < m - 1)
                            {
                                table[t, i, j] += table[t - 1, i, j + 1];
                            }
                        }
                    }
                }
            }

            BigInteger total = 0;
            for (int i = 0; i <= k; ++i)
            {
                total += table[i, n - 1, m - 1];
            }

            Console.WriteLine(total);
        }
    }
}
