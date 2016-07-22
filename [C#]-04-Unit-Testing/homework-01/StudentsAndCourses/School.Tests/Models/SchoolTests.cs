namespace School.Tests.Models
{
    using System;
    using System.Collections.Generic;

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
            var testInputSchoolName = "test school";
            var testInputSchoolMinimumIdValue = 1;
            var testInputSchoolMaximumIdValue = 10;
            this.testInputSchool = new Schools(testInputSchoolName, testInputSchoolMinimumIdValue, testInputSchoolMaximumIdValue);
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
            var testInputSchoolName = "test school";
            var testInputSchoolMinimumIdValue = 1;
            var testInputSchoolMaximumIdValue = 2;
            this.testInputSchool = new Schools(testInputSchoolName, testInputSchoolMinimumIdValue, testInputSchoolMaximumIdValue);

            var students = new List<IStudent>()
            {
                new Student("1", 1),
                new Student("2", 1),
                new Student("3", 1)
            };

            for (int i = 0; i < students.Count; i++)
            {
                this.testInputSchool.AdmitStudent(students[i]);
            }
        }

        [TestMethod]
        public void AdmitStudent_shouldReturnTrue_ifStudentWasSuccessfullyAddedToICollection()
        {
            var actual = this.testInputSchool.AdmitStudent(this.testInputStudent);

            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void GenerateUniqueStudentID_shouldGenerateIdValueGreaterThanSchoolMinimumIdValue()
        {
            var testInputSchoolMinimumIdValue = 1;
            var testInputSchoolMaximumValue = 100;
            
            this.testInputSchool = new Schools("school", testInputSchoolMinimumIdValue, testInputSchoolMaximumValue);

            this.testInputSchool.AdmitStudent(this.testInputStudent);

            Assert.IsTrue(testInputSchoolMinimumIdValue <= this.testInputStudent.ID);
        }

        [TestMethod]
        public void GenerateUniqueStudentID_shouldGenerateIdValueLessThanSchoolMaximumIdValue()
        {
            var testInputSchoolMinimumIdValue = 1;
            var testInputSchoolMaximumValue = 100;
            
            this.testInputSchool = new Schools("school", testInputSchoolMinimumIdValue, testInputSchoolMaximumValue);

            this.testInputSchool.AdmitStudent(this.testInputStudent);

            Assert.IsTrue(this.testInputStudent.ID <= testInputSchoolMaximumValue);
        }
    }
}
