namespace School.Tests.Models
{
    using System;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using School.Contracts;
    using School.Models;

    [TestClass]
    public class BaseObjectTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), AllowDerivedTypes = false)]
        public void NameSetter_shouldThrow_ifPassedValueIsANullString()
        {
            string testNameValue = null;
            var testIntValue = 100;

            IName testBaseObject = new Course(testNameValue, testIntValue);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), AllowDerivedTypes = false)]
        public void NameSetter_shouldThrow_ifPassedValueIsAnEmptyString()
        {
            string testNameValue = string.Empty;
            var testIntValue = 100;

            IName testBaseObject = new Course(testNameValue, testIntValue);
        }

        [TestMethod]
        public void NameSetter_objectNamePropertyShouldBeTheSameAsInput_ifThePassedStringIsNotNullOrEmpty()
        {
            string expectedNameValue = "course name";
            var testIntValue = 100;

            IName testBaseObject = new Course(expectedNameValue, testIntValue);

            var actualNameValue = testBaseObject.Name;

            Assert.AreEqual(expectedNameValue, actualNameValue);
        }
    }
}
