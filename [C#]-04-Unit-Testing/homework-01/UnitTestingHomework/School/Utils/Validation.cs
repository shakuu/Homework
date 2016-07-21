namespace School.Utils
{
    using System;

    public static class Validation
    {
        public static bool CheckIfStringIsNullOrEmpty(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentNullException();
            }

            return true;
        }

        public static bool CheckIfNumberIsInRange(int value, int minimumValue, int maximumValue)
        {
            if (minimumValue <= value && value <= maximumValue)
            {
                return true;
            }
            else
            {
                throw new ArgumentOutOfRangeException();
            }
        }

        public static bool CheckIfObjectIsNull(object obj)
        {
            if(obj == null)
            {
                throw new ArgumentNullException();
            }

            return true;
        }
    }
}
