namespace StudentAssembly.Models
{
    using System;
    using System.Collections;
    using System.IO;
    using System.Numerics;
    using System.Reflection;
    using System.Runtime.Serialization.Formatters.Binary;
    using System.Text;
    using Types;

    [Serializable]
    public class Student : IEnumerable, ICloneable, IComparable<Student>
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
            int result = 797;
            var multiply = 37;

            // Allow overflow.
            unchecked
            {
                // Known types strings and ints ( enums default to int )
                foreach (PropertyInfo prop in this)
                {
                    var hash = prop.GetValue(this) == null ?
                               0 : prop.GetValue(this).GetHashCode();

                    result = multiply * result + hash;

                }
            }

            return result;
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

        #region Interface Implementations
        /// <summary>
        /// Enumarates all properties of this class.
        /// </summary>
        /// <returns>Enumareta all class properties.</returns>
        public IEnumerator GetEnumerator()
        {
            var properties = this.GetType().GetProperties();

            foreach (var prop in properties)
            {
                yield return prop;
            }
        }

        /// <summary>
        /// Init a MemoryStreamand a BinaryFormatter.
        /// Serialze this to stream.
        /// Reset stream position.
        /// Deserialize stream to a new object.
        /// </summary>
        /// <returns>Object binary copy of this</returns>
        public object Clone()
        {
            object output;

            using (var stream = new MemoryStream())
            {
                var formatter = new BinaryFormatter();

                formatter.Serialize(stream, this);
                stream.Position = 0;
                output = formatter.Deserialize(stream);

                stream.Close();
            }

            return output;
        }

        /// <summary>
        /// Comapre by: 
        /// FirstName
        /// MiddleName
        /// LastName
        /// SSN
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public int CompareTo(Student other)
        {
            var comapre = new[]
            {
                "FirstName",
                "LastName",
                "MiddleName",
                "SSN"
            };

            var len = comapre.Length;
            for (int i = 0; i < len ; i++)
            {
                var property = this.GetType().GetProperty(comapre[i]);

                var valueThis = property.GetValue(this);
                var strThis = valueThis == null ?
                            string.Empty : valueThis.ToString();

                var valueOther = property.GetValue(other);
                var strOther = valueOther == null ?
                            string.Empty : valueOther.ToString();

                var result = strThis.CompareTo(strOther);

                if (result != 0) return -result;
            }

            //var thisSSN = BigInteger.Parse(this.SSN);
            //var otherSSN = BigInteger.Parse(other.SSN);

            //if (thisSSN > otherSSN) return -1;
            //else if (thisSSN < otherSSN) return 1;
            //else return 0;

            return 0;
        }
        #endregion
    }
}
