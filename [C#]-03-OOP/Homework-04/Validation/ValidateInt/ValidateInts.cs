
namespace Validation.ValidateInt
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public static class ValidateInts
    {
        /// <summary>
        /// Larger than zero
        /// </summary>
        /// <param name="value"></param>
        public static void ValidateNumberOfLectures(int value)
        {
            StandardValidation(value);
        }

        /// <summary>
        /// Exercises CAN be zero
        /// Possibly merge with ValidateNumberOfLectures ?  
        /// </summary>
        /// <param name="value"></param>
        public static void ValidateNumberOfExcercises(int value)
        {
            StandardValidation(value);
        }

        private static void StandardValidation(int value)
        {
            if (value < 0)
            {
                throw new ArgumentException("Number must be positive");
            }
        }

        /// <summary>
        ///  ID must be unique for the student out
        ///  of the students in his class. ( that's how school works ? )
        ///  OR unique overall ( as a university number ) ? 
        /// </summary
        /// <param name="value"></param>
        public static void ValidateStudentID(int value)
        {
            throw new NotImplementedException();
        }
    }
}
