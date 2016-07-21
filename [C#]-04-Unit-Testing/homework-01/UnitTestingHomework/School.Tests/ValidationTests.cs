namespace School.Tests
{
    using System;

    using NUnit.Framework;
    using School.Utils;

    /// <summary>
    /// Summary description for ValidationTests
    /// </summary>
    [TestFixture]
    public class ValidationTests
    {
        [Test]
        public void CheckIfStringIsNullOrEmpty_shouldThrow_ifPassedAnEmptyString()
        {
            var testInputEmptyString = string.Empty;

            Assert.Throws<ArgumentNullException>(() => Validation.CheckIfStringIsNullOrEmpty(testInputEmptyString));
        }

        [Test]
        public void CheckIfStringIsNullOrEmpty_shouldThrow_ifPassedNullValue()
        {
            string testInputNullString = null;

            Assert.Throws<ArgumentNullException>(() => Validation.CheckIfStringIsNullOrEmpty(testInputNullString));
        }

        [Test]
        public void CheckIfStringIsNullOrEmpty_shouldReturnTrue_ifPassedNotNullOrEmptyString()
        {
            var testInputStudentNameString = "student name";
            var expectedOutput = true;

            var actualOutput = Validation.CheckIfStringIsNullOrEmpty(testInputStudentNameString);

            Assert.AreEqual(expectedOutput, actualOutput);
        }

        [Test]
        public void CheckIfNumberIsInRange_shouldThrow_ifNumberIsBelowMinimumValue()
        {
            var minimumRangeValue = 1;
            var maximumRangeValue = 100;
            var testInputValue = 0;

            Assert.Throws<ArgumentOutOfRangeException>(() => Validation.CheckIfNumberIsInRange(testInputValue, minimumRangeValue, maximumRangeValue));
        }

        [Test]
        public void CheckIfNumberIsInRange_shouldThrow_ifNumberIsAboveMaximumValue()
        {
            var minimumRangeValue = 1;
            var maximumRangeValue = 100;
            var testInputValue = 999999;

            Assert.Throws<ArgumentOutOfRangeException>(() => Validation.CheckIfNumberIsInRange(testInputValue, minimumRangeValue, maximumRangeValue));
        }

        [Test]
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
