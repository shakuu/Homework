namespace School.Tests.Models
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using School.Contracts;
    using School.Exceptions;
    using School.Models;

    [TestClass]
    public class SchoolTests
    {
        private IStudent testInputStudent;
        private ISchool testInputSchool;

        [TestInitialize]
        public void InitializeSchoolTests()
        {
            var testInputStudentName = "test student";
            var testInputStudentId = 10000;
            this.testInputStudent = new Student(testInputStudentName, testInputStudentId);

            // TODO: Init testing school.
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), AllowDerivedTypes = false)]
        public void AdmitStudent_shouldThrow_ifPassedStudentIsNull()
        {
            this.testInputStudent = null;
            this.testInputSchool.AdmitStudent(this.testInputStudent);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNotUniqueException), AllowDerivedTypes = false)]
        public void AdmitStudent_shouldThrow_ifThePassedStudentAlreadyExistsInStudentsICollection()
        {
            this.testInputSchool.AdmitStudent(this.testInputStudent);
            this.testInputSchool.AdmitStudent(this.testInputStudent);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNotUniqueException), AllowDerivedTypes = false)]
        public void AdmitStudent_shouldThrow_ifTheIdGeneratorWasNotAbleToGenerateAUniqueIdForTheNewlyAdmittedStudent()
        {
            // TODO: testing School with smaller number of possible ids ? 
            throw new NotImplementedException();
        }

        [TestMethod]
        public void AdmitStudent_shouldReturnTrue_ifStudentWasSuccessfullyAddedToICollection()
        {
            var actual = this.testInputSchool.AdmitStudent(this.testInputStudent);

            Assert.IsTrue(actual);
        }
    }
}
