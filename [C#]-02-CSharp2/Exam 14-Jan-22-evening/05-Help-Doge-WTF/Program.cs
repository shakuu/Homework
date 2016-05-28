
namespace _05_Help_Doge_WTF
{
    using System;
    using System.Numerics;

    class Program
    {
        static void Main()
        {
            string[] nm = Console.ReadLine().Split(' ');
            int n = int.Parse(nm[0]);
            int m = int.Parse(nm[1]);

            nm = Console.ReadLine().Split(' ');
            int fx = int.Parse(nm[0]);
            int fy = int.Parse(nm[1]);

            int k = int.Parse(Console.ReadLine());

            bool[,] matrix = new bool[fx + 1, fy + 1];

            for (int i = 0; i < k; i++)
            {
                nm = Console.ReadLine().Split(' ');
                int x = int.Parse(nm[0]);
                int y = int.Parse(nm[1]);

                if (x <= fx && y <= fy)
                {
                    matrix[x, y] = true;
                }
            }

            BigInteger[,] count = new BigInteger[fx + 1, fy + 1];
            count[0, 0] = 1;

            for (int col = 1; col < count.GetLength(1); col++)
            {
                count[0, col] = matrix[0, col] ? 0 : count[0, col - 1];
            }

            for (int row = 1; row < count.GetLength(0); row++)
            {
                count[row, 0] = matrix[row, 0] ? 0 : count[row - 1, 0];
            }

            for (int row = 1; row < count.GetLength(0); row++)
            {
                for (int col = 1; col < count.GetLength(1); col++)
                {
                    count[row, col] = matrix[row, col] ? 0 : count[row - 1, col] + count[row, col - 1];
                }
            }

            Console.WriteLine(count[fx, fy]);
        }
    }
}
