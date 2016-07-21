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

            var actualOutput = Validation.CheckIfNumberIsInRange(testInputValue, minimumRangeValue, maximumRangeValue);

            Assert.IsTrue(actualOutput);
        }

        [TestMethod]
        public void CheckIfNumberIsInRange_shouldReturnTrue_ifPassedANumberIsEqualToMinimumValue()
        {
            var minimumRangeValue = 1;
            var maximumRangeValue = 100;
            var testInputValue = minimumRangeValue;

            var actualOutput = Validation.CheckIfNumberIsInRange(testInputValue, minimumRangeValue, maximumRangeValue);

            Assert.IsTrue(actualOutput);
        }

        [TestMethod]
        public void CheckIfNumberIsInRange_shouldReturnTrue_ifPassedANumberIsEqualToMaximumValue()
        {
            var minimumRangeValue = 1;
            var maximumRangeValue = 100;
            var testInputValue = maximumRangeValue;

            var actualOutput = Validation.CheckIfNumberIsInRange(testInputValue, minimumRangeValue, maximumRangeValue);

            Assert.IsTrue(actualOutput);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), AllowDerivedTypes = false)]
        public void CheckIfObjectIsNull_shouldThrow_ifPassedParameterIsNull()
        {
            object testInput = null;

            Validation.CheckIfObjectIsNull(testInput);
        }

        [TestMethod]
        public void CheckIfObjectIsNull_shouldReturnTrue_ifPassedParameterIsNotNull()
        {
            var testInput = new Object();

            var actualResult= Validation.CheckIfObjectIsNull(testInput);

            Assert.IsTrue(actualResult);
        }
    }
}
