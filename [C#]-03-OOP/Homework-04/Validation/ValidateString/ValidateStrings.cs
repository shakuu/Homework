
namespace Validation.ValidateString
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class ValidateStrings
    {
        public static void ValidateName(string value)
        {
            #region validate
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentException("Name is null or empty");
            }
            else if (!char.IsUpper(value[0]))
            {
                throw new ArgumentException("Names must begin with a capital letter");
            }

            foreach (var chr in value)
            {
                if (!char.IsLetter(chr))
                {
                    throw new ArgumentException("Names can only contain valid letters");
                }
            }
            #endregion
        }

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
        /// Each Class MUST have a Unique ID
        /// </summary>
        /// <param name="value"></param>
        public static void ValidateClassID(string value)
        {
            throw new NotImplementedException();
        }
        
        /// <summary>
        ///  ID must be unique for the student out
        ///  of the students in his class. ( that's how school works ? )
        ///  OR unique overall ( as a university number ) ? 
        /// </summary
        /// <param name="value"></param>
        public static void ValidateStudentID(string value)
        {
            throw new NotImplementedException();
        }
    }
}
