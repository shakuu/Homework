namespace School.Tests.Utils
{
    using System.Collections.Generic;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using School.Utils;

    [TestClass]
    public class ValidationTests
    {
        [TestMethod]
        public void CheckIfStringIsNullOrEmpty_shouldReturnTrue_ifPassedAnEmptyString()
        {
            var testInputEmptyString = string.Empty;

            var actual = Validation.CheckIfStringIsNullOrEmpty(testInputEmptyString);

            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void CheckIfStringIsNullOrEmpty_shouldReturnTrue_ifPassedNullValue()
        {
            string testInputNullString = null;

            var actual = Validation.CheckIfStringIsNullOrEmpty(testInputNullString);

            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void CheckIfStringIsNullOrEmpty_shouldReturnFalse_ifPassedNotNullOrEmptyString()
        {
            var testInputStudentNameString = "student name";

            var actual = Validation.CheckIfStringIsNullOrEmpty(testInputStudentNameString);

            Assert.IsFalse(actual);
        }

        [TestMethod]
        public void CheckIfNumberIsInRange_shouldReturnFalse_ifNumberIsBelowMinimumValue()
        {
            var minimumRangeValue = 1;
            var maximumRangeValue = 100;
            var testInputValue = 0;

            var actual = Validation.CheckIfNumberIsInRange(testInputValue, minimumRangeValue, maximumRangeValue);

            Assert.IsFalse(actual);
        }

        [TestMethod]
        public void CheckIfNumberIsInRange_shouldReturnFalse_ifNumberIsAboveMaximumValue()
        {
            var minimumRangeValue = 1;
            var maximumRangeValue = 100;
            var testInputValue = 999999;

            var actual = Validation.CheckIfNumberIsInRange(testInputValue, minimumRangeValue, maximumRangeValue);

            Assert.IsFalse(actual);
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
        public void CheckIfObjectIsNull_shouldReturnTrue_ifPassedParameterIsNull()
        {
            object testInput = null;

            var actualResult = Validation.CheckIfObjectIsNull(testInput);

            Assert.IsTrue(actualResult);
        }

        [TestMethod]
        public void CheckIfObjectIsNull_shouldReturnFalse_ifPassedParameterIsNotNull()
        {
            var testInput = new List<string>() { "test" };

            var actualResult = Validation.CheckIfObjectIsNull(testInput);

            Assert.IsFalse(actualResult);
        }
    }
}
