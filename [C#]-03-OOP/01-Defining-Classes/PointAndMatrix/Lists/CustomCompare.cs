
namespace PointAndMatrix.Lists
{
    using System;
    using System.Collections.Generic;

    class CustomCompare
    {
        public static int LargerThen<T>(T a, T b) where T : IComparable<T>
        {
            // Result
            // a > b = 1
            // a < b = -1
            // a == b = 0;
            var result = Comparer<T>.Default.Compare(a, b);

            return result;
        }

        public static T Min<T>(GenericList<T> list) where T:IComparable<T>
        {
            var min = list[0];

            for (int i = 0; i < list.Count; i++)
            {
                var result = Comparer<T>.Default.Compare(min, list[i]);

                if (result == 1) min = list[i];
            }

            return min;
        }

        public static T Max<T>(GenericList<T> list) where T : IComparable<T>
        {
            var max = list[0];

            for (int i = 0; i < list.Count; i++)
            {
                var result = Comparer<T>.Default.Compare(max, list[i]);

                if (result == -1) max = list[i];
            }

            return max;
        }
    }
}
