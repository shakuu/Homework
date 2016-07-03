namespace ExceptionsAssembly
{
    using System;

    public class Validate
    {
        public static bool ValidateDataInRange<T>(T value, T min, T max)
            where T : IComparable<T>
        {
            if (min.CompareTo(value) > 0 || max.CompareTo(value) < 0)
            {
                throw new InvalidRangeException<T>(null, min, max);
            }
            else
            {
                return true;
            }
        }
    }
}