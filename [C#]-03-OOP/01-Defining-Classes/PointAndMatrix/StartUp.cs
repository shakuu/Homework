
namespace PointAndMatrix
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Point;
    using PathUtility;

    class StartUp
    {
        static void Main(string[] args)
        {
            var test = 0;

            var myPath = new Path();

            myPath.AddPoint(new Point3D(0, 0, 0));
            myPath.AddPoint(new Point3D(0, 20, 0));
            myPath.AddPoint(new Point3D(0, 0, 3));
            myPath.AddPoint(new Point3D(0, 60, 0));
            myPath.AddPoint(new Point3D(0, 5, 0));

            //PathStorage.SavePath(myPath, nameof(myPath));
            var newPath =  PathStorage.ReadPath();
        }
    }
}
