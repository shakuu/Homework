using System;
using System.Text;

namespace Patterns
{
    class Program
    {
        private static string figure = "urd";

        static void Main(string[] args)
        {
            // Right
            // -- connection
            // Up
            // -- connection
            // Up
            // -- connection
            // Left
            var input = int.Parse(Console.ReadLine());
            PrintFigure(input - 1);
        }

        private static void PrintFigure(int iterations)
        {
            if (iterations == 0)
            {
                Console.WriteLine(figure);
                Environment.Exit(0);
            }

            var nextFigure = new StringBuilder();

            // right
            for (int i = figure.Length - 1; i >= 0; i--)
            {
                var letter = figure[i];
                nextFigure.Append(RotateRight(letter.ToString()));
            }

            // connection up
            nextFigure.Append("u");

            // up
            nextFigure.Append(figure);

            // connection right
            nextFigure.Append("r");

            // up
            nextFigure.Append(figure);

            // connection down
            nextFigure.Append("d");

            // left
            for (int i = figure.Length - 1; i >= 0; i--)
            {
                var letter = figure[i];
                nextFigure.Append(RotateLeft(letter.ToString()));
            }

            figure = nextFigure.ToString();

            PrintFigure(iterations - 1);
        }

        private static string RotateLeft(string letter)
        {
            switch (letter)
            {
                case "u":
                    return "r";
                case "r":
                    return "d";
                case "d":
                    return "l";
                case "l":
                    return "u";
                default:
                    throw new ArgumentException();
            }
        }

        private static string RotateRight(string letter)
        {
            switch (letter)
            {
                case "u":
                    return "l";
                case "r":
                    return "u";
                case "d":
                    return "r";
                case "l":
                    return "d";
                default:
                    throw new ArgumentException();
            }
        }
    }
}
