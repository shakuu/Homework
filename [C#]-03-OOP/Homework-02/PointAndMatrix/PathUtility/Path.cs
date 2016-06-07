
namespace PointAndMatrix.PathUtility
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using Point;

    public class Path : IEnumerable<Point3D>
    {
        private List<Point3D> path;

        public Path()
        {
            this.path = new List<Point3D>();
        }

        public Point3D this[int index]
        {
            get
            {
                return path[index];
            }
        }

        public void AddPoint(Point3D point)
        {
            this.path.Add(point);
        }
        
        public void RemovePoint(int index)
        {
            this.path.RemoveAt(index);
        }

        public IEnumerator<Point3D> GetEnumerator()
        {
            return path.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return path.GetEnumerator();
        }
    }
}
