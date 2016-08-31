using Methods.OtherInfo.Contracts;
using Methods.Students.Contracts;

namespace Methods.Students
{
    /// <summary>
    /// Student class.
    /// </summary>
    public class Student : IStudent
    {
        /// <summary>
        /// Creates a new Student with the provided parameters.
        /// </summary>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <param name="otherInfo"></param>
        public Student(string firstName, string lastName, IPersonalInformation otherInfo)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.OtherInfo = otherInfo;
        }

        /// <summary>
        /// Student's first name.
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Student's last name.
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Contains birth place, birth date and a list of characteristics.
        /// </summary>
        public IPersonalInformation OtherInfo { get; set; }

        /// <summary>
        /// Compare two IStudent objects by IStudent.BirthDate value.
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool IsOlderThan(IStudent other)
        {
            var thisBirthDate = this.OtherInfo.BirthDate;
            var otherBirthDate = other.OtherInfo.BirthDate;

            return thisBirthDate < otherBirthDate;
        }
    }
}
