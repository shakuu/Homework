using Methods.OtherInfo.Contracts;
using Methods.Students.Contracts;

namespace Methods.Students
{
    internal class Student : IStudent
    {
        public Student(string firstName, string lastName, IOtherInformation otherInfo)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.OtherInfo = otherInfo;
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public IOtherInformation OtherInfo { get; set; }

        public bool IsOlderThan(Student other)
        {
            var thisBirthDate = this.OtherInfo.BirthDate;
            var otherBirthDate = other.OtherInfo.BirthDate;

            return thisBirthDate < otherBirthDate;
        }
    }
}
