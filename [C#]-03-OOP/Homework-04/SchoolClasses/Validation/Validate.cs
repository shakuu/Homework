
namespace SchoolClasses.LocalValidation
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    public static class Validate
    {
        
        /// <summary>
        /// Read a file of forbidden words and check the text 
        /// for them.
        /// Check for empty string.
        /// </summary>
        /// <param name="value"></param>
        public static void ValidateComment(string value)
        {

            // TODO: 
            throw new NotImplementedException();
        }

        /// <summary>
        /// Larger than zero
        /// </summary>
        /// <param name="value"></param>
        public static void ValidateNumberOfLectures(int value)
        {
            // TODO: 
            throw new NotImplementedException();
        }

        /// <summary>
        /// Larger than zero
        /// Possibly merge with ValidateNumberOfLectures ?  
        /// </summary>
        /// <param name="value"></param>
        public static void ValidateNumberOfExcercises(int value)
        {
            // TODO:
            throw new NotImplementedException();
        }


        /// <summary>
        /// Each Class MUST have a Unique ID
        /// </summary>
        /// <param name="value"></param>
        public static void ValidateClassID(string value)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Student ID must be unique to his class
        /// </summary>
        /// <param name="value"></param>
        public static void ValidateStudentID(string value)
        {
            throw new NotImplementedException();
        }
    }
}
