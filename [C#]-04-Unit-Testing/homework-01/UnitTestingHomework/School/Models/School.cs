namespace School.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using School.Models.Base;
    using School.Contracts;
    using School.Utils;

    public class Schools : BaseNameableObject, ISchool
    {
        private readonly int minimumIdValue;
        private readonly int maximumIdValue;

        private ICollection<ICourse> courses;
        private ICollection<IStudent> students;

        public Schools(string name, int minimumIdValue, int maximumIdValue)
            : base(name)
        {
            this.minimumIdValue = minimumIdValue;
            this.maximumIdValue = maximumIdValue;
        }

        public ICollection<ICourse> Courses
        {
            get
            {
                if (this.courses == null)
                {
                    this.courses = new List<ICourse>();
                }

                return new List<ICourse>(this.courses);
            }

            private set
            {
                this.courses = value;
            }
        }

        public ICollection<IStudent> Students
        {
            get
            {
                if (this.students == null)
                {
                    this.students = new HashSet<IStudent>();
                }

                return new HashSet<IStudent>(this.students);
            }

            private set
            {
                this.students = value;
            }
        }

        public bool AdmitStudent(IStudent student)
        {
            if (Validation.CheckIfObjectIsNull(student))
            {
                throw new ArgumentNullException();
            }

            var uniqueId = GenerateUniqueStudentID();
            student.ID = uniqueId;

            this.students.Add(student);

            return true;
        }

        private int GenerateUniqueStudentID()
        {
            var existingIds = this.ExtractExisingIds(this.Students);

            // TODO: exceptions
            var uniqueId = IdGenerator.GenerateUniqueIdInRange(existingIds, this.minimumIdValue, this.maximumIdValue);

            return uniqueId;
        }

        private IEnumerable<int> ExtractExisingIds(IEnumerable<IStudent> students)
        {
            var existingIds = students.Select(student => student.ID);

            if (existingIds.Count() == 0)
            {
                existingIds = new List<int>() { this.maximumIdValue };
            }

            return existingIds;
        }
    }
}
