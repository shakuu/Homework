
namespace PointAndMatrix.Tests
{
    using System;
    using Lists;
    using Point;

    class GenericListTesting
    {
        public static void MainTest()
        {
            Console.WriteLine("GenericList<T> Testing: " + Environment.NewLine);

            var myTestingList = new GenericList<Point3D>();

            var rng = new Random();

            var numberOfElements = rng.Next(1, 25);

            for (int i = 0; i < numberOfElements; i++)
            {
                var point = new Point3D(rng.Next(1, 49), rng.Next(1, 49), rng.Next(1, 49));

                myTestingList.Add(point);
            }

            Console.WriteLine("Min: {0}", myTestingList.Min());
            Console.WriteLine("Max: {0}", myTestingList.Max());
            Console.WriteLine("All: {0}", myTestingList.Count);

            foreach (var  point in myTestingList)
            {
                Console.WriteLine(point.ToString());
            }

            Console.WriteLine((myTestingList[0] + myTestingList[1]).ToString());
        }
    }
}
