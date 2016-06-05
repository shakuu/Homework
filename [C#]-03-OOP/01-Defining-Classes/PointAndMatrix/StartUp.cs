
namespace PointAndMatrix
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Point;
    using PathUtility;
    using Lists;

    class StartUp
    {
        static void Main(string[] args)
        {
            var myList = new GenericList<Point3D>();
            var myList2 = new GenericList<int>();
            myList2.Add(0);
            myList2.Add(1);

            myList.Add(new Point3D(0, 0, 0));
            myList.Insert(0, new Point3D(1, 1, 1));
            myList.Remove(1);
            myList.Add(new Point3D(2, 2, 2));
            myList.Add(new Point3D(3, 2, 2));
            myList.Add(new Point3D(4, 2, 2));
            myList.Add(new Point3D(5, 2, 2));
            myList.Add(new Point3D(6, 2, 2));
            myList.Insert(3, new Point3D(7, 2, 2));
            myList.Remove(4);
            
        }
        
    }
}
