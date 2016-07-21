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
        private string courseName;
        private int courseMaximumCapacity;

        public IGenerateId GenerateID { get; private set; }

        [TestInitialize]
        public void InitializeIdGenerator()
        {
            this.GenerateID = new GenerateId(int.MinValue, int.MaxValue);
            
            courseName = "course name";
            courseMaximumCapacity = 10;
        }

        [TestMethod]
        [ExpectedException(typeof(CourseException), AllowDerivedTypes = false)]
        public void AddStudentToCourse_shouldThrow_ifCourseHasMaximumAllowedStudentsEnrolled()
        {
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
            
            ICourse testCourse = new Course(courseName, courseMaximumCapacity);

            testCourse.AddStudentToCourse(testInputStudent);
            testCourse.AddStudentToCourse(testInputStudent);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), AllowDerivedTypes = true)]
        public void AddStudentToCourse_shouldThrow_ifPassedANullArgument()
        {
            IStudent testInputStudent = null;
            
            ICourse testCourse = new Course(courseName, courseMaximumCapacity);

            testCourse.AddStudentToCourse(testInputStudent);
        }

        [TestMethod]
        public void AddStudentToCourse_shouldReturnTrue_ifPassedAValidArgument()
        {
            var id = new GenerateId(0, 100).Generate();
            var name = "student name";
            IStudent testInputStudent = new Student(name, id);

            ICourse testCourse = new Course(courseName, courseMaximumCapacity);

            var actual = testCourse.AddStudentToCourse(testInputStudent);

            Assert.IsTrue(actual);
        }

        [TestMethod]
        [ExpectedException(typeof(CourseException), AllowDerivedTypes = true)]
        public void RemoveStudentFromCourse_shouldThrow_ifPassedStudentIsNotFound()
        {
            var id = new GenerateId(0, 100).Generate();
            var name = "student name";
            IStudent testInputStudent = new Student(name, id);

            ICourse testCourse = new Course(courseName, courseMaximumCapacity);

            testCourse.RemoveStudentFromCourse(testInputStudent);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), AllowDerivedTypes = true)]
        public void RemoveStudentFromCourse_shouldReturnTrue_ifPassedANullArgument()
        {
            IStudent testInputStudent = null;

            ICourse testCourse = new Course(courseName, courseMaximumCapacity);

            testCourse.RemoveStudentFromCourse(testInputStudent);
        }

        [TestMethod]
        public void RemoveStudentFromCourse_shouldReturnTrue_ifPassedAValidArgument()
        {
            var id = new GenerateId(0, 100).Generate();
            var name = "student name";
            IStudent testInputStudent = new Student(name, id);

            ICourse testCourse = new Course(courseName, courseMaximumCapacity);

            testCourse.AddStudentToCourse(testInputStudent);
            var actual = testCourse.RemoveStudentFromCourse(testInputStudent);

            Assert.IsTrue(actual);
        }
    }
}
