namespace School.Tests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using School.Contracts;
    using School.Exceptions;
    using School.Models;
    using School.Utils;

    [TestClass]
    public class CoursesTests
    {
        public IGenerateId GenerateID { get; private set; }

        [TestInitialize]
        public void InitializeIdGenerator()
        {
            this.GenerateID = new GenerateId(int.MinValue, int.MaxValue);
        }

        [TestMethod]
        [ExpectedException(typeof(CourseException), AllowDerivedTypes = false)]
        public void AddStudentToCourse_shouldThrow_ifCourseHasMaximumAllowedStudentsEnrolled()
        {
            var courseName = "course name";
            var courseMaximumCapacity = 10;
            ICourse testCourse = new Course(courseName, courseMaximumCapacity);

            for (int i = 0; i < courseMaximumCapacity + 1; i++)
            {
                var studentId = new GenerateId(0, 100).Generate();
                var studentName = "student name";
                IStudent testInputStudent = new Student(studentName, studentId);

                testCourse.AddStudentToCourse(testInputStudent);
            }

        }

        [TestMethod]
        [ExpectedException(typeof(CourseException), AllowDerivedTypes = true)]
        public void AddStudentToCourse_shouldThrow_ifPassedADuplicateStudent()
        {
            var id = new GenerateId(0, 100).Generate();
            var name = "student name";

            IStudent testInputStudent = new Student(name, id);
            ICourse testCourse = new Course();

            testCourse.AddStudentToCourse(testInputStudent);
            testCourse.AddStudentToCourse(testInputStudent);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), AllowDerivedTypes = true)]
        public void AddStudentToCourse_shouldThrow_ifPassedANullArgument()
        {
            throw new NotImplementedException();
        }

        [TestMethod]
        public void AddStudentToCourse_shouldReturnTrue_ifPassedAValidArgument()
        {
            throw new NotImplementedException();
        }

        [TestMethod]
        [ExpectedException(typeof(CourseException), AllowDerivedTypes = true)]
        public void RemoveStudentFromCourse_shouldThrow_ifPassedStudentIsNotFound()
        {
            throw new NotImplementedException();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), AllowDerivedTypes = true)]
        public void RemoveStudentFromCourse_shouldReturnTrue_ifPassedANullArgument()
        {
            throw new NotImplementedException();
        }

        [TestMethod]
        public void RemoveStudentFromCourse_shouldReturnTrue_ifPassedAValidArgument()
        {
            throw new NotImplementedException();
        }
    }
}
