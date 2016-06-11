namespace StartUp._01_Shapes_Tests
{
    using ShapesAssembly.AbstractModels;
    using ShapesAssembly.Models;
    using System;
    using System.Linq;

    public static class Array_Of_Shapes
    {
        #region Init static randomizer
        private static Random random;

        static Array_Of_Shapes()
        {
            random = new Random();
        }
        #endregion

        /// <summary>
        /// Write a program that tests the behaviour of the
        /// CalculateSurface() method for different shapes 
        /// (Square, Rectangle, Triangle) stored in an array.
        /// </summary>
        public static void Test_01()
        {
            var shapes = InitArray(random);

            shapes =
                (from shape in shapes
                 orderby shape.GetType().ToString().Length,
                         shape.CalculateSurface()
                 select shape).ToArray();

            var format = "Type: {0, -12}| Area: {1, 8}| Width: {2, 4}| Height: {3, 4}";
            foreach (var shape in shapes)
            {
                Console.WriteLine(
                    format, 
                    shape.ToString()
                        .Split('.')
                        .ToArray()[2], 
                    shape.CalculateSurface(),
                    shape.Width,
                    shape.Height);
            }
        }

        private static Shape[] InitArray(Random random)
        {
            var size = random.Next(10, 99);
            var shapes = new Shape[size];

            for (int index = 0; index < size; index++)
            {
                var type = random.Next(0, 3);
                var width = random.Next(1, 100);
                var height = random.Next(1, 100);
                Shape add;

                switch (type)
                {
                    case 1:
                        add = new Triangle(width, height);
                        break;
                    case 2:
                        add = new Rectangle(width, height);
                        break;
                    default:
                        add = new Square(width);
                        break;
                }

                shapes[index] = add;
            }

            return shapes;
        }
    }
}
