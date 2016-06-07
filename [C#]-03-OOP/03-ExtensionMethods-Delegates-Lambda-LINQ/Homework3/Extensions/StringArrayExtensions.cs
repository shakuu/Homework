
namespace Homework3.Extensions
{
    using System;
    using System.Linq;

    public static class StringArrayExtensions
    {
        public static string MaxLength(this string[] array)
        {
            var output =
                (from str in array
                 orderby str.Length descending
                 select str).ToArray()[0];

            return output;
        }
    }
}
