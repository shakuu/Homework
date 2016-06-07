
namespace Homework3.Extensions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Students;

    public static class IEnumerableExtension
    {
        public static T Sum<T>(IEnumerable<T> collection)
        {
            dynamic sum = 0;

            foreach (var item in collection)
            {
                dynamic element = item;

                sum += element;
            }

            return sum;
        }

        public static T Average<T>(IEnumerable<T> collection)
        {
            dynamic sum = 0;

            foreach (var item in collection)
            {
                dynamic element = item;

                sum += element;
            }

            return sum / collection.Count();
        }

        public static T Product<T>(IEnumerable<T> collection)
        {
            dynamic sum = 0;

            foreach (var item in collection)
            {
                dynamic element = item;

                sum *= element;
            }

            return sum;
        }

        public static T Min<T>(IEnumerable<T> collection)
        {
            dynamic min = collection.ElementAt(0);

            foreach (var item in collection)
            {
                dynamic element = item;

                if (min > element)
                    min = element;
            }

            return min;
        }

        public static T Max<T>(IEnumerable<T> collection)
        {
            dynamic max = collection.ElementAt(0);

            foreach (var item in collection)
            {
                dynamic element = item;

                if (max < element)
                    max = element;
            }

            return max;
        }

        public static ClassOfStudents ToClassOfStudents<T>(this IEnumerable<T> collection) 
                where T : Student
        {
            var output = new ClassOfStudents();

            foreach (dynamic student in collection)
            {
                output.AddStudent(student);
            }

            return output;
        }
    }
}
