namespace School.Exceptions
{
    using System;

    public class CourseException : ArgumentException
    {
        public const string StudentNotFoundErrorMessage = "Must pass an existing Student object to remove";
        public const string DuplicateStudentErrorMessage = "Must pass a unique student to add to course";
        public const string CourseOverCapacityErrorMessage = "Can only add new students up to the set course capacity";

        public CourseException(string message)
            : base(message)
        {
        }
    }
}
