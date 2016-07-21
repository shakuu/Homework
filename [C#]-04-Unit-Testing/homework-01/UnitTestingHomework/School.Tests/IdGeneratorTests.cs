namespace School.Tests
{
    using System;
    using System.Collections.ObjectModel;

    using NUnit.Framework;

    using School.Exceptions;
    using School.Utils;

    [TestFixture]
    public class IdGeneratorTests
    {
        [Test]
        public void GenerateUniqueIdInRange_shouldThrow_ifThereIsNoAvailableUniqueIdWithinTheGivenRange()
        {
            var testInputExistingIds = new Collection<int>() { 1, 2, 3, 4, 5 };
            var testInputMinimumValue = 1;
            var testInputMaximumValue = 5;

            var ouputException = Assert.Throws<Exception>(() =>
                IdGenerator.GenerateUniqueIdInRange(testInputExistingIds, testInputMinimumValue, testInputMaximumValue));
        }

        [Test]
        public void GenerateUniqueIdInRange_shouldThrowArgumentNotUniqueException_ifThereIsNoAvailableUniqueIdWithinTheGivenRange()
        {
            var testInputExistingIds = new Collection<int>() { 1, 2, 3, 4, 5 };
            var testInputMinimumValue = 1;
            var testInputMaximumValue = 5;

            Assert.Catch<ArgumentNotUniqueException>(() =>
                IdGenerator.GenerateUniqueIdInRange(testInputExistingIds, testInputMinimumValue, testInputMaximumValue));
        }

        [Test]
        public void GenerateUniqueIdInRange_shouldReturnAUniqueIntValue()
        {
            var testInputExistingIds = new Collection<int>() { 1, 4, 5 };
            var testInputMinimumValue = 1;
            var testInputMaximumValue = 5;

            var actual = IdGenerator.GenerateUniqueIdInRange(testInputExistingIds, testInputMinimumValue, testInputMaximumValue);

            CollectionAssert.DoesNotContain(testInputExistingIds, actual);
        }

        [Test]
        public void GenerateUniqueIdInRange_shouldReturnIntGreaterThanOrEqualToMinimumValue()
        {
            var testInputExistingIds = new Collection<int>() { 1, 4, 5 };
            var testInputMinimumValue = 1;
            var testInputMaximumValue = 5;

            var actual = IdGenerator.GenerateUniqueIdInRange(testInputExistingIds, testInputMinimumValue, testInputMaximumValue);

            Assert.GreaterOrEqual(actual, testInputMinimumValue);
        }

        [Test]
        public void GenerateUniqueIdInRange_shouldReturnIntlessThanOrEqualToMaximumValue()
        {
            var testInputExistingIds = new Collection<int>() { 1, 4, 5 };
            var testInputMinimumValue = 1;
            var testInputMaximumValue = 5;

            var actual = IdGenerator.GenerateUniqueIdInRange(testInputExistingIds, testInputMinimumValue, testInputMaximumValue);

            Assert.GreaterOrEqual(testInputMaximumValue, actual);
        }
    }
}