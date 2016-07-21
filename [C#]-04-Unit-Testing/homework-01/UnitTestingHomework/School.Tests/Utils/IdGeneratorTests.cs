namespace School.Tests.Utils
{
    using System;
    using System.Collections.ObjectModel;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using School.Exceptions;
    using School.Utils;

    [TestClass]
    public class IdGeneratorTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNotUniqueException), AllowDerivedTypes = false)]
        public void GenerateUniqueIdInRange_shouldThrowArgumentNotUniqueException_ifThereIsNoAvailableUniqueIdWithinTheGivenRange()
        {
            var testInputExistingIds = new Collection<int>() { 1, 2, 3, 4, 5 };
            var testInputMinimumValue = 1;
            var testInputMaximumValue = 5;

            IdGenerator.GenerateUniqueIdInRange(testInputExistingIds, testInputMinimumValue, testInputMaximumValue);
        }

        [TestMethod]
        public void GenerateUniqueIdInRange_shouldReturnAUniqueIntValue()
        {
            var testInputExistingIds = new Collection<int>() { 1, 4, 5 };
            var testInputMinimumValue = 1;
            var testInputMaximumValue = 5;

            var actual = IdGenerator.GenerateUniqueIdInRange(testInputExistingIds, testInputMinimumValue, testInputMaximumValue);

            CollectionAssert.DoesNotContain(testInputExistingIds, actual);
        }

        [TestMethod]
        public void GenerateUniqueIdInRange_shouldReturnIntGreaterThanOrEqualToMinimumValue()
        {
            var testInputExistingIds = new Collection<int>() { 1, 4, 5 };
            var testInputMinimumValue = 1;
            var testInputMaximumValue = 5;

            var actual = IdGenerator.GenerateUniqueIdInRange(testInputExistingIds, testInputMinimumValue, testInputMaximumValue);

            Assert.IsTrue(testInputMinimumValue <= actual);
        }

        [TestMethod]
        public void GenerateUniqueIdInRange_shouldReturnIntlessThanOrEqualToMaximumValue()
        {
            var testInputExistingIds = new Collection<int>() { 1, 4, 5 };
            var testInputMinimumValue = 1;
            var testInputMaximumValue = 5;

            var actual = IdGenerator.GenerateUniqueIdInRange(testInputExistingIds, testInputMinimumValue, testInputMaximumValue);

            Assert.IsTrue(actual <= testInputMaximumValue);
        }

        [TestMethod]
        public void GenerateUniqueIdInRange_shouldReturnTheSmallestUniqueValue()
        {
            var testInputExistingIds = new Collection<int>() { 1, 4, 5 };
            var testInputMinimumValue = 1;
            var testInputMaximumValue = 5;

            var expectedValue = 2;
            var actual = IdGenerator.GenerateUniqueIdInRange(testInputExistingIds, testInputMinimumValue, testInputMaximumValue);

            Assert.AreEqual(expectedValue, actual);
        }
    }
}