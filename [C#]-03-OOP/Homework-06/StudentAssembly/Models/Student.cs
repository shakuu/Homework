namespace StudentAssembly.Models
{
    using System;
    using System.Collections;
    using System.Reflection;
    using System.Text;
    using Types;

    public class Student : IEnumerable
    {
        #region Properties
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string SSN { get; set; }
        public string PermanentAddress { get; set; }
        public string MobilePhone { get; set; }
        public string Email { get; set; }
        public string Course { get; set; }
        public SpecialtyType Specialty { get; set; }
        public FacultyType Faculty { get; set; }
        public UniversityType University { get; set; }
        #endregion

        #region Overrides
        public override string ToString()
        {
            var toString = new StringBuilder();
            var format = "{0, -16}: {1, 16}{2}";

            foreach (PropertyInfo prop in this)
            {
                toString.AppendFormat(
                    format,
                    prop.Name,
                    prop.GetValue(this),
                    Environment.NewLine);
            }

            return toString.ToString();
        }

        public override bool Equals(object obj)
        {
            if (obj.GetType() != typeof(Student))
                throw new ArgumentException("Invalid Object Type");

            var other = obj as Student;
            foreach (PropertyInfo prop in this)
            {
                var thisValue = prop.GetValue(this) == null ?
                                string.Empty : prop.GetValue(this).ToString();
                var otherValue = prop.GetValue(other) == null ?
                                string.Empty : prop.GetValue(other).ToString();

                if (thisValue != otherValue) return false;
            }
            
            return true;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public static bool operator ==(Student one, Student other)
        {
            return one.Equals(other);
        }

        public static bool operator !=(Student one, Student other)
        {
            return !one.Equals(other);
        }
        #endregion


        public IEnumerator GetEnumerator()
        {
            var properties = this.GetType().GetProperties();

            foreach (var prop in properties)
            {
                yield return prop;
            }
        }
    }
}
