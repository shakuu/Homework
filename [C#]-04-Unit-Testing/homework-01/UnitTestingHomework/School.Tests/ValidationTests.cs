namespace School.Tests
{
    using System;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using School.Utils;

    [TestClass]
    public class ValidationTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), AllowDerivedTypes = false)]
        public void CheckIfStringIsNullOrEmpty_shouldThrow_ifPassedAnEmptyString()
        {
            var testInputEmptyString = string.Empty;

            Validation.CheckIfStringIsNullOrEmpty(testInputEmptyString);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), AllowDerivedTypes = false)]
        public void CheckIfStringIsNullOrEmpty_shouldThrow_ifPassedNullValue()
        {
            string testInputNullString = null;

            Validation.CheckIfStringIsNullOrEmpty(testInputNullString);
        }

        [TestMethod]
        public void CheckIfStringIsNullOrEmpty_shouldReturnTrue_ifPassedNotNullOrEmptyString()
        {
            var testInputStudentNameString = "student name";
            var expectedOutput = true;

            var actualOutput = Validation.CheckIfStringIsNullOrEmpty(testInputStudentNameString);

            Assert.AreEqual(expectedOutput, actualOutput);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException), AllowDerivedTypes = false)]
        public void CheckIfNumberIsInRange_shouldThrow_ifNumberIsBelowMinimumValue()
        {
            var minimumRangeValue = 1;
            var maximumRangeValue = 100;
            var testInputValue = 0;

            Validation.CheckIfNumberIsInRange(testInputValue, minimumRangeValue, maximumRangeValue);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException), AllowDerivedTypes = false)]
        public void CheckIfNumberIsInRange_shouldThrow_ifNumberIsAboveMaximumValue()
        {
            var minimumRangeValue = 1;
            var maximumRangeValue = 100;
            var testInputValue = 999999;

            Validation.CheckIfNumberIsInRange(testInputValue, minimumRangeValue, maximumRangeValue);
        }

        [TestMethod]
        public void CheckIfNumberIsInRange_shouldReturnTrue_ifPassedANumberWithinTheGivenRange()
        {
            var minimumRangeValue = 1;
            var maximumRangeValue = 100;
            var testInputValue = 10;

            var expectedOutput = true;
            var actualOutput = Validation.CheckIfNumberIsInRange(testInputValue, minimumRangeValue, maximumRangeValue);

            Assert.AreEqual(expectedOutput, actualOutput);
        }
    }
}
